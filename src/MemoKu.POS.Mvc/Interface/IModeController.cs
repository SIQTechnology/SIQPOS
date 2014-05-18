using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MemoKu.POS.Mvc.Modes;

namespace MemoKu.POS.Mvc.Interface
{
    public interface IModeController
    {
        ActionMode CurrentMode { get; }
        void Action(KeyEventArgs key);
        void ChangeToSelectionItemMode();
        void ChangeToScanMode();
        void ChangeToEndTransactionMode();
        void ChangeToPaymentMode();
        void ChangeToSearchPartMode();
    }
}
