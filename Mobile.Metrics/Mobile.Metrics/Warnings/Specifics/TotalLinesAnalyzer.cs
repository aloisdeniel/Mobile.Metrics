using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.Metrics.Metrics;
using Mobile.Metrics.Localization;
using Mobile.Metrics.Analyzers;

namespace Mobile.Metrics.Warnings.Specifics
{
    public class TotalLinesAnalyzer : IWarningAnalyzer
    {
        public const double MaxLines = 1000;

        public void Analyze(Analysis metrics)
        {
            foreach (var project in metrics.Metrics.Projects)
            {
                foreach (var file in project.Files)
                {
                    //TODO : improve amount for different file categories
                    //TODO : add method line count to add specific warnings for methods with too many code lines.
                    if (file.LinesOfCode > MaxLines)
                    {
                        metrics.Warnings.Add(new Warning()
                        {
                            File = file.File,
                            Project = project.Name,
                            Level = WarningLevel.Major,
                            Message = string.Format(Messages.Warning_File_HighNumberOfLines_Message, file.LinesOfCode),
                            WorkAround = Messages.Warning_File_HighNumberOfLines_WorkAround,
                        });
                    }
                }
            }
        }
    }
}
