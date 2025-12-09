using System;

namespace BlackjackGame.Game
{
    /// <summary>
    /// Indicates the result of a single round for a player.
    /// </summary>
    public enum RoundOutcome
    {
        Win,
        Loss,
        Push
    }

    /// <summary>
    /// Central place for tweakable scoring and options.
    /// </summary>
    public static class GameRules
    {
        public const int PointsForBlackjack = 15;
        public const int PointsForBeatingDealer = 5;
        public const int PointsForWinHeadToHead = 7;
        public const int PointsForPush = 1;
        public const int BustPenalty = -2;

        /// <summary>
        /// Writes quick rules to the console.
        /// </summary>
        public static void ShowRules()
        {
            Console.WriteLine("========== Venetian Blackjack Rules ==========");
            Console.WriteLine("1. Try to get as close to 21 as possible without going over.");
            Console.WriteLine("2. Number cards are worth their face value.");
            Console.WriteLine("3. Face cards (J, Q, K) are worth 10.");
            Console.WriteLine("4. Aces are worth 1 or 11.");
            Console.WriteLine("5. Each player starts with two cards.");
            Console.WriteLine("6. You may choose to Hit or Stand on your turn.");
            Console.WriteLine("7. The dealer must hit until reaching at least 17.");
            Console.WriteLine("8. If you go over 21, you bust and lose the round.");
            Console.WriteLine();
            Console.WriteLine("========== Scoring ==========");
            Console.WriteLine($"Blackjack Bonus: {PointsForBlackjack} points");
            Console.WriteLine($"Beat the Dealer: {PointsForBeatingDealer} points");
            Console.WriteLine($"Win Head-to-Head: {PointsForWinHeadToHead} points");
            Console.WriteLine($"Push (Tie): {PointsForPush} point");
            Console.WriteLine($"Bust Penalty: {BustPenalty} points");
            Console.WriteLine("==============================================");
            Console.WriteLine();
        }

        // Helper Message Methods

        public static void ShowPlayerTurn(string name)
        {
            Console.WriteLine($"\n{name}'s turn...");
        }

        public static void ShowDealerTurn()
        {
            Console.WriteLine("\nDealer's turn...");
        }

        public static void ShowHitOrStand()
        {
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1 - Hit");
            Console.WriteLine("2 - Stand");
        }

        public static void ShowBustMessage()
        {
            Console.WriteLine("Bust! You went over 21.");
        }

        public static void ShowBlackjackMessage()
        {
            Console.WriteLine("Blackjack! You hit 21!");
        }

        public static void ShowWinMessage()
        {
            Console.WriteLine("You win this round!");
        }

        public static void ShowLoseMessage()
        {
            Console.WriteLine("You lost this round.");
        }

        public static void ShowPushMessage()
        {
            Console.WriteLine("Push! It's a tie.");
        }

        /// <summary>
        /// Determines the outcome of a round given player and dealer totals.
        /// </summary>
        public static RoundOutcome DetermineOutcome(int playerValue, int dealerValue)
        {
            // Both bust -> treat as push
            if (playerValue > 21 && dealerValue > 21)
                return RoundOutcome.Push;

            // Player busts only
            if (playerValue > 21)
                return RoundOutcome.Loss;

            // Dealer busts only
            if (dealerValue > 21)
                return RoundOutcome.Win;

            // Neither busts: compare values
            if (playerValue > dealerValue)
                return RoundOutcome.Win;

            if (playerValue < dealerValue)
                return RoundOutcome.Loss;

            // Same value
            return RoundOutcome.Push;
        }
    }
}
