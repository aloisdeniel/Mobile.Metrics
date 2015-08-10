using Microsoft.CodeAnalysis;
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

        private string[] excludedFiles = new string[] { "/bin/", "/obj/", "\\bin\\", "\\obj\\", "/appdata/", "\\appdata\\", "AssemblyInfo.cs", ".g.cs", ".g.i.cs" };
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

            IEnumerable<Project> projects = new List<Project>();
            string solutionPath = String.Empty;

            try
            {
                var solution = await ws.OpenSolutionAsync(folderPath);
                projects = solution.Projects;
                solutionPath = solution.FilePath;
                Console.WriteLine("Loaded solution");
            }
            catch (Exception)
            {
                Console.WriteLine("Can't load solution through CodeAnalysis, trying to load each project independently ...");
                var slnContent = File.ReadAllText(folderPath);

                solutionPath = folderPath;
                var solutionDir = Path.GetDirectoryName(folderPath);
                var fpaths = Directory.GetFiles(solutionDir, "*.csproj", SearchOption.AllDirectories).ToList();
                var loadedProjects = new List<Project>();
                foreach (var p in fpaths)
                {
                    if(!String.IsNullOrEmpty(p) && slnContent.Contains(Path.GetFileName(p)))
                    {
                        try
                        {
                            var project = await ws.OpenProjectAsync(p);
                            loadedProjects.Add(project);
                            Console.WriteLine("Loaded project : {0}", p);
                        }
                        catch (Exception e2)
                        {
                            Console.WriteLine("Can't load project : {0} -> {1}", p, e2.Message);
                        }
                    }
                }
                projects = loadedProjects;
            }
            
            var solutionMetrics = new SolutionMetrics()
            {
                Path = solutionPath,
            };

            foreach (var project in projects)
            {
                if(project != null && !String.IsNullOrEmpty(project.FilePath) && !Settings.Global.IgnoredProjects.Contains(Path.GetFileName(project.FilePath)))
                {
                    var projectMetrics = new ProjectMetrics()
                    {
                        Name = project.Name,
                        Path = project.FilePath,
                    };

                    Console.WriteLine("Analysing project {0}", projectMetrics.Name);

                    // Files from a project
                    var projectPath = Path.GetDirectoryName(projectMetrics.Path);
                    var projectFilePaths = Directory.GetFiles(projectPath, "*", SearchOption.AllDirectories).ToList();
                    var documentsPaths = project.Documents.Where((d) => !projectFilePaths.Contains(d.FilePath)).Select((d) => d.FilePath);
                    projectFilePaths.AddRange(documentsPaths);

                    foreach (var doc in projectFilePaths)
                    {
                        try
                        {
                            if (!excludedFiles.Any((f) => doc.ToLowerInvariant().Contains(f.ToLowerInvariant())))
                            {
                                Console.WriteLine(" -> File {0} ...", doc);
                                
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
                        catch (Exception)
                        {
                            Console.WriteLine(" -> Failed to analyze file {0} ...", doc);
                        }
                    }

                    solutionMetrics.Projects.Add(projectMetrics);
                }
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
            //var totalDuplication = duplicationFinder.FindDuplicates () ;
            
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
