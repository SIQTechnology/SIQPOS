using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoKu.POS.Mvc.Interface
{
    public interface ISearchPartView
    {
        void ShowView();

        void Close();

        void SetController(IMainController m_controller);
    }
}
