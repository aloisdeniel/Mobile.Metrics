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
    public class AssetsSizeAnalyzer : IWarningAnalyzer
    {
        public const double MaxSize = 300000;

        public void Analyze(Analysis metrics)
        {
            foreach (var project in metrics.Metrics.Projects)
            {
                foreach (var file in project.Files)
                {
                    if(file.Categories.Contains(FileCategory.Assets))
                    {
                        if (file.Size > MaxSize)
                        {
                            metrics.Warnings.Add(new Warning()
                            {
                                File = file.File,
                                Project = project.Name,
                                Level = WarningLevel.Minor,
                                Message = string.Format(Messages.Warning_File_HighSize_Message, file.Size),
                                WorkAround = Messages.Warning_File_HighSize_WorkAround,
                            });
                        }
                    }
                }
            }
        }
    }
}
