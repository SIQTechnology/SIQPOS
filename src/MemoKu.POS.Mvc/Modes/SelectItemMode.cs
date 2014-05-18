using MemoKu.POS.Mvc.Informations;
using MemoKu.POS.Mvc.Interface;

namespace MemoKu.POS.Mvc.Modes
{
    public class SelectItemMode : ActionMode
    {
        private IMainController m_ctrl;
        private IMainView m_view;
        private IModeController mode_ctrl;

        public SelectItemMode(IMainController mainController, IMainView mainView, IModeController mode_ctrl)
            : base(new SelectItemModeInfo())
        {
            this.m_ctrl = mainController;
            this.m_view = mainView;
            this.mode_ctrl = mode_ctrl;
        }

        public override void OnKeyEscapePress()
        {
            mode_ctrl.ChangeToScanMode();
        }

        public override void OnKeyDownPress()
        {
            m_view.FocusNextGridItem();
        }

        public override void OnKeyUpPress()
        {
            m_view.FocusPreviousGridItem();
        }

        public override void OnKeyEnterPress(string txtInputTextBox)
        {
            m_view.FocusSelectedGridItemToTop();
            var itemId = m_view.GetItemSelected();
            Context.Session.SetCurrentItemId(itemId);
            mode_ctrl.ChangeToScanMode();
        }
    }
}
