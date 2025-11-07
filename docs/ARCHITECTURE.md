
# ARCHITECTURE

## Layers
- **Core**: cards, deck, hand math — no console I/O here.
- **Models**: player & stats state containers.
- **Game**: engine, session, input, rules — orchestrates gameplay & I/O.
- **Services**: file I/O (high scores), analytics, etc.

## Data Flow (happy path)
Program ➜ BlackjackEngine.RunGameSetupAndStart()
  ➜ GameSession(players, mode, rounds)
  ➜ PlaySession(session)
      ➜ Deal / TakeTurn(players)
      ➜ (VersusDealer) DealerPlay()
      ➜ ScoreRound() ➜ HighScoreService

## Persistence
- `Data/highscores.json` tracks the **best** score ever.
- Use *relative paths* so it runs on any machine.
