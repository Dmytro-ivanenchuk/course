using game.Models;

namespace game.Interface
{
    interface IGameService
    {
        void RecordGame(Game game);
        List<Game> GetAllGames();
        List<Game> GetPlayerGames(string playerName);
    }
}