using game.Core;
using game.Commands;
using game.Data;
using game.Interface;
using game.Services;
using game.Models;

namespace game.Data
{
    class DbContext
    {
        public List<BaseAccount> Players { get; private set; }
        public List<Game> Games { get; private set; }

        public DbContext()
        {
            Players = new List<BaseAccount>();
            Games = new List<Game>();
        }
    }
}
