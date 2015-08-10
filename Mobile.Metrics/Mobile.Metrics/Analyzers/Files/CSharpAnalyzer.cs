// test de comment
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Mobile.Metrics.Metrics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mobile.Metrics.Analyzers.Files
{
    public class CSharpAnalyzer : IFileAnalyzer
    {
        private const string singlelineComment = @"(\s)*(\/\/(.*))";
        private const string startMultilineComments = @"\/\*";
        private const string endMultilineComments = @"\*\/";
        private const string onlyStartMultilineComments = @"^(\s)*(\/\*)";
        private const string onlyEndMultilineComments = @"(\*\/)(\s)*$";
        private const string emptyLine = @"^(\s|\{|\})*$";

        private readonly Regex singlelineCommentRegex = new Regex(singlelineComment);
        private readonly Regex startMultilineCommentsRegex = new Regex(startMultilineComments);
        private readonly Regex onlyStartMultilineCommentsRegex = new Regex(onlyStartMultilineComments);
        private readonly Regex onlyEndMultilineCommentsRegex = new Regex(onlyEndMultilineComments);
        private readonly Regex endMultilineCommentsRegex = new Regex(endMultilineComments);
        private readonly Regex emptyLineRegex = new Regex(emptyLine);

        public string[] Extensions { get { return new string[] { ".cs" }; } }

        public static string[] IgnoredFiles = new string[] { ".g.cs", "AssemblyInfo.cs" };

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
                var singleLine = singlelineCommentRegex.Match(line).Success;
                
                var isLineComment = (isComment) || (startComments) || singleLine;
                var isLineCode = (!isLineComment) || (startComments && !onlyStartMultilineCommentsRegex.Match(line).Success) || (endComments && !onlyEndMultilineCommentsRegex.Match(line).Success);
                
                if (isLineComment)
                {
                    metrics.LinesOfComments++;
                }
                
                if (isLineCode)
                {
                    metrics.LinesOfCode++;
                }

                isComment = isLineComment && !singleLine && !endComments;
            }
        }

        private void AnalyzeSyntaxTree(FileMetrics metrics, String content)
        {
            SyntaxTree tree = CSharpSyntaxTree.ParseText(content);

            var root = (CompilationUnitSyntax)tree.GetRoot();

            this.CountMembers(metrics, root);
            this.CalculateCyclomatic(metrics, root);
        }

        #region Count members

        private static readonly SyntaxKind[] TypeKinds = new SyntaxKind[] { SyntaxKind.InterfaceDeclaration, SyntaxKind.ClassDeclaration, SyntaxKind.StructDeclaration, SyntaxKind.EnumDeclaration };
        private static readonly SyntaxKind[] MemberKinds = new SyntaxKind[] { SyntaxKind.PropertyDeclaration, SyntaxKind.FieldDeclaration };
        private static readonly SyntaxKind[] MethodKinds = new SyntaxKind[] { SyntaxKind.MethodDeclaration, SyntaxKind.ConstructorDeclaration, SyntaxKind.DestructorDeclaration };

        private void CountMembers(FileMetrics metrics, SyntaxNode node)
        {
            var kind = node.Kind();

            if (TypeKinds.Contains(kind))
            {
                metrics.TypeDeclarations++;
            }
            else if (MemberKinds.Contains(kind))
            {
                metrics.MemberDeclarations++;
            }
            else if (MethodKinds.Contains(kind))
            {
                metrics.MethodDeclarations++;
            }

            foreach (var child in node.ChildNodes())
            {
                this.CountMembers(metrics, child);
            }
        }

        #endregion

        #region Cyclomatic complexity

        private static readonly SyntaxKind[] CyclomaticKinds = new SyntaxKind[] 
        {
            SyntaxKind.IfStatement,
            SyntaxKind.ElseClause,
            SyntaxKind.WhileStatement,
            SyntaxKind.ForEachStatement,
            SyntaxKind.ForStatement,
            SyntaxKind.CaseSwitchLabel,
            SyntaxKind.LogicalAndExpression,
            SyntaxKind.LogicalOrExpression,
            SyntaxKind.TryStatement,
            SyntaxKind.CatchDeclaration,
            SyntaxKind.ConditionalExpression,
            SyntaxKind.ConditionalAccessExpression,
        };
     
        private string FindMethodName(SyntaxNode node)
        {

            var kind = node.Kind();
            var isGetter = kind == SyntaxKind.GetAccessorDeclaration;
            var isSetter = kind == SyntaxKind.SetAccessorDeclaration;

            if(isGetter || isSetter)
            {
                var type = node.Ancestors().OfType<PropertyDeclarationSyntax>().FirstOrDefault();

                if (isGetter)
                {
                    return type?.Identifier.ValueText + ".get() : " + type?.Type;
                }
                else if (isSetter)
                {
                    return type?.Identifier.ValueText + ".set(" + type?.Type + " value) : void";
                }
            }

            var name = "";
            string returnType = String.Empty;

            if (node is MethodDeclarationSyntax)
            {
                var m = (node as MethodDeclarationSyntax);
                name = m.Identifier.ValueText;
                returnType = " : " + m.ReturnType.ToString();
            }
            else if (node is ConstructorDeclarationSyntax)
            {
                name = (node as ConstructorDeclarationSyntax).Identifier.ValueText;
            }
            else if (node is DestructorDeclarationSyntax)
            {
                name = (node as DestructorDeclarationSyntax).Identifier.ValueText;
            }
            
            var parameters = node.DescendantNodes().OfType<ParameterListSyntax>().FirstOrDefault();

            return name + (parameters == null ? "()" : parameters.ToString()) + returnType;
        }

        private void CalculateCyclomatic(FileMetrics metrics, SyntaxNode node)
        {
            var kind = node.Kind();
            
            if (MethodKinds.Contains(kind) || kind == SyntaxKind.GetAccessorDeclaration || kind == SyntaxKind.SetAccessorDeclaration)
            {
                var method = new MethodMetrics()
                {
                    Name = this.FindMethodName(node)
                };

                CalculateMethodCyclomatic(method, node);

                metrics.Methods.Add(method);
            }

            foreach (var child in node.ChildNodes())
            {
                CalculateCyclomatic(metrics, child);
            }
        }
        
        private void CalculateMethodCyclomatic(MethodMetrics metrics, SyntaxNode node)
        {
            var kind = node.Kind();
            
            if (CyclomaticKinds.Contains(kind))
            {
                metrics.CyclomaticComplexity++;
            }

            foreach (var child in node.ChildNodes())
            {
                CalculateMethodCyclomatic(metrics, child);
            }
            
        }

        #endregion

        #region Halstead volume

        private void CalculateHalsteadVolume(FileMetrics metrics, SyntaxNode node)
        {
            //TODO:
        }

        #endregion

        private FileCategory[] GetCategories(string path)
        {
            if(path.ToLowerInvariant().EndsWith(".xaml.cs"))
            {
                return new FileCategory[] { FileCategory.Code, FileCategory.View };
            }

            return new FileCategory[] { FileCategory.Code };
        }
                
        public async Task<FileMetrics> Analyze(string path)
        {
            if(IgnoredFiles.Any((s) =>  Path.GetFileName(path).Contains(s)) || !File.Exists(path))
            {
                return null;
            }

            var metrics = new FileMetrics(path);

            metrics.Categories = GetCategories(path);
            
            using (var content = new StreamReader(path))
            {
                // Count lines
                string line;
                var allLines = new StringBuilder();

                bool isComment = false;
                
                while ((line = await content.ReadLineAsync()) != null)
                {
                    this.CountLine(metrics, line, ref isComment);
                    allLines.AppendLine(line);
                }

                // Count members
                this.AnalyzeSyntaxTree(metrics, allLines.ToString());

                // Other infos
                FileInfo f = new FileInfo(path);
                metrics.Size = f.Length;
                
                return metrics;
            }
        }
    }
}
