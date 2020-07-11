namespace TextAnalyzer.Services.Interfaces
{
    public interface IMetric
    {
        public string Analyze(string text);
        public string Name { get; set; }
    }
}
