using game.Core;
using game.Commands;
using game.Data;
using game.Interface;
using game.Services;

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

        public IEnumerable<Game> GetGameHistory()
        {
            return gameHistory.AsReadOnly();
        }

        protected void RecordGame(string opponentName, string result, int rating, string gameType)
        {
            gameHistory.Add(new Game(UserName, opponentName, result, rating, CurrentRating, gameType));
        }
    }
}
