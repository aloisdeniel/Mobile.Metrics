using Mobile.Metrics.Analyzers;
using Mobile.Metrics.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Metrics.Reporting
{
    public interface IReporter
    {
        Task Generate(string output, Analysis metrics);
    }
}
