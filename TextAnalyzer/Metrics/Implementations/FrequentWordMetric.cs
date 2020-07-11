using System.Linq;
using TextAnalyzer.Services.Interfaces;

namespace TextAnalyzer.Metrics.Implementations
{
    public class FrequentWordMetric : IMetric
    {
        public FrequentWordMetric()
        {
            Name = "Frequent word";
        }

        public string Name { get; set; }

        /// <summary>
        /// Analyze each word in text on repeating
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string Analyze(string text)
        {
            string result = string.Empty;

            var analyzed = text.Split(' ').GroupBy(x => x)
                              .Select(x => new { Count = x.Count(), Word = x.Key })
                              .OrderByDescending(x => x.Count);

            foreach (var item in analyzed)
            {
                result += "Word - " + item.Word + "/" + "Count - " + item.Count + "; ";
            }

            return result;
        }
    }
}
