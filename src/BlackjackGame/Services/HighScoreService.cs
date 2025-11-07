
namespace BlackjackGame.Services
{
    /// <summary>
    /// Persists and retrieves the global high score.
    /// This stub uses a JSON file (Data/highscores.json) with the best score.
    /// </summary>
    public class HighScoreService
    {
        private readonly string _path;

        public HighScoreService()
        {
            // TODO: build path relative to AppContext.BaseDirectory/Data/highscores.json
            _path = "Data/highscores.json";
        }

        public (string Name, int Score)? GetHighScore()
        {
            // TODO: read file if exists; parse JSON; return best or null
            throw new NotImplementedException();
        }

        public void SaveHighScore(string name, int score)
        {
            // TODO: append to list; overwrite JSON file
            throw new NotImplementedException();
        }
    }
}
