using game.Core;

namespace game.UI
{
class UIManager
{
    private readonly CommandManager _commandManager;
    private readonly SessionManager _sessionManager;

    public UIManager(CommandManager commandManager, SessionManager sessionManager)
    {
        _commandManager = commandManager;
        _sessionManager = sessionManager;
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();

            bool isLoggedIn = _sessionManager.IsLoggedIn();

            if (!isLoggedIn)
            {
                Console.WriteLine("Welcome! Please choose an option:");
            }
            else
            {
                Console.WriteLine($"Welcome back, {_sessionManager.GetCurrentAccount().UserName}! Please choose an option:");
            }

            _commandManager.ShowMenu(isLoggedIn);

            Console.Write("Select an option: ");
            if (int.TryParse(Console.ReadLine(), out int commandIndex))
            {
                if (commandIndex == 0)
                {
                    Console.WriteLine("Exiting the program...");
                    break;
                }

                Console.Clear();
                _commandManager.ExecuteCommand(commandIndex, isLoggedIn);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.ReadLine();
            }
        }
    }
}
}