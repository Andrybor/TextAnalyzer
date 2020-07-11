using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TextAnalyzer.Models;
using TextAnalyzer.Services.Interfaces;

namespace TextAnalyzer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMetricsService _metricsService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMetricsService metricsService, ILogger<HomeController> logger)
        {
            _metricsService = metricsService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Metrics = _metricsService.GetMetrics();

            return View();
        }

        [HttpPost]
        public IActionResult Analyze(string metricName, string text)
        {
            return Content(_metricsService.Analyze(metricName, text));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
