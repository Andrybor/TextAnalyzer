using System.Linq;
using TextAnalyzer.Services.Interfaces;

namespace TextAnalyzer.Services.Implementations
{
    public class FrequentSymbolsMetric : IMetric
    {
        public FrequentSymbolsMetric()
        {
            Name = "Frequent symbol";
        }

        public string Name { get; set; }

        /// <summary>
        /// analyze how each symbol frequent repeat
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        string IMetric.Analyze(string text)
        {
            string result = string.Empty;

            var dictionary = text.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            foreach (var item in dictionary)
            {
                result += "Symbol - " + "(" + item.Key + ") " + "frequent : " + "(" + item.Value + ") ";
            }
            return result;
        }
    }
}
