using game.Commands;
using game.Interface;

namespace game.Core
{
    class CommandManager
    {
        private readonly List<ICommand> _commands;

        public CommandManager()
        {
            _commands = new List<ICommand>();
        }

        public void RegisterCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public void ShowMenu(bool isLoggedIn)
        {
            Console.WriteLine("\nAvailable commands:");

            int start = isLoggedIn ? 2 : 0; 
            int count = isLoggedIn ? _commands.Count - 2 : 2; 

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}. {_commands[start + i].GetDescription()}");
            }
            Console.WriteLine("0. Exit");
        }

        public void ExecuteCommand(int commandIndex, bool isLoggedIn)
        {
            int start = isLoggedIn ? 2 : 0; 
            int count = isLoggedIn ? _commands.Count - 2 : 2;

            if (commandIndex >= 1 && commandIndex <= count)
            {
                _commands[start + commandIndex - 1].Execute();
            }
            else if (commandIndex != 0)
            {
                Console.WriteLine("Invalid command.");
            }
        }
    }
}






