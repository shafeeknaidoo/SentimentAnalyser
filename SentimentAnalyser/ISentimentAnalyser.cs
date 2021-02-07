using System.Collections.Generic;

namespace SentimentAnalyser
{
    /**
     * Interface to enforce the contract required
     */
    public interface ISentimentAnalyser
    {
        /**
         * Checks if the text contains a valid sentiment
         * @return bool
         */
        bool IsWordSentiment(string text);
    }
}