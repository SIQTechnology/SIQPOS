using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Windows.Forms;
using MemoKu.POS.Mvc.Interface;
using MemoKu.POS.Reporting.Models;
using MemoKu.POS.Utils;

namespace MemoKu.POS.Views
{
    public partial class LoginView : Form, ILoginView
    {
        public event Action OnLogin;
        public event Action OnPrinterChanged;
        public event Action OnUseCashdrawerChanged;
        public event Action OnIsFullScreenChanged;

        public LoginView()
        {
            InitializeComponent();
            InitTabPrinter();
        }

        private void btnShowOption_Click(object sender, EventArgs e)
        {
            if (loginPanel.Visible == true)
                configureAdvancedLoginView();
            else
                configureSimpleLoginView();
        }

        private void configureSimpleLoginView()
        {
            panelTimer.Start();
            loginPanel.Controls.Add(loginContainer);
            panelAdvanceLogin.Hide();
            loginPanel.Show();
            btnShowOption.Text = "Show Options";
        }
        private void configureAdvancedLoginView()
        {
            panelTimer.Start();
            tabGeneral.Controls.Add(loginContainer);
            loginPanel.Hide();
            panelAdvanceLogin.Show();
            btnShowOption.Text = "Hide Options";
        }

        private void panelTimer_Tick(object sender, EventArgs e)
        {
            if (loginPanel.Visible == true)
            {
                this.Height -= 15;
                if (this.Height < 250) panelTimer.Stop();
            }
            else
            {
                this.Height += 15;
                if (this.Height > 310) panelTimer.Stop();
            }
            this.txtUsername.Focus();
        }

        public void ShowSimpleLogin()
        {
            configureSimpleLoginView();
            this.ShowDialog();
        }

        public void ShowAdvancedLogin()
        {
            configureAdvancedLoginView();
            this.ShowDialog();
        }

        public void HideLinkRegister()
        {
            this.linkRegister.Hide();
        }

        public void CloseView()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.IsNullOrWhiteSpace())
                this.txtUsername.Focus();
            else if (txtPassword.Text.IsNullOrWhiteSpace())
                this.txtPassword.Focus();
            else
                if (OnLogin != null) OnLogin();
        }

        public void Waiting()
        {
            this.Cursor = Cursors.WaitCursor;
            this.Refresh();
        }

        public void Idle()
        {
            this.Cursor = Cursors.Default;
            this.Refresh();
            this.txtUsername.Focus();
        }

        public string UserName
        {
            get { return txtUsername.Text; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message,
                String.Format("{0} - {1}", ProductName, ProductVersion),
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        protected virtual void sendTab(KeyEventArgs e)
        {
            if (ActiveControl is TextBox)
            {
                TextBox tb = (TextBox)ActiveControl;
                if (tb.Multiline)
                    return;
            }
            if (e.KeyValue == (int)Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void LoginView_KeyDown(object sender, KeyEventArgs e)
        {
            sendTab(e);
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(ConfigurationManager.AppSettings["registerURI"]);
        }

        #region Settings Printer

        private void InitTabPrinter()
        {
            List<string> printerInstalled = new List<string>();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                printerInstalled.Add(printer);
            }
            this.comboPrinter.DataSource = printerInstalled;
        }

        public void SetPOSSetting(POSSetting setting)
        {
            if (!setting.PrinterName.Equals(string.Empty))
            {
                this.comboPrinter.SelectedIndex = comboPrinter.Items.IndexOf(setting.PrinterName);
            }

            this.checkBoxCashdrawer.Checked = setting.IsUseCashdrawer;
            this.checkBoxFullScreen.Checked = setting.IsFullScreen;
        }

        public bool IsFullScreen
        {
            get { return this.checkBoxFullScreen.Checked; }
        }

        public string PrinterName
        {
            get { return this.comboPrinter.Text; }
        }

        public bool IsUseCashdrawer
        {
            get { return this.checkBoxCashdrawer.Checked; }
        }

        private void comboPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnPrinterChanged != null) OnPrinterChanged();
        }

        private void checkBoxCashdrawer_CheckedChanged(object sender, EventArgs e)
        {
            if (OnUseCashdrawerChanged != null) OnUseCashdrawerChanged();
        }

        private void checkBoxFullScreen_CheckedChanged(object sender, EventArgs e)
        {
            if (OnIsFullScreenChanged != null) OnIsFullScreenChanged();
        }

        #endregion
    }
}
