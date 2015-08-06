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
    public class DuplicationAnalyzer : IWarningAnalyzer
    {
        public const double MaxDuplicatedPortions = 10;

        public void Analyze(Analysis metrics)
        {
            if(metrics.Warnings.Count > MaxDuplicatedPortions)
            {
                metrics.Warnings.Add(new Warning()
                {
                    File = metrics.Metrics.Path,
                    Level = WarningLevel.Major,
                    Message = Messages.Warning_Solution_Duplication_Message,
                    WorkAround = Messages.Warning_Solution_Duplication_WorkAround,
                });
            }
            
        }
    }
}
