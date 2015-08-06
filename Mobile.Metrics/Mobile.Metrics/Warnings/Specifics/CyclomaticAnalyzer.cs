using Mobile.Metrics.Analyzers;
using Mobile.Metrics.Localization;
using Mobile.Metrics.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Metrics.Warnings.Specifics
{
    public class CyclomaticAnalyzer : IWarningAnalyzer
    {
        public const double MaxCyclomatic = 15;

        public void Analyze(Analysis metrics)
        {
            foreach (var project in metrics.Metrics.Projects)
            {
                foreach (var file in project.Files)
                {
                    foreach (var method in file.Methods)
                    {
                        if (method.CyclomaticComplexity > MaxCyclomatic)
                        {
                            metrics.Warnings.Add(new Warning()
                            {
                                File = file.File,
                                Method = method.Name,
                                Project = project.Name,
                                Level = WarningLevel.Major,
                                Message = string.Format(Messages.Warning_Method_HighCyclomaticComplexity_Message, method.CyclomaticComplexity),
                                WorkAround = Messages.Warning_Method_HighCyclomaticComplexity_WorkAround,
                            });
                        }
                    }
                }
            }
        }
    }
}
