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

        private string ApplyTemplates(string content, string solution)
        {
            content = content.Replace("{{SOLUTION}}", solution);
            content = content.Replace("{{Settings.Name}}", Settings.Global.Name);
            content = content.Replace("{{Settings.AccentColor}}", Settings.Global.Colors[0]);
            content = content.Replace("{{Settings.Colors}}", String.Format("[\"{0}\"]", String.Join("\",\"", Settings.Global.Colors)));

            return content;
        }

        private void SaveTemplates(string output, string content, string solution)
        {
            content = this.ApplyTemplates(content, solution);

            File.Delete(output);

            File.WriteAllText(output, content);
        }
        
        public async Task Generate(string output, Analysis metrics)
        {
            var json = jsonReporter.GenerateJson(metrics).Replace("\\", "\\\\").Replace("'", "\\'");
            var solution = metrics.Metrics.Name.Replace(".sln",String.Empty);

            var htmlOutput = output + solution + ".html";
            var cssOutput = output + solution + ".css";
            var jsOutput = output + solution + ".Mobile.Metrics.js";
            var dataOutput = output + solution + ".Data.js";
            
            var jsContent = File.ReadAllText("./Views/Js/Mobile.Metrics.js");
            var dataContent = String.Format("var jsonReport = '{0}'; console.log(jsonReport); var report = JSON.parse(jsonReport);", json);
            var htmlContent = File.ReadAllText("./Views/Html/Mobile.Metrics.html");

            // Can't get libsassnet or dotless to work so ugly workaround ...
            var cssContent = File.ReadAllText("./Views/Css/bootswatch.css");
            cssContent = cssContent
                .Replace("../fonts/", "http://bootswatch.com/fonts/")
                .Replace("#165ba8", "#444444")
                .Replace("#10427b", "#555555")
                .Replace("#1862b5", "{{Settings.AccentColor}}")
                .Replace("#1967be", "{{Settings.AccentColor}}")
                .Replace("#2780e3", "{{Settings.AccentColor}}");
            

            SaveTemplates(htmlOutput, htmlContent, solution);
            SaveTemplates(dataOutput, dataContent, solution);
            SaveTemplates(jsOutput, jsContent, solution);
            SaveTemplates(cssOutput, cssContent, solution);

        }
    }
}
