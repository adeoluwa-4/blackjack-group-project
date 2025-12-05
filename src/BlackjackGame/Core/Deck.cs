using System;
using System.Collections.Generic;

namespace BlackjackGame.Core
{
    /// <summary>
    /// Represents one or more standard 52-card decks, shuffled.
    /// </summary>
    public class Deck
    {
        private readonly Stack<Card> _cards = new();

        /// <summary>
        /// Creates a new deck containing <paramref name="decks"/> shuffled 52-card decks.
        /// </summary>
        /// <param name="decks">Number of standard decks to include.</param>
        public Deck(int decks = 1)
        {
            if (decks <= 0)
                throw new ArgumentOutOfRangeException(nameof(decks), "Number of decks must be at least 1.");

            // Define faces and base values
            var faces = new (string Face, int Value)[]
            {
                ("2", 2), ("3", 3), ("4", 4), ("5", 5), ("6", 6),
                ("7", 7), ("8", 8), ("9", 9), ("10", 10),
                ("J", 10), ("Q", 10), ("K", 10), ("A", 11)
            };

            // Build raw list first
            var temp = new List<Card>();

            for (int d = 0; d < decks; d++)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    foreach (var f in faces)
                    {
                        temp.Add(new Card(suit, f.Face, f.Value));
                    }
                }
            }

            // Shuffle temp into the stack
            ShuffleListInPlace(temp);
            foreach (var card in temp)
            {
                _cards.Push(card);
            }
        }

        /// <summary>
        /// Randomizes the order of cards remaining in the deck.
        /// </summary>
        public void Shuffle()
        {
            var list = new List<Card>(_cards);
            _cards.Clear();

            ShuffleListInPlace(list);

            foreach (var card in list)
            {
                _cards.Push(card);
            }
        }

        /// <summary>
        /// Draws the next card from the top of the deck.
        /// Throws if the deck is empty.
        /// </summary>
        public Card Draw()
        {
            if (_cards.Count == 0)
                throw new InvalidOperationException("Cannot draw from an empty deck.");

            return _cards.Pop();
        }

        /// <summary>
        /// Number of cards remaining in the deck.
        /// </summary>
        public int Count => _cards.Count;

        /// <summary>
        /// Fisher–Yates shuffle of a list, in place.
        /// </summary>
        private static void ShuffleListInPlace(List<Card> list)
        {
            var rng = new Random();
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }
}
