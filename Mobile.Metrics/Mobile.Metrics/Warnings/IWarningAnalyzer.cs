using Mobile.Metrics.Analyzers;
using Mobile.Metrics.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Metrics.Warnings
{
    public interface IWarningAnalyzer
    {
        void Analyze(Analysis metrics);
    }
}
