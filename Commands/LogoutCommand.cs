using game.Core;
using game.Interface;


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
