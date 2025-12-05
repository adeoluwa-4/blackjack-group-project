using BlackjackGame.Core;
using BlackjackGame.Models;
using BlackjackGame.Services;

namespace BlackjackGame.Game
{
    /// <summary>
    /// Coordinates game setup, rounds, and scoring.
    /// </summary>
    public class BlackjackEngine
    {
        private readonly HighScoreService _highScoreService;

        public BlackjackEngine(HighScoreService highScoreService)
        {
            _highScoreService = highScoreService;
        }

        /// <summary>
        /// Collects players, selects mode, and starts a session.
        /// </summary>
        public void RunGameSetupAndStart()
        {
            Console.WriteLine("=== Blackjack Setup ===");

            // Get player count (you can swap to Input.ReadIntInRange later)
            Console.Write("Enter number of players: ");
            int count = int.Parse(Console.ReadLine() ?? "1");

            var players = new List<Player>();

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter name for Player {i + 1}: ");
                string name = Console.ReadLine() ?? $"Player{i + 1}";
                players.Add(new Player(name));     // assumes Player(string name)
            }

            // Choose mode
            Console.WriteLine("Choose game mode:");
            Console.WriteLine("1) Versus Dealer");
            Console.WriteLine("2) Free Play");
            Console.Write("Selection: ");
            int modeChoice = int.Parse(Console.ReadLine() ?? "1");

            GameMode mode = modeChoice == 1 ? GameMode.VersusDealer : GameMode.FreePlay;

            // Number of rounds
            Console.Write("How many rounds? ");
            int rounds = int.Parse(Console.ReadLine() ?? "5");

            var dealer = mode == GameMode.VersusDealer ? new Player("Dealer") : null;

            // Your GameSession signature:
            GameSession session = new GameSession(players, dealer, mode, rounds);

            PlaySession(session);
        }

        /// <summary>
        /// Runs N rounds of blackjack.
        /// </summary>
        private void PlaySession(GameSession session)
        {
            Console.WriteLine($"\n=== Starting {session.Rounds} Rounds ===");

            Deck deck = new Deck();
            deck.Shuffle();

            for (int round = 1; round <= session.Rounds; round++)
            {
                Console.WriteLine($"\n--- Round {round} ---");

                // Deal initial cards
                foreach (var p in session.Players)
                {
                    p.Hand = new Hand();
                    p.Hand.Add(deck.Draw());    // CHANGED: Add + Draw
                    p.Hand.Add(deck.Draw());
                }

                if (session.Mode == GameMode.VersusDealer && session.Dealer != null)
                {
                    session.Dealer.Hand = new Hand();
                    session.Dealer.Hand.Add(deck.Draw());   // CHANGED
                    session.Dealer.Hand.Add(deck.Draw());
                }

                // Player turns
                foreach (var p in session.Players)
                {
                    TakeTurn(p, deck, session.Mode);
                }

                // Dealer turn if required
                if (session.Mode == GameMode.VersusDealer && session.Dealer != null)
                {
                    DealerPlay(session.Dealer, deck);
                }

                // Score each player's round (vs dealer)
                if (session.Mode == GameMode.VersusDealer && session.Dealer != null)
                {
                    foreach (var p in session.Players)
                    {
                        int delta = ScoreRound(p, session.Dealer, session.Mode);
                        p.Points += delta;      // assumes Player has Points
                    }
                }

                Console.WriteLine("--- Round Complete ---\n");
            }

            // Save high scores (make sure HighScoreService has this method)
            foreach (var p in session.Players)
                _highScoreService.RecordScore(p.Name, p.Points);

            Console.WriteLine("=== Session Complete ===");
        }

        /// <summary>
        /// Handles a single player's turn.
        /// </summary>
        private void TakeTurn(Player p, Deck deck, GameMode mode)
        {
            Console.WriteLine($"\n{p.Name}'s turn:");
            bool done = false;

            while (!done)
            {
                // CHANGED: use BestValue() and ToString()
                Console.WriteLine($"Hand: {p.Hand}  (Value = {p.Hand.BestValue()})");

                if (p.Hand.IsBust)
                {
                    Console.WriteLine("BUST!");
                    return;
                }

                Console.Write("Hit (H) or Stand (S)? ");
                string input = Console.ReadLine()?.Trim().ToUpper() ?? "S";

                if (input == "H")
                {
                    p.Hand.Add(deck.Draw());   // CHANGED
                }
                else
                {
                    done = true;
                }
            }
        }

        /// <summary>
        /// Dealer hits until hand >= 17.
        /// </summary>
        private void DealerPlay(Player dealer, Deck deck)
        {
            Console.WriteLine("\nDealer's turn...");

            // CHANGED: use BestValue()
            while (dealer.Hand.BestValue() < 17)
            {
                dealer.Hand.Add(deck.Draw());
            }

            Console.WriteLine(
                $"Dealer final hand: {dealer.Hand} (Value = {dealer.Hand.BestValue()})"
            );
        }

        /// <summary>
        /// Scores the round for one player.
        /// </summary>
        private int ScoreRound(Player p, Player dealer, GameMode mode)
        {
            int playerValue = p.Hand.BestValue();   // CHANGED
            int dealerValue = dealer.Hand.BestValue();

            // Use GameRules to determine win/loss
            RoundOutcome result = GameRules.DetermineOutcome(playerValue, dealerValue);

            switch (result)
            {
                case RoundOutcome.Win:
                    p.Wins++;
                    Console.WriteLine($"{p.Name} wins the round!");
                    return +1;

                case RoundOutcome.Loss:
                    p.Losses++;
                    Console.WriteLine($"{p.Name} loses the round.");
                    return -1;

                default:
                    Console.WriteLine($"{p.Name} pushes the round.");
                    return 0;
            }
        }
    }
}
