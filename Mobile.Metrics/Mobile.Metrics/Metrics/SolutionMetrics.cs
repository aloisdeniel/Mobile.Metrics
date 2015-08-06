namespace Mobile.Metrics.Metrics
{
    using Newtonsoft.Json;
    using System.Linq;
    using System.Collections.Generic;

    public class SolutionMetrics
    {
        /// <summary>
        /// Main constructor.
        /// </summary>
        public SolutionMetrics()
        {
            this.Projects = new List<ProjectMetrics>();
        }
        
        /// <summary>
        /// Name of the solution.
        /// </summary>
        public string Name { get { return System.IO.Path.GetFileName(Path); } }

        /// <summary>
        /// File path to the .sln file.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Metrics for all referenced projects.
        /// </summary>
        public List<ProjectMetrics> Projects { get; set; }

        public Dictionary<ProjectCategory, ProjectMetrics> TotalProjectCategories {
            get
            {
                var result = new Dictionary<ProjectCategory, ProjectMetrics>();

                this.Projects.ForEach((p) => {
                    
                    foreach (var category in p.Categories)
                    {
                        if(!result.ContainsKey(category))
                        {
                            result[category] = new ProjectMetrics()
                            {
                                FilesTotal = new FileMetrics(null)
                                {
                                    MethodsTotal = new MethodMetrics()
                                    {
                                        CyclomaticComplexity = 0
                                    }
                                }
                            };

                        }

                        result[category].FilesTotal.LinesOfCode += p.FilesTotal.LinesOfCode;
                        result[category].FilesTotal.LinesOfComments += p.FilesTotal.LinesOfComments;
                        result[category].FilesTotal.MemberDeclarations += p.FilesTotal.MemberDeclarations;
                        result[category].FilesTotal.MethodDeclarations += p.FilesTotal.MethodDeclarations;

                        result[category].FilesTotal.MethodsTotal.CyclomaticComplexity += p.FilesTotal.MethodsTotal.CyclomaticComplexity;
                    } 

                });

                return result;
            }
        }

        /// <summary>
        /// All file metrics from all referenced projects.
        /// </summary>
        [JsonIgnore]
        public List<FileMetrics> Files { get
            {
                var result = new List<FileMetrics>();

                foreach (var project in this.Projects)
                {
                    result.AddRange(project.Files);
                }

                return result;
            }
        }
    }
}
