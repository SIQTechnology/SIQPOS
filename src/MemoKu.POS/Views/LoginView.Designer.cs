using System.Windows.Forms;
namespace MemoKu.POS.Views
{
    partial class LoginView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            this.headerPictureBox = new System.Windows.Forms.PictureBox();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.settingTabStrip = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnLogin = new DevComponents.DotNetBar.ButtonX();
            this.btnShowOption = new DevComponents.DotNetBar.ButtonX();
            this.bigPanel = new System.Windows.Forms.Panel();
            this.panelAdvanceLogin = new System.Windows.Forms.Panel();
            this.tabAdvanceLogin = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tabDisplay = new System.Windows.Forms.TabPage();
            this.checkBoxFullScreen = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.tabPrinter = new System.Windows.Forms.TabPage();
            this.checkBoxCashdrawer = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.comboPrinter = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.loginContainer = new System.Windows.Forms.TableLayoutPanel();
            this.linkRegister = new System.Windows.Forms.LinkLabel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panelTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.headerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingTabStrip)).BeginInit();
            this.settingTabStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.bigPanel.SuspendLayout();
            this.panelAdvanceLogin.SuspendLayout();
            this.tabAdvanceLogin.SuspendLayout();
            this.tabDisplay.SuspendLayout();
            this.tabPrinter.SuspendLayout();
            this.loginPanel.SuspendLayout();
            this.loginContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPictureBox
            // 
            this.headerPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("headerPictureBox.Image")));
            this.headerPictureBox.Location = new System.Drawing.Point(0, 0);
            this.headerPictureBox.Name = "headerPictureBox";
            this.headerPictureBox.Size = new System.Drawing.Size(349, 67);
            this.headerPictureBox.TabIndex = 0;
            this.headerPictureBox.TabStop = false;
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(256, 126);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "tabItem1";
            // 
            // settingTabStrip
            // 
            this.settingTabStrip.CanReorderTabs = true;
            this.settingTabStrip.Controls.Add(this.tabControlPanel2);
            this.settingTabStrip.Controls.Add(this.tabControlPanel1);
            this.settingTabStrip.Location = new System.Drawing.Point(13, 4);
            this.settingTabStrip.Name = "settingTabStrip";
            this.settingTabStrip.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.settingTabStrip.SelectedTabIndex = 1;
            this.settingTabStrip.Size = new System.Drawing.Size(256, 152);
            this.settingTabStrip.TabIndex = 0;
            this.settingTabStrip.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.settingTabStrip.Text = "tabControl1";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(256, 126);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "tabItem2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.bigPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 139);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.66476F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.19198F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLogin, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnShowOption, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 103);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(349, 36);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(268, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 22);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Help";
            // 
            // btnLogin
            // 
            this.btnLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLogin.Location = new System.Drawing.Point(180, 7);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 22);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnShowOption
            // 
            this.btnShowOption.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnShowOption.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnShowOption.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnShowOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowOption.Location = new System.Drawing.Point(19, 6);
            this.btnShowOption.Name = "btnShowOption";
            this.btnShowOption.Size = new System.Drawing.Size(75, 23);
            this.btnShowOption.TabIndex = 7;
            this.btnShowOption.Text = "Show Options";
            this.btnShowOption.Click += new System.EventHandler(this.btnShowOption_Click);
            // 
            // bigPanel
            // 
            this.bigPanel.Controls.Add(this.panelAdvanceLogin);
            this.bigPanel.Controls.Add(this.loginPanel);
            this.bigPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bigPanel.Location = new System.Drawing.Point(0, 0);
            this.bigPanel.Name = "bigPanel";
            this.bigPanel.Size = new System.Drawing.Size(349, 139);
            this.bigPanel.TabIndex = 1;
            this.bigPanel.TabStop = true;
            // 
            // panelAdvanceLogin
            // 
            this.panelAdvanceLogin.Controls.Add(this.tabAdvanceLogin);
            this.panelAdvanceLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAdvanceLogin.Location = new System.Drawing.Point(0, 103);
            this.panelAdvanceLogin.Name = "panelAdvanceLogin";
            this.panelAdvanceLogin.Size = new System.Drawing.Size(349, 36);
            this.panelAdvanceLogin.TabIndex = 3;
            // 
            // tabAdvanceLogin
            // 
            this.tabAdvanceLogin.Controls.Add(this.tabGeneral);
            this.tabAdvanceLogin.Controls.Add(this.tabDisplay);
            this.tabAdvanceLogin.Controls.Add(this.tabPrinter);
            this.tabAdvanceLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabAdvanceLogin.Location = new System.Drawing.Point(0, 0);
            this.tabAdvanceLogin.Name = "tabAdvanceLogin";
            this.tabAdvanceLogin.SelectedIndex = 0;
            this.tabAdvanceLogin.Size = new System.Drawing.Size(349, 171);
            this.tabAdvanceLogin.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(341, 145);
            this.tabGeneral.TabIndex = 2;
            this.tabGeneral.Text = "General";
            // 
            // tabDisplay
            // 
            this.tabDisplay.Controls.Add(this.checkBoxFullScreen);
            this.tabDisplay.Location = new System.Drawing.Point(4, 22);
            this.tabDisplay.Name = "tabDisplay";
            this.tabDisplay.Padding = new System.Windows.Forms.Padding(3);
            this.tabDisplay.Size = new System.Drawing.Size(341, 145);
            this.tabDisplay.TabIndex = 4;
            this.tabDisplay.Text = "Display";
            this.tabDisplay.UseVisualStyleBackColor = true;
            // 
            // checkBoxFullScreen
            // 
            this.checkBoxFullScreen.Location = new System.Drawing.Point(15, 19);
            this.checkBoxFullScreen.Name = "checkBoxFullScreen";
            this.checkBoxFullScreen.Size = new System.Drawing.Size(185, 23);
            this.checkBoxFullScreen.TabIndex = 0;
            this.checkBoxFullScreen.Text = "Menggunakan Fullscreen ?";
            this.checkBoxFullScreen.CheckedChanged += new System.EventHandler(this.checkBoxFullScreen_CheckedChanged);
            // 
            // tabPrinter
            // 
            this.tabPrinter.Controls.Add(this.checkBoxCashdrawer);
            this.tabPrinter.Controls.Add(this.comboPrinter);
            this.tabPrinter.Controls.Add(this.label3);
            this.tabPrinter.Location = new System.Drawing.Point(4, 22);
            this.tabPrinter.Name = "tabPrinter";
            this.tabPrinter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrinter.Size = new System.Drawing.Size(341, 145);
            this.tabPrinter.TabIndex = 3;
            this.tabPrinter.Text = "Printer";
            this.tabPrinter.UseVisualStyleBackColor = true;
            // 
            // checkBoxCashdrawer
            // 
            this.checkBoxCashdrawer.Location = new System.Drawing.Point(19, 59);
            this.checkBoxCashdrawer.Name = "checkBoxCashdrawer";
            this.checkBoxCashdrawer.Size = new System.Drawing.Size(166, 23);
            this.checkBoxCashdrawer.TabIndex = 2;
            this.checkBoxCashdrawer.Text = "Menggunakan Cashdrawer ?";
            this.checkBoxCashdrawer.CheckedChanged += new System.EventHandler(this.checkBoxCashdrawer_CheckedChanged);
            // 
            // comboPrinter
            // 
            this.comboPrinter.DisplayMember = "Text";
            this.comboPrinter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboPrinter.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.comboPrinter.FormattingEnabled = true;
            this.comboPrinter.Location = new System.Drawing.Point(19, 31);
            this.comboPrinter.Name = "comboPrinter";
            this.comboPrinter.Size = new System.Drawing.Size(297, 21);
            this.comboPrinter.TabIndex = 1;
            this.comboPrinter.WatermarkText = "No Printer in this Computer";
            this.comboPrinter.SelectedIndexChanged += new System.EventHandler(this.comboPrinter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Pilih printer untuk print struk :";
            // 
            // loginPanel
            // 
            this.loginPanel.Controls.Add(this.loginContainer);
            this.loginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.loginPanel.Location = new System.Drawing.Point(0, 0);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(349, 103);
            this.loginPanel.TabIndex = 1;
            this.loginPanel.TabStop = true;
            // 
            // loginContainer
            // 
            this.loginContainer.ColumnCount = 7;
            this.loginContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.loginContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81F));
            this.loginContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.loginContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.loginContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.loginContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.loginContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.loginContainer.Controls.Add(this.linkRegister, 3, 3);
            this.loginContainer.Controls.Add(this.lblUsername, 1, 1);
            this.loginContainer.Controls.Add(this.lblPassword, 1, 2);
            this.loginContainer.Controls.Add(this.txtUsername, 2, 1);
            this.loginContainer.Controls.Add(this.txtPassword, 2, 2);
            this.loginContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.loginContainer.Location = new System.Drawing.Point(0, 0);
            this.loginContainer.Name = "loginContainer";
            this.loginContainer.RowCount = 4;
            this.loginContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.loginContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66F));
            this.loginContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.loginContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.loginContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.loginContainer.Size = new System.Drawing.Size(349, 103);
            this.loginContainer.TabIndex = 1;
            this.loginContainer.TabStop = true;
            // 
            // linkRegister
            // 
            this.linkRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkRegister.AutoSize = true;
            this.loginContainer.SetColumnSpan(this.linkRegister, 3);
            this.linkRegister.LinkArea = new System.Windows.Forms.LinkArea(0, 29);
            this.linkRegister.Location = new System.Drawing.Point(159, 71);
            this.linkRegister.Name = "linkRegister";
            this.linkRegister.Size = new System.Drawing.Size(163, 13);
            this.linkRegister.TabIndex = 1;
            this.linkRegister.TabStop = true;
            this.linkRegister.Text = "Don\'t have a Memoku account ?";
            this.linkRegister.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRegister_LinkClicked);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsername.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(22, 14);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(75, 29);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username :";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(22, 43);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(75, 28);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password :";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUsername
            // 
            // 
            // 
            // 
            this.txtUsername.Border.Class = "TextBoxBorder";
            this.loginContainer.SetColumnSpan(this.txtUsername, 4);
            this.txtUsername.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtUsername.Location = new System.Drawing.Point(103, 17);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(219, 20);
            this.txtUsername.TabIndex = 7;
            this.txtUsername.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.WatermarkText = "Example : test@memoku.com";
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.Border.Class = "TextBoxBorder";
            this.loginContainer.SetColumnSpan(this.txtPassword, 4);
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(103, 46);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(219, 20);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // panelTimer
            // 
            this.panelTimer.Interval = 1;
            this.panelTimer.Tick += new System.EventHandler(this.panelTimer_Tick);
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 206);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.headerPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "LoginView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POS Memoku";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginView_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.headerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingTabStrip)).EndInit();
            this.settingTabStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.bigPanel.ResumeLayout(false);
            this.panelAdvanceLogin.ResumeLayout(false);
            this.tabAdvanceLogin.ResumeLayout(false);
            this.tabDisplay.ResumeLayout(false);
            this.tabPrinter.ResumeLayout(false);
            this.tabPrinter.PerformLayout();
            this.loginPanel.ResumeLayout(false);
            this.loginContainer.ResumeLayout(false);
            this.loginContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox headerPictureBox;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabControl settingTabStrip;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel bigPanel;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Panel panelAdvanceLogin;
        private System.Windows.Forms.TabControl tabAdvanceLogin;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnLogin;
        private DevComponents.DotNetBar.ButtonX btnShowOption;
        protected System.Windows.Forms.Timer panelTimer;
        private System.Windows.Forms.TabPage tabPrinter;
        private System.Windows.Forms.Label label3;
        public DevComponents.DotNetBar.Controls.ComboBoxEx comboPrinter;
        public DevComponents.DotNetBar.Controls.CheckBoxX checkBoxCashdrawer;
        private System.Windows.Forms.TableLayoutPanel loginContainer;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUsername;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPassword;
        private LinkLabel linkRegister;
        private TabPage tabDisplay;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxFullScreen;
    }
}