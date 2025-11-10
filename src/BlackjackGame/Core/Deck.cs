// hi 
// hello
namespace BlackjackGame.Core
{
    /// <summary>Represents one or more shuffled decks.</summary>
    public class Deck
    {
        // TODO: choose container (Stack or List)
        // private readonly Stack<Card> _cards = new();

        public Deck(int decks = 1)
        {
            // TODO: Generate standard 52 * decks cards.
            // TODO: Shuffle using Fisher–Yates.
            throw new NotImplementedException();
        }

        /// <summary>Randomizes _cards in place.</summary>
        public void Shuffle()
        {
            // TODO: Implement Fisher–Yates shuffle.
            throw new NotImplementedException();
        }

        /// <summary>Draws the next card.</summary>
        public Card Draw()
        {
            // TODO: Pop from container; if empty, throw.
            throw new NotImplementedException();
        }

        /// <summary>Number of cards remaining.</summary>
        public int Count
        {
            get
            {
                // TODO: return _cards.Count;
                throw new NotImplementedException();
            }
        }
    }
}
