using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoKu.POS.Mvc.Informations;
using MemoKu.POS.Mvc.Interface;

namespace MemoKu.POS.Mvc.Modes
{
    public class EndTransactionMode : ActionMode
    {
        private IMainController m_ctrl;
        private IMainView m_view;
        private IModeController mode_ctrl;

        public EndTransactionMode(IMainController mainController, IMainView mainView, IModeController mode_ctrl)
            : base(new EndTransactionModeInfo())
        {
            this.m_ctrl = mainController;
            this.m_view = mainView;
            this.mode_ctrl = mode_ctrl;
        }
        
        public override void OnKeyEnterPress(string paymentAmount)
        {
            var sessionId = Context.Session.POSSession.Id;
            var userName = Context.Session.POSUser.Username;
            ShoppingCartService.Create(sessionId, userName);
            m_ctrl.CreateNewTransaction();
        }
    }
}
