using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MemoKu.POS.Mvc;
using MemoKu.POS.Mvc.Interface;
using MemoKu.POS.Reporting.Models;
using MemoKu.POS.Utils;

namespace MemoKu.POS.Views
{
    public partial class MainView : Form, IMainView
    {
        private static MainView _instance;
        private IMainController m_ctrl;
        public MainView()
        {
            InitializeComponent();
        }

        public MainView(bool fullscreen)
            : this()
        {
            if (fullscreen)
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        public static MainView Instance(bool fullscreen)
        {
            if (_instance.IsNull())
                _instance = new MainView(fullscreen);
            return _instance;
        }

        public void LogOut()
        {
            MessageBox.Show("LogOut");
            m_ctrl.CloseSession();
            Close();
        }

        private void MainView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                m_ctrl.OnKeyDown(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message);
            }
        }

        public void SetController(IMainController mainController)
        {
            this.m_ctrl = mainController;
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            m_ctrl.Start();
        }

        public void FocusToInputTextBox()
        {
            this.txtInput.Focus();
        }

        public void SetCompanyProfile(CompanyProfile cp)
        {
            if (cp.IsNull()) return;
            if (cp.Logo.IsNotEmpty())
                companyLogoBox.Image = Image.FromStream(new MemoryStream(cp.Logo));
            lblCompanyName.Text = cp.Name;
        }

        public void SetInfo(IModeInformation informationView)
        {
            this.lblInfomation.Text = informationView.ModeName.ToUpper();
            menu1.Text = informationView.Menu1;
            menu2.Text = informationView.Menu2;
            menu3.Text = informationView.Menu3;
            menu4.Text = informationView.Menu4;
            menu5.Text = informationView.Menu5;
            menu6.Text = informationView.Menu6;
            menu7.Text = informationView.Menu7;
            menu8.Text = informationView.Menu8;
            menu9.Text = informationView.Menu9;
            menu10.Text = informationView.Menu10;
            menu11.Text = informationView.Menu11;
            menu12.Text = informationView.Menu12;
            menu13.Text = informationView.Menu13;
            menu14.Text = informationView.Menu14;
            menu15.Text = informationView.Menu15;
            menu16.Text = informationView.Menu16;
        }

        public string txtInputTextBox
        {
            get { return this.txtInput.Text; }
        }

        public void AddOrUpdateItem(Guid itemId)
        {
            var item = Context.Session.ShoppingCart.Items.FirstOrDefault(i => i.Id == itemId);
            gridPOS.AddOrUpdateItem(item);
            RefreshFooter();
            ClearAndFocusTextBox();
        }

        public void DeleteSelectedItem()
        {
            gridPOS.DeleteSelectedItem();
            RefreshFooter();
            ClearAndFocusTextBox();
        }

        private void RefreshFooter()
        {
            var totalQty = Context.Session.ShoppingCart.Items.Sum(i => i.Quantity);
            var netAmount = Context.Session.ShoppingCart.Summary.NetAmount;
            gridPOS.SetTotalItems(totalQty, netAmount);
        }

        private void ClearAndFocusTextBox()
        {
            txtInput.Text = string.Empty;
            txtInput.Focus();
        }

        public Guid GetItemSelected()
        {
            return gridPOS.GetSelectedItemRowDataSource();
        }

        public void FocusNextGridItem()
        {
            gridPOS.MoveNextItem();
        }

        public void FocusPreviousGridItem()
        {
            gridPOS.MovePreviousItem();
        }

        public void FocusSelectedGridItemToTop()
        {
            gridPOS.MoveSelectedItemToTop();
        }

        public void Clear()
        {
            this.txtInput.Text = string.Empty;
            gridPOS.Clear();
            //gridPOS.SetTotal(0);
            //gridPOS.SetChange("");
            gridPOS.SetTotalItems(0, 0);
            //barcodeScanner.SetPayment("");
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            //LogOut();
        }
    }
}
