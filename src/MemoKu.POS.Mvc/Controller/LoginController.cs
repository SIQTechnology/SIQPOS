using System;
using System.Drawing.Printing;
using MemoKu.POS.Domain.Services;
using MemoKu.POS.Mvc.Interface;
using MemoKu.POS.Reporting;
using MemoKu.POS.Reporting.Models;
using StructureMap;

namespace MemoKu.POS.Mvc.Controller
{
    public class LoginController : ILoginController
    {
        private readonly IAccountRepository accountRepository = ObjectFactory.GetInstance<IAccountRepository>();
        private readonly IPOSSettingRepository posSettingRepository = ObjectFactory.GetInstance<IPOSSettingRepository>();
        private readonly IDatabaseManagement databaseManagement = ObjectFactory.GetInstance<IDatabaseManagement>();
        private readonly SessionService sessionService = ObjectFactory.GetInstance<SessionService>();

        private ILoginView loginView;
        public LoginController(ILoginView loginView)
        {
            this.loginView = loginView;
            this.loginView.OnLogin += loginView_OnLogin;
            this.loginView.OnPrinterChanged += loginView_OnPrinterChanged;
            this.loginView.OnUseCashdrawerChanged += loginView_OnCashdrawerChanged;
            this.loginView.OnIsFullScreenChanged += loginView_OnIsFullScreenChanged;
            initSetting();
        }

        void loginView_OnLogin()
        {
            try
            {
                loginView.Waiting();
                if (!posSettingRepository.IsHasBeenLoggedIn())
                {
                    databaseManagement.CreateTablesIfNecessary();
                    //Sync Data
                    posSettingRepository.SetToLoggedIn();
                }
                var isAuthenticated = accountRepository.ValidateUser(loginView.UserName, loginView.Password);
                if (!isAuthenticated)
                    throw new ApplicationException("Invalid username or password");

                POSUser user = accountRepository.Get(loginView.UserName);
                Context.Session.SetPOSUser(user);
                loginView.CloseView();
            }
            catch (Exception ex)
            {
                loginView.ShowMessage(ex.GetBaseException().Message);
                loginView.Idle();
            }
        }

        public void ShowLoginView()
        {
            if (posSettingRepository.IsHasBeenLoggedIn())
            {
                loginView.HideLinkRegister();
                loginView.ShowSimpleLogin();
            }
            else
                loginView.ShowAdvancedLogin();
        }

        #region Settings Control

        private void initSetting()
        {
            POSSetting setting = posSettingRepository.Get();
            if (setting.PrinterName.Equals(string.Empty) && PrinterSettings.InstalledPrinters.Count > 0)
            {
                setting.ChangePrinter(PrinterSettings.InstalledPrinters[0]);
                posSettingRepository.Save(setting);
            }
            this.loginView.SetPOSSetting(setting);
        }

        void loginView_OnCashdrawerChanged()
        {
            POSSetting setting = posSettingRepository.Get();
            if (loginView.IsUseCashdrawer)
                setting.UseCashdrawer();
            else
                setting.NoUseCashdrawer();
            posSettingRepository.Save(setting);
        }

        void loginView_OnPrinterChanged()
        {
            POSSetting setting = posSettingRepository.Get();
            setting.ChangePrinter(loginView.PrinterName);
            posSettingRepository.Save(setting);
        }

        void loginView_OnIsFullScreenChanged()
        {
            POSSetting setting = posSettingRepository.Get();
            if (loginView.IsFullScreen)
                setting.SetToFullScreen();
            else
                setting.SetToDefaultScreen();
            posSettingRepository.Save(setting);
        }

        #endregion
    }
}
