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
        public async Task Generate(string output, Analysis metrics)
        {
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

            var json = JsonConvert.SerializeObject(metrics, Formatting.None, settings);

            File.Delete(output);

            using (var file = new StreamWriter(output, true))
            {
                await file.WriteAsync(json);
            }
        }
    }
}
