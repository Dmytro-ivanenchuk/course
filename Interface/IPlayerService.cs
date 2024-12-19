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