using Newtonsoft.Json;
using Mobile.Metrics.Analyzers;
using Mobile.Metrics.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mobile.Metrics
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var task = Run(args);
                task.Wait();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        private static string FindSolution()
        {
            var files = Directory.GetFiles(Environment.CurrentDirectory).ToList();
            return files.FirstOrDefault((f) => Path.GetExtension(f) == ".sln");
        }

        private static async Task Run(string[] args)
        {
            var arguments = new Arguments();
            if (CommandLine.Parser.Default.ParseArguments(args, arguments))
            {
                // Argument : Solution

                if (arguments.Solution == null)
                {
                    arguments.Solution = FindSolution();
                }

                if(arguments.Solution == null)
                {
                    throw new ArgumentException("No solution file found");
                }

                // Argument : Settings

                var defaultSettingsPath = arguments.Solution.Replace(".sln", ".metrics");
                if (arguments.Settings == null && File.Exists(defaultSettingsPath))
                {
                    var settings = File.ReadAllText(defaultSettingsPath);
                    Settings.Global = JsonConvert.DeserializeObject<Settings>(settings);
                }

                if (arguments.Settings != null)
                {
                    var settings = File.ReadAllText(arguments.Settings);
                    Settings.Global = JsonConvert.DeserializeObject<Settings>(settings);
                }

                // Argument : Output

                if (arguments.Output == null)
                {
                    arguments.Output = Path.GetDirectoryName(arguments.Solution);
                }

                // Argument : Reporting

                var reporting = arguments.Reporting.Split(',');
                
                // Analysis

                var analyzer = new SolutionAnalyzer();

                var analysis = await analyzer.Analyze(arguments.Solution);
                
                if (reporting.Contains("json"))
                {
                    var json = new JsonReporter();
                    await json.Generate(arguments.Output + analysis.Metrics.Name.Replace(".sln",".json"), analysis);
                }

                if (reporting.Contains("html"))
                {
                    var html = new HtmlReporter();
                    await html.Generate(arguments.Output + "\\", analysis);
                }
            }
        }
    }
}
