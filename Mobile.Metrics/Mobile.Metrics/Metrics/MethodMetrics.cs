using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Metrics.Metrics
{
    public class MethodMetrics
    {
        public MethodMetrics()
        {
            this.CyclomaticComplexity = 1;
        }

        public string Name { get; set; }

        public int CyclomaticComplexity { get; set; }

        public int HalsteadVolume { get; set; }
    }
}
