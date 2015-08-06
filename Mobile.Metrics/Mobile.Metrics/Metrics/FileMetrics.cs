namespace Mobile.Metrics.Metrics
{
    using Warnings;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Reporting;

    public class FileMetrics
    {
        public FileMetrics(string file)
        {
            this.File = file;
            this.Methods = new List<MethodMetrics>();
        }

        /// <summary>
        /// Path to the file.
        /// </summary>
        public string File { get; private set; }

        /// <summary>
        /// All metrics about methods declared into the file.
        /// </summary>
        public List<MethodMetrics> Methods { get; set; }

        /// <summary>
        /// All categories of this file.
        /// </summary>
        [JsonConverter(typeof(StringEnumsConverter<FileCategory>))]
        public FileCategory[] Categories { get; set; }

        /// <summary>
        /// Total lines (exluding non representative lines).
        /// </summary>
        public int Lines { get { return this.LinesOfCode + this.LinesOfComments; } }

        /// <summary>
        /// Lines of files that contain code.
        /// </summary>
        public int LinesOfCode { get; set; }

        /// <summary>
        /// Lines of files that contain comments.
        /// </summary>
        public int LinesOfComments { get; set; }

        /// <summary>
        /// All type declarations (Classes, Enumerations, Structs, ...).
        /// </summary>
        public int TypeDeclarations { get; set; }

        /// <summary>
        /// All member declarations (Properties, fields, ...).
        /// </summary>
        public int MemberDeclarations { get; set; }

        /// <summary>
        /// All method declarations.
        /// </summary>
        public int MethodDeclarations { get; set; }

        /// <summary>
        /// Size of file in bytes.
        /// </summary>
        public long Size { get; set; }

        private MethodMetrics methodsTotal;

        /// <summary>
        /// Aggregation of all methods metrics.
        /// </summary>
        public MethodMetrics MethodsTotal {
            get
            {
                if(this.methodsTotal == null)
                {
                    this.methodsTotal = new MethodMetrics()
                    {
                        CyclomaticComplexity = 0,
                    };

                    foreach (var method in this.Methods)
                    {
                        this.methodsTotal.CyclomaticComplexity += method.CyclomaticComplexity;
                    }
                }

                return this.methodsTotal;
            }
            set
            {
                this.methodsTotal = value;
            }
        }
    }
}
