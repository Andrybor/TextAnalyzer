using System.Collections.Generic;

namespace TextAnalyzer.Services.Interfaces
{
    public interface IMetricsService
    {
        public IEnumerable<string> GetMetrics();
        public string Analyze(string metricName, string text);
    }
}
