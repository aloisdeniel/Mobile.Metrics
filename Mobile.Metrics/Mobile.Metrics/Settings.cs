using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Metrics
{
    public class Settings
    {
        public static Settings Default = new Settings()
        {
            Name = "Mobile.Metrics",
            Colors = defaultColors,
        };

        private readonly static string[] defaultColors = new string[] { "#2780E3", "#3fB618", "#9954BB", "#FF7518", "#FF0039" };

        private static volatile Settings instance;
        
        public static Settings Global
        {
            get
            {
                if (instance == null)
                {
                    instance = Default;
                }

                return instance;
            }
            set
            {
                instance = value;
            }

        }

        public string Name { get; set; }
        
        private string[] colors;

        public string[] Colors
        {
            get {

                if (colors == null)
                    return defaultColors;

                return colors;

            }
            set { colors = value; }
        }


        public string[] IgnoredProjects { get; set; }
    }
}
