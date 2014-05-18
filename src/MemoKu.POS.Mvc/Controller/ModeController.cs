using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MemoKu.POS.Mvc.Interface;
using MemoKu.POS.Mvc.Modes;

namespace MemoKu.POS.Mvc.Controller
{
    public class ModeController : IModeController
    {
        private IMainView m_view;
        private ActionMode currentMode;
        private ActionMode mode_scan;
        private ActionMode mode_selectItem;
        private ActionMode mode_payment;
        private ActionMode mode_searchPartByGroup;
        private ActionMode mode_endTransaction;

        public ModeController(IMainController mainController, IMainView m_view, ISearchPartView searchPartView)
        {
            this.m_view = m_view;
            this.mode_scan = new ScanMode(mainController, m_view, this, searchPartView);
            this.mode_selectItem = new SelectItemMode(mainController, m_view, this);
            this.mode_payment = new PaymentMode(mainController, m_view, this);
            this.mode_searchPartByGroup = new SearchPartMode(mainController, searchPartView, this);
            this.mode_endTransaction = new EndTransactionMode(mainController, m_view, this);
        }

        public void Action(System.Windows.Forms.KeyEventArgs key)
        {
            if (key.KeyCode.Equals(Keys.Escape))
                currentMode.OnKeyEscapePress();
            else if (key.KeyCode.Equals(Keys.Enter))
                currentMode.OnKeyEnterPress(m_view.txtInputTextBox.Trim());
            else if (key.KeyCode.Equals(Keys.Down))
                currentMode.OnKeyDownPress();
            else if (key.KeyCode.Equals(Keys.Up))
                currentMode.OnKeyUpPress();
            else if (key.KeyCode.Equals(Keys.Delete))
                currentMode.OnKeyDeletePress();
            else if (key.KeyCode.Equals(Keys.Space))
                currentMode.OnKeySpacePress();
            else if (key.KeyCode.Equals(Keys.F2))
                currentMode.OnKeyF2Press();
            else if (key.KeyCode.Equals(Keys.F3))
                currentMode.OnKeyF3Press();
            else if (key.KeyCode.Equals(Keys.F9))
                currentMode.OnKeyF9Press();
        }

        private void changeMode(ActionMode mode)
        {
            currentMode = mode;
            currentMode.InitializeView();
            m_view.SetInfo(currentMode.GetInfomation);
        }

        public ActionMode CurrentMode
        {
            get { return currentMode; }
        }

        public void ChangeToScanMode()
        {
            changeMode(mode_scan);
        }

        public void ChangeToEndTransactionMode()
        {
            changeMode(mode_endTransaction);
        }

        public void ChangeToSelectionItemMode()
        {
            changeMode(mode_selectItem);
        }

        public void ChangeToPaymentMode()
        {
            changeMode(mode_payment);
        }

        public void ChangeToSearchPartMode()
        {
            changeMode(mode_searchPartByGroup);
            currentMode.OnKeyEnterPress(string.Empty);
        }
    }
}
