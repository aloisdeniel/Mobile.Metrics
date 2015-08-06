namespace Mobile.Metrics.Metrics
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Reporting;
    using System;
    using System.Collections.Generic;

    public class ProjectMetrics
    {
        public ProjectMetrics()
        {
            this.Files = new List<FileMetrics>();
            this.Categories = new ProjectCategory[0];
        }

        /// <summary>
        /// Name of the project.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Categories of the project.
        /// </summary>
        [JsonConverter(typeof(StringEnumsConverter<ProjectCategory>))]
        public ProjectCategory[] Categories { get; set; }

        /// <summary>
        /// Path to the .csproj file.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// All file metrics.
        /// </summary>
        public List<FileMetrics> Files { get; set; }

        private FileMetrics filesTotal;

        /// <summary>
        /// Aggregated file metrics.
        /// </summary>
        public FileMetrics FilesTotal {
            get
            {
                if(filesTotal == null)
                {
                    this.filesTotal = new FileMetrics(this.Path)
                    {
                        MethodsTotal = new MethodMetrics()
                        {
                            CyclomaticComplexity = 0
                        }
                    };

                    foreach (var file in this.Files)
                    {
                        this.filesTotal.LinesOfCode += file.LinesOfCode;
                        this.filesTotal.LinesOfComments += file.LinesOfComments;
                        this.filesTotal.MethodDeclarations += file.MethodDeclarations;
                        this.filesTotal.MemberDeclarations += file.MemberDeclarations;
                        this.filesTotal.TypeDeclarations += file.TypeDeclarations;

                        this.filesTotal.MethodsTotal.CyclomaticComplexity += file.MethodsTotal.CyclomaticComplexity;
                    }
                }
                
                return this.filesTotal;
            }
            set
            {
                this.filesTotal = value;
            }
        }
    }
}
