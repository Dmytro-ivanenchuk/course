using game.Core;
using game.Commands;
using game.Data;
using game.Interface;
using game.Services;
using game.Models;

namespace game.Commands
{
    class CreateAccountCommand : ICommand
    {
        private readonly PlayerService _playerService;

        public CreateAccountCommand(PlayerService playerService)
        {
            _playerService = playerService;
        }

        public void Execute()
        {
            Console.WriteLine("  == Creating a New Account == ");

            string userName;
            do
            {
                Console.Write("Enter username: ");
                userName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userName) || userName.Length < 1)
                {
                    Console.WriteLine("Error: Username must be at least 1 character long.");
                }
                else if (_playerService.ReadAccountById(userName) != null)
                {
                    Console.WriteLine("Error: This username is already taken. Please choose another.");
                    userName = null; 
                }
            } while (string.IsNullOrWhiteSpace(userName) || userName == null);

            string password;
            do
            {
                Console.Write("Enter password (at least 3 characters): ");
                password = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(password) || password.Length < 3)
                {
                    Console.WriteLine("Error: Password must be at least 3 characters long.");
                }
            } while (string.IsNullOrWhiteSpace(password) || password.Length < 3);

            BaseAccount account = new StandardAccount(userName, password);
            _playerService.CreateAccount(account);

            Console.WriteLine($"Account '{userName}' created successfully.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        public string GetDescription()
        {
            return "Create a new account";
        }
    }
}
