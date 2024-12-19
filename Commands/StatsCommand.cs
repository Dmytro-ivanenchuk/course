using game.Core;
using game.Interface;
using game.Models;
using game.UI;

namespace game.Commands
{
    class ViewStatsCommand : ICommand
    {
        private readonly SessionManager _sessionManager;

        public ViewStatsCommand(SessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public void Execute()
        {
            if (_sessionManager.IsLoggedIn())
            {
                BaseAccount account = _sessionManager.GetCurrentAccount();
                StatsUI.DisplayStats(account);
            }
            else
            {
                Console.WriteLine("No player is logged in. Please log in to view stats.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        public string GetDescription()
        {
            return "View stats";
        }
    }
}
