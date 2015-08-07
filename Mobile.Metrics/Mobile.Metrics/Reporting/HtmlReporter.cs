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

        public void ApplyTemplates(string output, string content, string solution)
        {
            content = content.Replace("{{SOLUTION}}", solution);
            content = content.Replace("{{Settings.Name}}", Settings.Global.Name);
            content = content.Replace("{{Settings.Colors}}", String.Format("[\"{0}\"]", String.Join("\",\"", Settings.Global.Colors)));

            File.Delete(output);

            File.WriteAllText(output, content);
        }
        
        public async Task Generate(string output, Analysis metrics)
        {
            var json = jsonReporter.GenerateJson(metrics).Replace("\\", "\\\\").Replace("'", "\\'");
            var solution = metrics.Metrics.Name.Replace(".sln",String.Empty);

            var htmlOutput = output + solution + ".html";
            var jsOutput = output + solution + ".Mobile.Metrics.js";
            var dataOutput = output + solution + ".Data.js";
            

            var jsContent = File.ReadAllText("./Views/Js/Mobile.Metrics.js");
            var dataContent = String.Format("var jsonReport = '{0}'; console.log(jsonReport); var report = JSON.parse(jsonReport);", json);
            var htmlContent = File.ReadAllText("./Views/Html/Mobile.Metrics.html");

            ApplyTemplates(htmlOutput, htmlContent, solution);
            ApplyTemplates(dataOutput, dataContent, solution);
            ApplyTemplates(jsOutput, jsContent, solution);
        }
    }
}
