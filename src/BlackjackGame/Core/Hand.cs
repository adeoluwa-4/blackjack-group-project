using System.Collections.Generic;
using System.Linq;

namespace BlackjackGame.Core
{
    /// <summary>
    /// Represents the cards a player holds and computes the best 21 value.
    /// </summary>
    public class Hand
    {
        private readonly List<Card> _cards = new();

        /// <summary>
        /// Read-only view of the cards in this hand.
        /// </summary>
        public IReadOnlyList<Card> Cards => _cards;

        /// <summary>
        /// Adds a card to the hand.
        /// </summary>
        public void Add(Card c)
        {
            _cards.Add(c);
        }

        /// <summary>
        /// Returns the highest total ≤ 21 by treating some Aces as 1 instead of 11.
        /// If all totals are > 21, returns the minimal bust value.
        /// </summary>
        public int BestValue()
        {
            if (_cards.Count == 0)
                return 0;

            int total = _cards.Sum(c => c.Value);
            int aceCount = _cards.Count(c => c.Face == "A");

            // Downgrade Aces from 11 → 1 as needed to avoid bust
            while (total > 21 && aceCount > 0)
            {
                total -= 10; // each Ace downgraded reduces total by 10
                aceCount--;
            }

            return total;
        }

        /// <summary>
        /// True when the hand has exactly two cards and totals 21.
        /// </summary>
        public bool IsBlackjack => _cards.Count == 2 && BestValue() == 21;

        /// <summary>
        /// True when the best value of the hand exceeds 21.
        /// </summary>
        public bool IsBust => BestValue() > 21;

        public override string ToString()
        {
            var cardsText = string.Join(", ", _cards.Select(c => c.ToString()));
            return $"{cardsText} (Total: {BestValue()})";
        }
    }
}
