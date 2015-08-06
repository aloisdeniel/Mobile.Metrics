namespace Mobile.Metrics.Warnings
{
    public class Warning
    {
        public WarningLevel Level { get; set; }

        public string Project { get; set; }

        public string File { get; set; }

        public string Method { get; set; }

        public string Message { get; set; }

        public string WorkAround { get; set; }
    }
}
