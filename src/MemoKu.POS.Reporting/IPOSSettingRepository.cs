using MemoKu.POS.Reporting.Models;
namespace MemoKu.POS.Reporting
{
    public interface IPOSSettingRepository
    {
        POSSetting Get();
        bool IsHasBeenLoggedIn();
        void SetToLoggedIn();
        void Save(POSSetting setting);
    }
}
