using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile.Metrics.Metrics;
using Newtonsoft.Json;
using System.IO;
using Mobile.Metrics.Analyzers;

namespace Mobile.Metrics.Reporting
{
    public class JsonReporter : IReporter
    {
        public string GenerateJson(Analysis metrics)
        {
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

            return JsonConvert.SerializeObject(metrics, Formatting.None, settings);
        }

        public async Task Generate(string output, Analysis metrics)
        {
            var json = this.GenerateJson(metrics);

            File.Delete(output);

            using (var file = new StreamWriter(output, true))
            {
                await file.WriteAsync(json);
            }
        }
    }
}
