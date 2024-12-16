using game.Core;
using game.Commands;
using game.Data;
using game.Interface;
using game.Services;
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