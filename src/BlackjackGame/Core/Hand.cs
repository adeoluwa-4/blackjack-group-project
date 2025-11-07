
namespace BlackjackGame.Core
{
    /// <summary>Represents the cards a player holds and computes best 21 value.</summary>
    public class Hand
    {
        // TODO: private readonly List<Card> _cards = new();

        /// <summary>Adds a card to the hand.</summary>
        public void Add(Card c)
        {
            // TODO: append
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the highest total <= 21, treating some Aces as 1 if needed; otherwise the minimal bust value.
        /// </summary>
        public int BestValue()
        {
            // TODO: sum; downgrade Ace(s) by 10 as needed
            throw new NotImplementedException();
        }

        /// <summary>True when hand has exactly two cards totaling 21.</summary>
        public bool IsBlackjack
        {
            get
            {
                // TODO: implement
                throw new NotImplementedException();
            }
        }

        /// <summary>True when BestValue() > 21.</summary>
        public bool IsBust => throw new NotImplementedException();

        public override string ToString()
        {
            // TODO: Comma-join cards and append total
            throw new NotImplementedException();
        }
    }
}
