using game.Core;
using game.Commands;
using game.Data;
using game.Interface;
using game.Services;
using game.Models;

namespace game.Data
{
    interface IPlayerRepository
    {
        void Create(BaseAccount player);
        BaseAccount ReadById(string userName);
        List<BaseAccount> ReadAll();
        void Update(BaseAccount player);
        void Delete(string userName);
    }

    class PlayerRepository : IPlayerRepository
    {
        private readonly DbContext _dbContext;

        public PlayerRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(BaseAccount player)
        {
            _dbContext.Players.Add(player);
        }

        public BaseAccount ReadById(string userName)
        {

            foreach (var player in _dbContext.Players)
            {
                if (player.UserName == userName)
                {
                    return player;
                }
            }
            return null; 
        }

        public List<BaseAccount> ReadAll()
        {
            return _dbContext.Players;
        }

        public void Update(BaseAccount player)
        {
            var existingPlayer = ReadById(player.UserName);
            if (existingPlayer != null)
            {
                _dbContext.Players.Remove(existingPlayer);
                _dbContext.Players.Add(player);
            }
        }

        public void Delete(string userName)
        {
            var player = ReadById(userName);
            if (player != null)
            {
                _dbContext.Players.Remove(player);
            }
        }
    }
}

