using Mobile.Metrics.Metrics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Metrics.Analyzers.Files
{
    public class AssetsAnalyzer : IFileAnalyzer
    {
        public string[] Extensions { get { return new string[] { ".png", ".jpg", ".jpeg", ".pdf", ".avi", ".mov" }; } }

        public Task<FileMetrics> Analyze(string path)
        {
            var metrics = new FileMetrics(path);

            metrics.Categories = new FileCategory[] { FileCategory.Assets };

            FileInfo f = new FileInfo(path);
            metrics.Size = f.Length;

            return Task.FromResult(metrics);
        }
    }
}
