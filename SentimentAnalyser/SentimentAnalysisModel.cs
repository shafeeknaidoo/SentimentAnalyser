using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SentimentAnalyser
{
    public class SentimentAnalysisModel
    {
        private readonly string _file;

        private readonly ISentimentAnalyser _negativeSentimentAnalyser;

        private readonly ISentimentAnalyser _positiveSentimentAnalyser;

        public SentimentAnalysisModel(string file)
        {
            _file = file;
            _negativeSentimentAnalyser = new NegativeSentimentAnalyser();
            _positiveSentimentAnalyser = new PositiveSentimentAnalyser();
        }

        public string AnalyzeSentiment()
        {
            var statementSentimentCount = new Dictionary<string, int>();
            ReportHelper.InitializeSentimentCounters(statementSentimentCount);

            var statements = File.ReadAllLines(_file);

            foreach (var statement in statements)
            {
                var isNegative = _negativeSentimentAnalyser.IsWordSentiment(statement);
                var isPositive = _positiveSentimentAnalyser.IsWordSentiment(statement);


                if (isNegative == isPositive && isNegative)
                {
                    statementSentimentCount[Constants.NegativeSentimentLabel]++;
                    statementSentimentCount[Constants.PositiveSentimentLabel]++;
                }
                else if(isNegative)
                {
                    statementSentimentCount[Constants.NegativeSentimentLabel]++;
                }
                else if(isPositive)
                {
                    statementSentimentCount[Constants.PositiveSentimentLabel]++;
                }
            }

            var finalSentiment = determineSentiment(statementSentimentCount);

            return finalSentiment;
        }

        /// <summary>
        ///     Determine the final sentiment of the commentary based on the sentiment
        ///     of the individual statements within the commentary
        /// </summary>
        /// <param name="statementSentimentCount">Sentiments for each statement in a file</param>
        /// <returns>Returns the final sentiment</returns>
        private string determineSentiment(Dictionary<string, int> statementSentimentCount)
        {
            var finalSentiment = string.Empty;

            if (statementSentimentCount[Constants.PositiveSentimentLabel] >
                statementSentimentCount[Constants.NegativeSentimentLabel])
            {
                finalSentiment = Constants.PositiveSentimentLabel;
            }
            else if (statementSentimentCount[Constants.PositiveSentimentLabel] <
                     statementSentimentCount[Constants.NegativeSentimentLabel])
            {
                finalSentiment = Constants.NegativeSentimentLabel;
            }
            else
            {
                finalSentiment = Constants.NeutralSentimentLabel;
            }

            return finalSentiment;
        }
    }
}