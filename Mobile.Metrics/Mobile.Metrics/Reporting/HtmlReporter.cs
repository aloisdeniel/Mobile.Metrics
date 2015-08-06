using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.Metrics.Metrics;
using System.IO;
using Mustache;
using Mobile.Metrics.Analyzers;

namespace Mobile.Metrics.Reporting
{
    public class HtmlReporter : IReporter
    {

        public HtmlReporter()
        {

        }
        
        public async Task Generate(string output, Analysis metrics)
        {
            File.Delete(output);
            
            using (var template = new StreamReader("./Views/Html/Report.html.mustache"))
            {
                FormatCompiler compiler = new FormatCompiler();
                Generator generator = compiler.Compile(await template.ReadToEndAsync());

                string result = generator.Render(metrics.Metrics);

                using (var file = new StreamWriter(output, true))
                {
                    await file.WriteAsync(result);
                }
            }     
        }
    }
}
