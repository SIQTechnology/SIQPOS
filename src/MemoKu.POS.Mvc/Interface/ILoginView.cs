using System;
using MemoKu.POS.Reporting.Models;

namespace MemoKu.POS.Mvc.Interface
{
    public interface ILoginView
    {
        event Action OnLogin;
        event Action OnPrinterChanged;
        event Action OnUseCashdrawerChanged;
        event Action OnIsFullScreenChanged;
        string PrinterName { get; }
        bool IsUseCashdrawer { get; }
        bool IsFullScreen { get; }
        string UserName { get; }
        string Password { get; }

        void ShowMessage(string message);
        void ShowSimpleLogin();
        void ShowAdvancedLogin();
        void HideLinkRegister();
        void CloseView();
        void Waiting();
        void Idle();
        void SetPOSSetting(POSSetting setting);
    }
}
