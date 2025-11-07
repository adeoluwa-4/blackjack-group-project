
using BlackjackGame.Core;
using BlackjackGame.Models;
using BlackjackGame.Services;

namespace BlackjackGame.Game
{
    /// <summary>Coordinates game setup, rounds, and scoring.</summary>
    public class BlackjackEngine
    {
        private readonly HighScoreService _highScoreService;

        public BlackjackEngine(HighScoreService highScoreService)
        {
            _highScoreService = highScoreService;
        }

        /// <summary>Collects players, selects mode, and starts a session.</summary>
        public void RunGameSetupAndStart()
        {
            // TODO: prompt for players, mode, rounds; create GameSession; call PlaySession
            throw new NotImplementedException();
        }

        /// <summary>Plays N rounds per session.</summary>
        private void PlaySession(GameSession session)
        {
            // TODO: deal, player turns, optional dealer play, scoring, round summary
            throw new NotImplementedException();
        }

        /// <summary>Handles a single player's turn loop.</summary>
        private void TakeTurn(Player p, Deck deck, GameMode mode)
        {
            // TODO: show hand; hit/stand/double; track stats
            throw new NotImplementedException();
        }

        /// <summary>Dealer hits to 17+ in VersusDealer mode.</summary>
        private void DealerPlay(Player dealer, Deck deck)
        {
            // TODO
            throw new NotImplementedException();
        }

        /// <summary>Computes points delta for a player's round.</summary>
        private int ScoreRound(Player p, Player dealer, GameMode mode)
        {
            // TODO: use GameRules; update Wins/Losses; return delta
            throw new NotImplementedException();
        }
    }
}
