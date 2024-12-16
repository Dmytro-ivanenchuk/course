using game.Core;
using game.Commands;
using game.Data;
using game.Interface;
using game.Services;
using game.Models;

namespace game.Core
{
    class SessionManager
    {
        private BaseAccount _currentAccount;

        public bool IsLoggedIn()
        {
            return _currentAccount != null;
        }

        public void Login(BaseAccount account)
        {
            _currentAccount = account;
            Console.WriteLine($"Logged in as {account.UserName}");
        }
        public BaseAccount GetCurrentAccount()
        {
            return _currentAccount;
        }
        public void Logout()
        {
            _currentAccount = null;
            Console.WriteLine("Logged out successfully.");
        }
    }

}
