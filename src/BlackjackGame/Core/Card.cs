// Sage Woods
namespace BlackjackGame.Core
{
    /// <summary>Immutable representation of a card.</summary>
    public readonly struct Card
    {
        public Suit Suit { get; }
        public string Face { get; } // "2".."10","J","Q","K","A"
        public int Value { get; }   // base value (A handled in Hand)

        /// <summary>Create a card.</summary>
        public Card(Suit suit, string face, int value)
        {
            Suit = suit;
            Face = face;
            Value = value;
        }

        public override string ToString() => $"{Face} of {Suit}";
    }
}
