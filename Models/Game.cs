namespace game.Models
{
    class Game
    {
        private static int nextGameId = 1;  
        public int GameId { get; private set; }
        public string OpponentName { get; private set; }
        public string PlayerName { get; private set; } 
        public string Result { get; private set; }
        public int Rating { get; private set; }
        public int CurrentRating { get; private set; }
        public string GameType { get; private set; }  

        public Game(string playerName, string opponentName, string result, int rating, int currentRating, string gameType)
        {
            GameId = nextGameId++;  
            PlayerName = playerName;  
            OpponentName = opponentName;
            Result = result;
            Rating = rating;
            CurrentRating = currentRating;
            GameType = gameType;  
        }
    }


}
