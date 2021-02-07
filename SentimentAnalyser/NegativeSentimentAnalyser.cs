using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SentimentAnalyser
{
    public class NegativeSentimentAnalyser : AbstractSentimentAnalyser, ISentimentAnalyser
    {
        private readonly Dictionary<string, int> _words;

        public NegativeSentimentAnalyser()
        {
            _words = GetSentimentWords();
        }
        
        public NegativeSentimentAnalyser(Dictionary<string,int> words)
        {
            _words = words;
        }

        public Dictionary<string, int> GetSentimentWords()
        {
            var words = new Dictionary<string, int>();
            words.Add("sad", 1);
            words.Add("unhapp", 1);
            words.Add("complain", 1);
            words.Add("\\?", 2);

            return words;
        }

        public bool IsWordSentiment(string text)
        {
            return IsSentiment(text, _words) || IsComplaintViaEmail(text);
        }

        private bool IsComplaintViaEmail(string text)
        {
            var words = new Dictionary<string, int>();
            words.Add("complain", 1);

            var reg = new Regex(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}", RegexOptions.IgnoreCase);
            var match = reg.Match(text);

            return match.Success && IsSentiment(text,words);
        }
    }
}