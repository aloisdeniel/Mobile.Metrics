using Mobile.Metrics.Metrics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Mobile.Metrics.Analyzers.Files
{
    public class XmlAnalyzer : IFileAnalyzer
    {
        private const string startMultilineComments = @"\<\!--";
        private const string endMultilineComments = @"--\>";
        private const string emptyLine = @"^(\s)*$";
        private const string onlyStartMultilineComments = @"^(\s)*(\<\!--)";
        private const string onlyEndMultilineComments = @"(--\>)(\s)*$";

        private readonly Regex startMultilineCommentsRegex = new Regex(startMultilineComments);
        private readonly Regex endMultilineCommentsRegex = new Regex(endMultilineComments);
        private readonly Regex onlyStartMultilineCommentsRegex = new Regex(onlyStartMultilineComments);
        private readonly Regex onlyEndMultilineCommentsRegex = new Regex(onlyEndMultilineComments);
        private readonly Regex emptyLineRegex = new Regex(emptyLine);

        public virtual string[] Extensions { get { return new string[] { ".xml" }; } }

        protected string FileContent;

        protected XmlDocument Document;

        /// <summary>
        /// Updates line count metrics of a file line.
        /// </summary>
        /// <param name="metrics"></param>
        /// <param name="line"></param>
        /// <param name="isComment"></param>
        private void CountLine(FileMetrics metrics, string line, ref bool isComment)
        {
            var isEmptyLine = emptyLineRegex.Match(line);

            if (line.Length > 0 && !isEmptyLine.Success)
            {
                var startComments = startMultilineCommentsRegex.Match(line).Success;
                var endComments = endMultilineCommentsRegex.Match(line).Success;

                var isLineComment = (isComment) || (startComments);
                var isLineCode = (!isLineComment) || (startComments && !onlyStartMultilineCommentsRegex.Match(line).Success) || (endComments && !onlyEndMultilineCommentsRegex.Match(line).Success);

                if (isLineComment)
                {
                    metrics.LinesOfComments++;
                }

                if (isLineCode)
                {
                    metrics.LinesOfCode++;
                }

                isComment = isLineComment && !endComments;
            }
        }

        public async virtual Task<FileMetrics> Analyze(string path)
        {
            var metrics = new FileMetrics(path);

            metrics.Categories = new FileCategory[] { FileCategory.View, FileCategory.Layout };

            using (var content = new StreamReader(path))
            {
                string line;
                var allLines = new StringBuilder();

                bool isComment = false;

                while ((line = await content.ReadLineAsync()) != null)
                {
                    this.CountLine(metrics, line, ref isComment);
                    allLines.AppendLine(line);
                }

                this.FileContent = allLines.ToString();

                this.Document = new XmlDocument();
                this.Document.LoadXml(FileContent);

                FileInfo f = new FileInfo(path);
                metrics.Size = f.Length;

                return metrics;
            }
        }
    }
}
