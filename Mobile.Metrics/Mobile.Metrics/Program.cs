using Newtonsoft.Json;
using Mobile.Metrics.Analyzers;
using Mobile.Metrics.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Metrics
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var task = Run();
                task.Wait();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        private static async Task Run()
        {
            var analyzer = new SolutionAnalyzer();

            var analysis = await analyzer.Analyze(@"C:\Users\Alois Deniel\Documents\Mobile.Metrics\Example\Mobile.Metrics.Example\Mobile.Metrics.Example.sln");
            
            var html = new HtmlReporter();
            var json = new JsonReporter();

            await json.Generate(@"report.json", analysis);
            await html.Generate(@"report.html", analysis);
            
        }
    }
}
