using System.Windows.Forms;

namespace MemoKu.POS.Mvc.Interface
{
    public interface IMainController
    {
        void OnKeyDown(object sender, KeyEventArgs e);
        void CreateNewTransaction();
        void CloseSession();
        void Start();
    }
}
