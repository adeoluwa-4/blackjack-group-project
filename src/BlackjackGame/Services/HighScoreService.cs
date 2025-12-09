using System;
using System.IO;
using System.Text.Json;

namespace BlackjackGame.Services
{
    /// <summary>
    /// Represents a high score entry (name + points).
    /// </summary>
    public class HighScoreEntry
    {
        /// <summary>
        /// Player's name or username.
        /// </summary>
        public string PlayerName { get; set; } = string.Empty;

        /// <summary>
        /// High score point value.
        /// </summary>
        public int Points { get; set; }
    }

    /// <summary>
    /// Handles loading and saving the global high score to a JSON file.
    /// </summary>
    public class HighScoreService
    {
        private readonly string _dataDirectory;
        private readonly string _filePath;

        public HighScoreService()
        {
            // Store file under a "Data" folder next to the executable.
            _dataDirectory = Path.Combine(AppContext.BaseDirectory, "Data");
            _filePath = Path.Combine(_dataDirectory, "HighScore.json");
        }

        /// <summary>
        /// Ensures that the Data folder exists.
        /// </summary>
        private void EnsureDataDirectory()
        {
            if (!Directory.Exists(_dataDirectory))
            {
                Directory.CreateDirectory(_dataDirectory);
            }
        }

        /// <summary>
        /// Saves the given high score entry to a JSON file.
        /// </summary>
        public void SaveHighScore(HighScoreEntry entry)
        {
            EnsureDataDirectory();

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(entry, options);
            File.WriteAllText(_filePath, json);
        }

        /// <summary>
        /// Loads the current high score from the JSON file, or null if none exists.
        /// </summary>
        public HighScoreEntry? LoadHighScore()
        {
            EnsureDataDirectory();

            if (!File.Exists(_filePath))
            {
                return null;
            }

            string json = File.ReadAllText(_filePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                return null;
            }

            return JsonSerializer.Deserialize<HighScoreEntry>(json);
        }

        /// <summary>
        /// Compares the given score against the stored high score
        /// and updates the JSON file if this is a new high score.
        /// </summary>
        /// <param name="playerName">Name/username of the player.</param>
        /// <param name="points">Points earned in the session.</param>
        public void RecordScore(string playerName, int points)
        {
            var current = LoadHighScore();

            if (current == null || points > current.Points)
            {
                var newHigh = new HighScoreEntry
                {
                    PlayerName = playerName,
                    Points = points
                };

                SaveHighScore(newHigh);

                Console.WriteLine($"New high score! {playerName} with {points} points.");
            }
        }
    }
}
