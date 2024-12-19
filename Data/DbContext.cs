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
