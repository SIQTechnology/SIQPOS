using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoKu.POS.Mvc.Informations;
using MemoKu.POS.Mvc.Interface;

namespace MemoKu.POS.Mvc.Modes
{
    public class SearchPartMode : ActionMode
    {
        private IMainController m_ctrl;
        private IModeController mode_ctrl;
        private ISearchPartView searchPart_view;

        public SearchPartMode(IMainController mainController, ISearchPartView searchPart_view, IModeController mode_ctrl)
            : base(new SearchPartModeInfo())
        {
            this.m_ctrl = mainController;
            this.searchPart_view = searchPart_view;
            this.mode_ctrl = mode_ctrl;
        }

        public override void OnKeyEnterPress(string txtInputTextBox)
        {
            searchPart_view.ShowView();
        }

        public override void OnKeyEscapePress()
        {
            searchPart_view.Close();
            mode_ctrl.ChangeToScanMode();
        }
    }
}
