using game.Core;
using game.Commands;
using game.Data;
using game.Interface;
using game.Services;
using game.Models;
using System;

namespace game.Commands
{
    class PlayGameCommand : ICommand
    {
        private readonly GameManager _gameManager;
        private readonly PlayerService _playerService;
        private readonly SessionManager _sessionManager;
        private readonly Random _random;

        public PlayGameCommand(GameManager gameManager, PlayerService playerService, SessionManager sessionManager)
        {
            _gameManager = gameManager;
            _playerService = playerService;
            _sessionManager = sessionManager;
            _random = new Random(); 
        }

        public void Execute()
        {
            if (!_sessionManager.IsLoggedIn())
            {
                Console.WriteLine("No player is logged in. Please log in to play.");
                return;
            }

            BaseAccount currentAccount = _sessionManager.GetCurrentAccount(); 

            var allAccounts = _playerService.ReadAllAccounts();
            var availableOpponents = allAccounts.Where(account => account.UserName != currentAccount.UserName).ToList();

            if (availableOpponents.Count == 0)
            {
                Console.WriteLine("No available opponents to play with.");
                return;
            }

            var randomOpponent = availableOpponents[_random.Next(availableOpponents.Count)];

            Console.WriteLine($"You will play against {randomOpponent.UserName}");

            _gameManager.PlayTicTacToeGame(currentAccount, randomOpponent);
        }

        public string GetDescription()
        {
            return "Play a game with a random opponent";
        }
    }
}
