using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SentimentAnalyser
{
    /**
     * Abstract class that implements functionality to check if a dictionary of words are present in the text
     */
    public abstract class AbstractSentimentAnalyser
    {
        /**
         * Checks if the sentiment exists
         * @param string text, text to search
         * @param Dict<string,int> dictionary of word or characters to consider and the occurences to account for
         * @return bool
         */
        protected bool IsSentiment(string text, IDictionary<string, int> words)
        {
            foreach (var word in words)
            {
                if (Regex.Matches(text, @"\b" + word.Key, RegexOptions.IgnoreCase).Count >= word.Value)
                {
                    return true;
                }
            }

            return false;
        }
    }
}