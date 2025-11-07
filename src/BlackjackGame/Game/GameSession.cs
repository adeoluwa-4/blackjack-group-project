
using BlackjackGame.Core;
using BlackjackGame.Models;

namespace BlackjackGame.Game
{
    /// <summary>Immutable configuration for a single play session.</summary>
    public class GameSession
    {
        public List<Player> Players { get; }
        public GameMode Mode { get; }
        public int Rounds { get; }

        public GameSession(List<Player> players, GameMode mode, int rounds)
        {
            Players = players;
            Mode = mode;
            Rounds = rounds;
        }
    }
}
