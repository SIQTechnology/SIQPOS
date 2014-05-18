using MemoKu.POS.Reporting.Models;

namespace MemoKu.POS.Reporting
{
    public interface IAccountRepository
    {
        bool ValidateUser(string username, string password);
        POSUser Get(string username);
    }
}
