using Mobile.Metrics.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Metrics.Analyzers.Files
{
    public interface IFileAnalyzer
    {
        string[] Extensions { get; }

        Task<FileMetrics> Analyze(string path);
    }
}
