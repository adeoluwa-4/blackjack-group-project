
using BlackjackGame.Core;

namespace BlackjackGame.Models
{
    /// <summary>Represents a participant at the table.</summary>
    public class Player
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Username { get; }
        public int TotalPoints { get; set; }
        public Hand Hand { get; set; } = new();

        // Session stats
        public int HandsPlayed { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Busts { get; set; }
        public int Blackjacks { get; set; }
        public int LongestTurnCardCount { get; set; }
        public int CardsTakenThisHand { get; set; }

        public Player(string first, string last, string username)
        {
            FirstName = first;
            LastName = last;
            Username = username;
        }

        public string DisplayName => $"{FirstName} {LastName} ({Username})";
    }
}
