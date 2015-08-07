using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Metrics
{
    // Define a class to receive parsed values
    public class Arguments
    {
        [Option('i', "input", Required = false, HelpText = "The input solution file to analyze.")]
        public string Solution { get; set; }

        [Option('o', "output", Required = false, HelpText = "The folder where the output will be written")]
        public string Output { get; set; }

        [Option('s', "settings", Required = false, HelpText = "The settings file (.json)")]
        public string Settings { get; set; }

        [Option('r', "reporting", Required = false, DefaultValue ="html", HelpText = "The output reporting type (comma separated). It could be 'json', 'html'.")]
        public string Reporting { get; set; }

    }
}
