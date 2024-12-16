using game.Core;
using game.Commands;
using game.Data;
using game.Interface;
using game.Services;
using game.Models;

namespace game.Commands
{
    class LogoutCommand : ICommand
    {
        private readonly SessionManager _sessionManager;

        public LogoutCommand(SessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public void Execute()
        {
            _sessionManager.Logout();
        }

        public string GetDescription()
        {
            return "Logout";
        }
    }

}
