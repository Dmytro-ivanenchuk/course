using game.Core;
using game.Commands;
using game.Data;
using game.Interface;
using game.Services;
using game.Models;

namespace game.Interface
{
    interface IPlayerService
    {
        void CreateAccount(BaseAccount player);
        BaseAccount ReadAccountById(string userName);
        List<BaseAccount> ReadAllAccounts();

        BaseAccount GetCurrentAccount(); 
    }
}