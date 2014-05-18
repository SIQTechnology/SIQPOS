using System;
using MemoKu.POS.Mvc.Informations;
using MemoKu.POS.Mvc.Interface;
using MemoKu.POS.Utils;

namespace MemoKu.POS.Mvc.Modes
{
    public class ScanMode : ActionMode
    {
        private IMainController m_ctrl;
        private IMainView m_view;
        private ISearchPartView searchPart_view;
        private IModeController mode_ctrl;

        public ScanMode(IMainController mainController, IMainView mainView, IModeController mode_ctrl, ISearchPartView searchPart_view)
            : base(new ScanModeInfo())
        {
            this.m_ctrl = mainController;
            this.m_view = mainView;
            this.mode_ctrl = mode_ctrl;
            this.searchPart_view = searchPart_view;
        }

        public override void InitializeView()
        {
            m_view.FocusToInputTextBox();
        }

        public override void OnKeyEnterPress(string txtInputBox)
        {
            if (txtInputBox.IsNullOrWhiteSpace())
            {
                searchPart_view.ShowView();
            }
            else
            {
                var itemId = Context.Session.CurrentItemId;
                if (txtInputBox.IsCalculateExpression())
                {
                    int qty = txtInputBox.GetExpressionValue().ToInt32();
                    ShoppingCartService.ChangeQuantity(itemId, qty);
                }
                else
                {
                    itemId = ShoppingCartService.AddItem(txtInputBox);
                    Context.Session.SetCurrentItemId(itemId);
                }
                m_view.AddOrUpdateItem(itemId);
            }
        }

        public override void OnKeyUpPress()
        {
            ShoppingCartService.IncreaseQuantity(Context.Session.CurrentItemId);
            m_view.AddOrUpdateItem(Context.Session.CurrentItemId);
        }

        public override void OnKeyDownPress()
        {
            ShoppingCartService.DecreaseQuantity(Context.Session.CurrentItemId);
            m_view.AddOrUpdateItem(Context.Session.CurrentItemId);
        }

        public override void OnKeyDeletePress()
        {
            ShoppingCartService.DeleteItem(Context.Session.CurrentItemId, Context.Session.POSUser.Username);
            m_view.DeleteSelectedItem();
            if (Context.Session.ShoppingCart.HasItems())
                Context.Session.SetCurrentItemId(m_view.GetItemSelected());
            else
                Context.Session.SetCurrentItemId(Guid.Empty);
        }

        public override void OnKeyF2Press()
        {
            if (Context.Session.ShoppingCart.HasItems())
                mode_ctrl.ChangeToSelectionItemMode();
        }

        public override void OnKeySpacePress()
        {
            mode_ctrl.ChangeToPaymentMode();
        }

        public override void OnKeyF3Press()
        {
            mode_ctrl.ChangeToSearchPartMode();
        }        
    }
}
