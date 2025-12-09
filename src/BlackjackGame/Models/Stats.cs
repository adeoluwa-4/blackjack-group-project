using System.Collections.Generic;

namespace BlackjackGame.Models
{
    /// <summary>
    /// Tracks statistics for a player or game session.
    /// </summary>
    public class Stats
    {
        /// <summary>
        /// Total number of rounds won.
        /// </summary>
        public int Wins { get; set; }

        /// <summary>
        /// Total number of  rounds lost.
        /// </summary>
        public int Losses { get; set; }

        /// <summary>
        /// Number of times a natural blackjack (21 with two cards) occurred.
        /// </summary>
        public int BlackjackCount { get; set; }

        /// <summary>
        /// Tracks how many times each final hand value has occurred.
        /// Key = final hand value (e.g., 17, 18, 19, 20, 21, or bust value).
        /// Value = number of times that value was seen.
        /// </summary>
        public Dictionary<int, int> HandValueDistribution { get; } = new();

        /// <summary>
        /// Records the result of a single hand into the stats.
        /// </summary>
        /// <param name="finalValue">The final hand value at the end of the round.</param>
        /// <param name="isWin">True if the round was a win for this player.</param>
        /// <param name="isBlackjack">True if the hand was a natural blackjack.</param>
        public void RecordHand(int finalValue, bool isWin, bool isBlackjack)
        {
            if (isWin)
            {
                Wins++;
            }
            else
            {
                Losses++;
            }

            if (isBlackjack)
            {
                BlackjackCount++;
            }

            if (HandValueDistribution.ContainsKey(finalValue))
            {
                HandValueDistribution[finalValue]++;
            }
            else
            {
                HandValueDistribution[finalValue] = 1;
            }
        }
    }
}
