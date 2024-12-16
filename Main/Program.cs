using game.Commands;
using game.Core;
using game.Data;
using game.Models;
using game.Services;

class Program
{
    static void Main(string[] args)
    {
        DbContext dbContext = new DbContext();
        PlayerRepository playerRepository = new PlayerRepository(dbContext);
        GameRepository gameRepository = new GameRepository(dbContext);

        PlayerService playerService = new PlayerService(playerRepository);
        GameService gameService = new GameService(gameRepository);
        SessionManager sessionManager = new SessionManager();
        GameManager gameManager = new GameManager(gameService);

        CommandManager commandManager = new CommandManager();
        commandManager.RegisterCommand(new CreateAccountCommand(playerService));
        commandManager.RegisterCommand(new LoginCommand(playerService, sessionManager));
        commandManager.RegisterCommand(new ViewStatsCommand(sessionManager));
        commandManager.RegisterCommand(new PlayGameCommand(gameManager, playerService, sessionManager));
        commandManager.RegisterCommand(new LogoutCommand(sessionManager));

        while (true)
        {
            Console.Clear();

            bool isLoggedIn = sessionManager.IsLoggedIn();

            if (!isLoggedIn)
            {
                Console.WriteLine("Welcome! Please choose an option:");
            }
            else
            {
                Console.WriteLine($"Welcome back, {sessionManager.GetCurrentAccount().UserName}! Please choose an option:");
            }

            commandManager.ShowMenu(isLoggedIn);

            Console.Write("Select an option: ");
            if (int.TryParse(Console.ReadLine(), out int commandIndex))
            {
                if (commandIndex == 0)
                {
                    Console.WriteLine("Exiting the program...");
                    break;
                }

                Console.Clear();
                commandManager.ExecuteCommand(commandIndex, isLoggedIn);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.ReadLine();
            }
        }
    }
}



