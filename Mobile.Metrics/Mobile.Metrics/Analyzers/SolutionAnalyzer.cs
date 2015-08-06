using Mobile.Metrics.Analyzers.Files;
using Mobile.Metrics.Metrics;
using Mobile.Metrics.Warnings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Metrics.Analyzers
{
    public class SolutionAnalyzer
    {
        private static readonly List<IFileAnalyzer> analyzers = new List<IFileAnalyzer>()
        {
            new CSharpAnalyzer(),
            new XmlAnalyzer(),
            new XamlAnalyzer(),
            new AssetsAnalyzer(),
        };
        
        private static SolutionWarningAnalyzer WarningAnalyzer = new SolutionWarningAnalyzer();

        private string[] excludedFiles = new string[] { "/bin/", "/obj/", "\\bin\\", "\\obj\\", "AssemblyInfo.cs", ".g.cs", ".g.i.cs" };
        private string[] duplicationFilesExt = new string[] { ".cs", ".xaml", ".xml" };
        private string[] excludedDuplicationFiles = new string[] { ".csproj", ".sln" };
        private string[] excludedDuplicationLinesStarts = new string[] { "using ", "namespace ", "//", "/*" };

        public async Task<Analysis> Analyze(String folderPath)
        {
            var result = new Analysis();

            //Duplication
            var duplicationFinder = new DuplicateFinderLib.FileDuplicateFinder();
            duplicationFinder.FirstLineMinWidth = 10;

            foreach (var excl in excludedDuplicationLinesStarts)
            {
                duplicationFinder.AddIgnoredLinePrefix(excl);
            }

            var ws = Microsoft.CodeAnalysis.MSBuild.MSBuildWorkspace.Create();
            
            var solution = await ws.OpenSolutionAsync(folderPath);

            var solutionMetrics = new SolutionMetrics()
            {
                Path = solution.FilePath,
            };

            foreach (var project in solution.Projects)
            {
                var projectMetrics = new ProjectMetrics()
                {
                    Name = project.Name,
                    Path = project.FilePath,
                };

                // Files from a project
                var projectPath = Path.GetDirectoryName(projectMetrics.Path);
                var projectFilePaths = Directory.GetFiles(projectPath, "*",SearchOption.AllDirectories).ToList();
                var documentsPaths = project.Documents.Where((d) => !projectFilePaths.Contains(d.FilePath)).Select((d) => d.FilePath);
                projectFilePaths.AddRange(documentsPaths);
                
                foreach (var doc in projectFilePaths)
                {
                    if (!excludedFiles.Any((f) => doc.ToLowerInvariant().Contains(f)))
                    {
                        var m = await this.AnalyzeFile(doc);
                        if (m != null)
                        {
                            projectMetrics.Files.Add(m);
                        }

                        if (duplicationFilesExt.Any((f) => Path.GetExtension(doc).Contains(f)) && !excludedDuplicationFiles.Any((f) => Path.GetFileName(doc).Contains(f)))
                        {
                            duplicationFinder.ReadFile(doc);
                        }
                    }
                }

                solutionMetrics.Projects.Add(projectMetrics);
            }

            result.Metrics = solutionMetrics;

            WarningAnalyzer.Analyze(result);

            //Duplication
            duplicationFinder.OnDuplicate += (s,e) =>
            {
                if (!(e.Items.Count == 2 && e.Items[0].FileName == e.Items[1].FileName && e.Items[0].LineNumber == e.Items[1].LineNumber))
                {
                    var line = e.Items[0];
                    var content = new StringBuilder(line.Content);

                    while ((line = line.NextLine) != null)
                    {
                        content.AppendLine(line.Content);
                    }

                    var duplicated = new DuplicatedPortion()
                    {
                        Content = content.ToString(),
                        Portions = e.Items.Select((item) => new DuplicatedPortion.Portion()
                        {
                            File = item.FileName,
                            Line = item.LineNumber,
                        }).ToList()
                    };

                    result.Duplicates.Add(duplicated);
                }
                
            };
            var totalDuplication = duplicationFinder.FindDuplicates () ;

            Console.WriteLine("Found {0} duplicates");
            
            
            return result;
        }

        private void AnalyzeUnitTests()
        {
            
        }

        private void DuplicationFinder_OnDuplicate(object sender, DuplicateFinderLib.DuplicateEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async Task<FileMetrics> AnalyzeFile(string path)
        {
            var ext = Path.GetExtension(path);

            var analyzer = analyzers.FirstOrDefault((a) => a.Extensions.Contains(ext));

            if (analyzer != null)
            {
                return await analyzer.Analyze(path);
            }

            return null;
        }
    }
}
