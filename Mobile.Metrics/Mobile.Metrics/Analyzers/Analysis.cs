using DuplicateFinderLib;
using Mobile.Metrics.Metrics;
using Mobile.Metrics.Warnings;
using System.Collections.Generic;

namespace Mobile.Metrics.Analyzers
{
    public class Analysis
    {
        public Analysis()
        {
            this.Warnings = new List<Warning>();
            this.Duplicates = new List<DuplicatedPortion>();
        }

        public SolutionMetrics Metrics { get; set; }
        public List<Warning> Warnings { get; set; }
        public List<DuplicatedPortion> Duplicates { get; set; }
    }
}
