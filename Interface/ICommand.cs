using game.Core;
using game.Commands;
using game.Data;
using game.Interface;
using game.Services;
using game.Models;

namespace game.Interface
{
    interface ICommand
    {
        void Execute(); 
        string GetDescription(); 
    }
}
