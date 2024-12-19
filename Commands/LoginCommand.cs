using game.Core;
using game.Interface;
using game.Services;
using game.Models;

namespace game.Commands
{
    class LoginCommand : ICommand
    {
        private readonly PlayerService _playerService;
        private readonly SessionManager _sessionManager;

        public LoginCommand(PlayerService playerService, SessionManager sessionManager)
        {
            _playerService = playerService;
            _sessionManager = sessionManager;
        }

        public void Execute()
        {
            Console.WriteLine("== Logginig in ==");
            Console.Write("Enter your username: ");
            string userName = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            BaseAccount account = _playerService.ReadAccountById(userName);

            if (account != null && account.VerifyPassword(password))
            {
                _sessionManager.Login(account);
                Console.WriteLine($"Successfully logged in as {userName}.");
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        public string GetDescription()
        {
            return "Login";
        }
    }
}
