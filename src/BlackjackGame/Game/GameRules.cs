
namespace BlackjackGame.Game
{
    /// <summary>Central place for tweakable scoring and options.</summary>
    public static class GameRules
    {
        public const int PointsForBlackjack = 15;
        public const int PointsForBeatingDealer = 5;
        public const int PointsForWinHeadToHead = 7;
        public const int PointsForPush = 1;
        public const int BustPenalty = -2;

        /// <summary>Writes quick rules to the console.</summary>
        public static void ShowRules()
        {
            // TODO: Console.WriteLine summary
            throw new NotImplementedException();
        }
    }
}
