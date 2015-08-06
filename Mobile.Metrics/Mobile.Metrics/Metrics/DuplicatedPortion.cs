using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Metrics.Metrics
{
    public class DuplicatedPortion
    {
        public class Portion
        {
            public String File { get; set; }

            public int Line { get; set; }
        }

        public DuplicatedPortion()
        {
            this.Portions = new List<Portion>();
        }
        public String Content { get; set; }

        public List<Portion> Portions { get; set; }
        
    }
}
