using Mobile.Metrics.Analyzers;
using Mobile.Metrics.Metrics;
using Mobile.Metrics.Warnings.Specifics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Metrics.Warnings
{
    public class SolutionWarningAnalyzer : IWarningAnalyzer
    {
        private List<IWarningAnalyzer> analyzers = new List<IWarningAnalyzer>()
        {
            new AmountOfCommentsAnalyzer(),
            new CyclomaticAnalyzer(),
            new TotalLinesAnalyzer(),
            new AssetsSizeAnalyzer(),
            new DuplicationAnalyzer(),
        };

        public void RegisterAnalyzer(IWarningAnalyzer analyzer)
        {
            this.analyzers.Add(analyzer);
        }

        public void Analyze(Analysis metrics)
        {
            foreach (var subAnalyzer in analyzers)
            {
                subAnalyzer.Analyze(metrics);
            }
        }
    }
}
