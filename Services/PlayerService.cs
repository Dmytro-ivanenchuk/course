using game.Core;
using game.Commands;
using game.Data;
using game.Interface;
using game.Services;
using game.Models;

namespace game.Services
{
    class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private BaseAccount _currentAccount; 

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void CreateAccount(BaseAccount player)
        {
            _playerRepository.Create(player);
        }

        public BaseAccount ReadAccountById(string userName)
        {
            return _playerRepository.ReadById(userName);
        }

        public List<BaseAccount> ReadAllAccounts()
        {
            return _playerRepository.ReadAll();
        }

        public BaseAccount GetCurrentAccount()
        {
            return _currentAccount;
        }
    }
}


