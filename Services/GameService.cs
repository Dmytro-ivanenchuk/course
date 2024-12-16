using game.Core;
using game.Commands;
using game.Data;
using game.Interface;
using game.Services;
using game.Models;

namespace game.Services
{
    class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void RecordGame(Game game)
        {
            _gameRepository.Create(game);
        }

        public List<Game> GetAllGames()
        {
            return _gameRepository.ReadAll();
        }

        public List<Game> GetPlayerGames(string playerName)
        {
            return _gameRepository.ReadByPlayer(playerName);
        }
    }
}
