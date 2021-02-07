using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SentimentAnalyser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var finalReport = new Dictionary<string, int>();
            ReportHelper.InitializeSentimentCounters(finalReport);

            var files = new List<string>(Directory.EnumerateFiles("commentary"));

            Parallel.ForEach(files, file =>
            {
                var model = new SentimentAnalysisModel(file);
                var sentiment = model.AnalyzeSentiment();

                UpdateReportResults(finalReport, sentiment);
            });

            Console.WriteLine("Final Report\n=============");
            foreach (var analytic in finalReport)
            {
                Console.WriteLine($"{analytic.Key} : {analytic.Value}");
            }
            Console.ReadLine();
        }

        private static void UpdateReportResults(Dictionary<string, int> finalReport, string sentiment)
        {
            finalReport[sentiment] = finalReport[sentiment] + 1;
        }
    }
}