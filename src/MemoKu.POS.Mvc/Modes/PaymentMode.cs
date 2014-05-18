using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoKu.POS.Mvc.Informations;
using MemoKu.POS.Mvc.Interface;

namespace MemoKu.POS.Mvc.Modes
{
    public class PaymentMode : ActionMode
    {
        private IMainController m_ctrl;
        private IMainView m_view;
        private IModeController mode_ctrl;

        public PaymentMode(IMainController mainController, IMainView mainView, IModeController mode_ctrl)
            : base(new PaymentModeInfo())
        {
            this.m_ctrl = mainController;
            this.m_view = mainView;
            this.mode_ctrl = mode_ctrl;
        }

        public override void OnKeyEscapePress()
        {
            mode_ctrl.ChangeToScanMode();
        }

        public override void OnKeyEnterPress(string paymentAmount)
        {
            var organizationId = Context.Session.CompanyProfile.OrganizationId;
            var clientId = Context.Session.CompanyProfile.ClientId;
            ShoppingCartService.Pay(Convert.ToDouble(paymentAmount), organizationId, clientId);
            //mixed payment
            mode_ctrl.ChangeToEndTransactionMode();
        }
    }
}
