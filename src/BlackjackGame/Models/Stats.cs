//testing push
namespace BlackjackGame.Models
{
    /// <summary>Aggregates basic statistics for the session.</summary>
    public class Stats
    {
        // e.g., histogram of final hand totals
        public Dictionary<int,int> HandSumDistribution { get; } = new();

        public void RecordHandSum(int sum)
        {
            // TODO: increment counters
            throw new NotImplementedException();
        }
    }
}
