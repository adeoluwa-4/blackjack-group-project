
# METHOD SPEC

### Core.Deck
- **Deck(int decks=1)**: Generate (52 * decks) cards and shuffle.
- **void Shuffle()**: Fisher–Yates shuffle for uniform randomness.
- **Card Draw()**: Remove and return the top card; error if empty.
- **int Count { get; }**: Remaining cards.

### Core.Hand
- **void Add(Card c)**: Append card.
- **int BestValue()**: Sum values; downgrade Ace(s) to 1 as needed to keep ≤ 21.
- **bool IsBlackjack { get; }**: Exactly 2 cards and BestValue()==21.
- **bool IsBust { get; }**: BestValue() > 21.

### Game.Input
- **string ReadNonEmpty(prompt)**: Loop until non-empty input.
- **int ReadIntInRange(prompt, min, max)**: Loop until valid int within range.
- **bool ReadYesNo(prompt)**: Accept y/yes, n/no.
- **void Wait(message)**: Console pause.

### Game.GameRules
- Constants for scoring (points, not money).
- **ShowRules()**: Write quick rules to console.

### Game.BlackjackEngine
- **RunGameSetupAndStart()**: Ask for players/mode/rounds then PlaySession().
- **PlaySession(GameSession)**: Main round loop — deal, turns, dealer, scoring.
- **TakeTurn(Player, Deck, GameMode)**: Hit/Stand/Double loop; update stats.
- **DealerPlay(Player, Deck)**: Dealer hits until 17+.
- **ScoreRound(Player, Player dealer, GameMode)**:
  - If bust: penalty.
  - VersusDealer: +5 beat dealer; +1 push; update W/L.
  - HeadToHead: award +7 to winner, +1 ties (design choice).

### Services.HighScoreService
- **GetHighScore()**: Return best (name, score) or null.
- **SaveHighScore(name, score)**: Append then persist.
