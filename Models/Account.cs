using game.Core;
using game.Commands;
using game.Data;
using game.Interface;
using game.Services;
using game.Models;

namespace game.Models
{
    abstract class BaseAccount
    {
        public string UserName { get; private set; }
        private string Password { get; set; }  
        protected int Rating = 1;
        public int CurrentRating
        {
            get { return Rating; }
            set { Rating = Math.Max(1, value); }
        }
        public int GamesCount { get { return gameHistory.Count; } }
        private List<Game> gameHistory;

        public BaseAccount(string userName, string password)
        {
            UserName = userName;
            Password = password;  
            CurrentRating = 1;
            gameHistory = new List<Game>();
        }

        public bool VerifyPassword(string password)
        {
            return Password == password;  
        }

        public abstract void WinGame(BaseGame game, string opponentName);
        public abstract void LoseGame(BaseGame game, string opponentName);
        public abstract void DrawGame(BaseGame game, string opponentName);

        public void GetStats()
        {
            Console.WriteLine();
            Console.WriteLine($"Player: {UserName}, Current Rating: {CurrentRating}, Games Played: {GamesCount}");
            if(GamesCount > 0)
            {
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("Index | Opponent     | Result | Rating | Current | GameId | Game Type");
                Console.WriteLine("---------------------------------------------------------------------");
            }

            for (int i = 0; i < gameHistory.Count; i++)
            {
                Game game = gameHistory[i];
                Console.WriteLine($"{i + 1,-5} | {game.OpponentName,-12} | {game.Result,-6} | {game.Rating,-6} | {game.CurrentRating, -7} | {game.GameId, -6} | {game.GameType}");
            }       
        }

        protected void RecordGame(string opponentName, string result, int rating, string gameType)
        {
            gameHistory.Add(new Game(UserName, opponentName, result, rating, CurrentRating, gameType));
        }
    }
}
