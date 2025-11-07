
using BlackjackGame.Game;
using BlackjackGame.Services;

namespace BlackjackGame;

internal class Program
{
    /// <summary>
    /// Entrypoint. Wires services and shows a simple main menu.
    /// </summary>
    private static void Main(string[] args)
    {
        var highScoreService = new HighScoreService(); // stubbed
        var engine = new BlackjackEngine(highScoreService); // stubbed

        Console.WriteLine("=== Blackjack (Points Edition) — Spec Starter ===");
        Console.WriteLine("This starter has method stubs & docs only. Implement TODOs per docs/TASKS.md");
    }
}
