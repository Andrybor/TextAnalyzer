using System.Collections.Generic;
using System.Linq;
using TextAnalyzer.Services.Interfaces;

namespace TextAnalyzer.Services.Implementations
{
    /// <summary>
    /// Service for analyzing text by particular metric
    /// </summary>
    public class MetricsService : IMetricsService
    {
        private IEnumerable<IMetric> _metrics;

        public MetricsService(IEnumerable<IMetric> metrics)
        {
            _metrics = metrics;
        }

        /// <summary>
        /// Get all metrics names
        /// </summary>
        /// <returns>array of metric names</returns>
        public IEnumerable<string> GetMetrics()
        {
            return _metrics.Select(i => i.Name);
        }

        /// <summary>
        /// Analyze text by metrci name
        /// </summary>
        /// <param name="metricName"></param>
        /// <param name="text"></param>
        /// <returns>string with result</returns>
        public string Analyze(string metricName, string text)
        {
            return _metrics.FirstOrDefault(i => i.Name == metricName).Analyze(text);
        }
    }
}
