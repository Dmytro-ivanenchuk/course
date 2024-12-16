using game.Core;
using game.Commands;
using game.Data;
using game.Interface;
using game.Services;
using game.Models;

namespace game.Data
{
    interface IGameRepository
    {
        void Create(Game game);
        Game ReadById(int gameId);
        List<Game> ReadAll();
        List<Game> ReadByPlayer(string playerName);
    }


    class GameRepository : IGameRepository
    {
        private readonly DbContext _dbContext;

        public GameRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Game game)
        {
            _dbContext.Games.Add(game);
        }

        public Game ReadById(int gameId)
        {
            foreach (var game in _dbContext.Games)
            {
                if (game.GameId == gameId)
                {
                    return game;
                }
            }
            return null; 
        }

        public List<Game> ReadAll()
        {
            return _dbContext.Games;
        }

        public List<Game> ReadByPlayer(string playerName)
        {
            List<Game> gamesForPlayer = new List<Game>();
            
            foreach (var game in _dbContext.Games)
            {
                if (game.OpponentName == playerName)
                {
                    gamesForPlayer.Add(game);
                }
            }
            return gamesForPlayer;
        }
    }
}

