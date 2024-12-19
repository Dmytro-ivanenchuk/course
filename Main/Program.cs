using game.Commands;
using game.Core;
using game.Data;
using game.Models;
using game.Services;
using game.UI;

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

        UIManager uiManager = new UIManager(commandManager, sessionManager);
        uiManager.Run();
    }
}



