using System.Collections.Generic;
using Mobile.Metrics.Metrics;
using System;
using Mobile.Metrics.Localization;
using Mobile.Metrics.Analyzers;

namespace Mobile.Metrics.Warnings.Specifics
{
    public class AmountOfCommentsAnalyzer : IWarningAnalyzer
    {
        public const double MinAmount = 0.2;

        public void Analyze(Analysis metrics)
        {
            foreach (var project in metrics.Metrics.Projects)
            {
                foreach (var file in project.Files)
                {
                    //TODO : improve amount for different file categories
                    var amountOfComments = file.LinesOfComments * 1.0 / (file.LinesOfCode + file.LinesOfComments);
                    if (amountOfComments < MinAmount)
                    {
                        metrics.Warnings.Add(new Warning()
                        {
                            File = file.File,
                            Project = project.Name,
                            Level = WarningLevel.Minor,
                            Message = string.Format(Messages.Warning_File_LowAmountOfComments_Message, amountOfComments * 100),
                            WorkAround = Messages.Warning_File_LowAmountOfComments_WorkAround,
                        });
                    }
                }
            }   
                    
        }
    }
}
