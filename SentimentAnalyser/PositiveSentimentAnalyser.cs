using System.Collections.Generic;

namespace SentimentAnalyser
{
    public class PositiveSentimentAnalyser : AbstractSentimentAnalyser, ISentimentAnalyser
    {
        private readonly Dictionary<string, int> _words;

        public PositiveSentimentAnalyser()
        {
            _words = GetSentimentWords();
        }

        public PositiveSentimentAnalyser(Dictionary<string, int> words)
        {
            _words = words;
        }

        public override Dictionary<string, int> GetSentimentWords()
        {
            var words = new Dictionary<string, int>();
            words.Add("happ", 1);
            words.Add("\\!", 1);

            return words;
        }

        public bool IsWordSentiment(string text)
        {
            return IsSentiment(text, _words);
        }
    }
}