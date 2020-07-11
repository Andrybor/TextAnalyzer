using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TextAnalyzer.Controllers;
using TextAnalyzer.Metrics.Implementations;
using TextAnalyzer.Services.Implementations;
using TextAnalyzer.Services.Interfaces;
using Xunit;

namespace TextAnalyzer.UnitTests
{
    public class HomeControllerTests
    {
        /// <summary>
        /// test method for frequent word metric
        /// </summary>
        [Fact]
        public void TestFrequentWordMetric()
        {
            // Init
            IMetric metricfirst = new FrequentWordMetric();
            IEnumerable<IMetric> metrics = new List<IMetric> { metricfirst };
            IMetricsService metricsService = new MetricsService(metrics);

            // Arrange
            HomeController controller = new HomeController(metricsService, null);

            // Act
            var result = (controller.Analyze(metricfirst.Name, "1 1") as ContentResult).Content;

            // Assert
            Assert.Equal("Word - " + 1 + "/" + "Count - " + 2 + "; ", result);
        }
    }
}
