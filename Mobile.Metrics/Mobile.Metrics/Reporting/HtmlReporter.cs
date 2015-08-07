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
        private JsonReporter jsonReporter = new JsonReporter();

        public HtmlReporter()
        {

        }
        
        public async Task Generate(string output, Analysis metrics)
        {
            var json = jsonReporter.GenerateJson(metrics).Replace("\\", "\\\\").Replace("'", "\\'");
            var solution = metrics.Metrics.Name.Replace(".sln",String.Empty);

            var htmlOutput = output + solution + ".html";
            var jsOutput = output + solution + ".Mobile.Metrics.js";
            var dataOutput = output + solution + ".Data.js";

            File.Delete(htmlOutput);
            File.Delete(jsOutput);
            File.Delete(dataOutput);

            var dataContent = String.Format("var jsonReport = '{0}'; console.log(jsonReport); var report = JSON.parse(jsonReport);", json);
            var htmlContent = File.ReadAllText("./Views/Html/Mobile.Metrics.html");
            htmlContent = htmlContent.Replace("{{SOLUTION}}", solution);
            
            File.Copy("./Views/Js/Mobile.Metrics.js", jsOutput);
            File.WriteAllText(htmlOutput, htmlContent);
            File.WriteAllText(dataOutput, dataContent);
        }
    }
}
