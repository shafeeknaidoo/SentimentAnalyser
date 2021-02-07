using System.Collections.Generic;
using NUnit.Framework;

namespace SentimentAnalyser.Test
{
    public class AnalyserTest
    {
        private ISentimentAnalyser _negativeSentimentAnalyser;

        private ISentimentAnalyser _positiveSentimentAnalyser;

        [Test]
        public void TestUnhappy()
        {
            var words = new Dictionary<string, int>();
            words.Add("unhapp", 1);

            _negativeSentimentAnalyser = new NegativeSentimentAnalyser(words);

            var text = "In essence, the complainant unhappily submitted that the advertisement is misleading.";

            Assert.IsTrue(_negativeSentimentAnalyser.IsWordSentiment(text));
        }

        [Test]
        public void TestComplain()
        {
            var words = new Dictionary<string, int>();
            words.Add("COMPLAIN", 1);

            _negativeSentimentAnalyser = new NegativeSentimentAnalyser(words);

            var text = "In essence, the complainant unhappily submitted that the advertisement is misleading.";

            Assert.IsTrue(_negativeSentimentAnalyser.IsWordSentiment(text));
        }

        [Test]
        public void TestSad()
        {
            var words = new Dictionary<string, int>();
            words.Add("Sadly", 1);

            _negativeSentimentAnalyser = new NegativeSentimentAnalyser(words);

            var text = "In essence, the ad was sadly misleading.";

            Assert.IsTrue(_negativeSentimentAnalyser.IsWordSentiment(text));
        }

        [Test]
        public void TestQuestionMarks()
        {
            var words = new Dictionary<string, int>();
            words.Add("\\?", 2);

            _negativeSentimentAnalyser = new NegativeSentimentAnalyser(words);

            var text = "A similar aspect can be applied to the matter at hand? Under which circumstances?";

            Assert.IsTrue(_negativeSentimentAnalyser.IsWordSentiment(text));
        }

        [Test]
        public void TestComplaintViaEmail()
        {
            var words = new Dictionary<string, int>();
            words.Add("complain", 1);

            _negativeSentimentAnalyser = new NegativeSentimentAnalyser(words);

            var text =
                "The respondent provided his email address john@notunilever.com that Ms Watkins could use to send any complaints to.";

            Assert.IsTrue(_negativeSentimentAnalyser.IsWordSentiment(text));
        }

        [Test]
        public void TestNonNegative()
        {
            var words = new Dictionary<string, int>();
            words.Add("happy", 2);

            _negativeSentimentAnalyser = new NegativeSentimentAnalyser(words);

            var text =
                "The ASA Directorate was happy to considered the relevant documentation submitted by the respective parties.";

            Assert.IsFalse(_negativeSentimentAnalyser.IsWordSentiment(text));
        }

        [Test]
        public void TestHappy()
        {
            var words = new Dictionary<string, int>();
            words.Add("happy", 1);

            _positiveSentimentAnalyser = new PositiveSentimentAnalyser(words);

            var text =
                "The ASA Directorate was happy to considered the relevant documentation submitted by the respective parties.";

            Assert.IsTrue(_positiveSentimentAnalyser.IsWordSentiment(text));
        }

        [Test]
        public void TestExclamationPoint()
        {
            var words = new Dictionary<string, int>();
            words.Add("\\!", 1);

            _positiveSentimentAnalyser = new PositiveSentimentAnalyser(words);

            var text =
                "Unilever lodged a competitor complaint against the respondent’s packaging of its Royco soup!";

            Assert.IsTrue(_positiveSentimentAnalyser.IsWordSentiment(text));
        }

        [Test]
        public void TestNegativeHappy()
        {
            var words = new Dictionary<string, int>();
            words.Add("complain", 1);

            _positiveSentimentAnalyser = new PositiveSentimentAnalyser(words);

            var text = "In essence, the ad was sadly misleading.";

            Assert.IsFalse(_positiveSentimentAnalyser.IsWordSentiment(text));
        }
    }
}