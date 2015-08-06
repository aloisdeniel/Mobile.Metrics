using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.Metrics.Metrics;
using System.Xml;

namespace Mobile.Metrics.Analyzers.Files
{
    public class XamlAnalyzer : XmlAnalyzer
    {
        public override string[] Extensions { get { return new string[] { ".xaml" }; } }


        private void CountMembers(FileMetrics metrics, XmlNode node)
        {
            if(node.Attributes != null)
            {
                foreach (XmlAttribute attr in node.Attributes)
                {
                    if(attr.Name.ToLowerInvariant() == "x:name")
                    {
                        metrics.MemberDeclarations++;
                    }
                }
            }

            foreach (XmlNode child in node.ChildNodes)
            {
                this.CountMembers(metrics, child);
            }
        }

        public override async Task<FileMetrics> Analyze(string path)
        {
            var metrics = await base.Analyze(path);
            
            this.CountMembers(metrics,this.Document);

            return metrics;
        }
    }
}
