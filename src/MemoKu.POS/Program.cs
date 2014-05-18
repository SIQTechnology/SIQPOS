using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MemoKu.POS.App_Start;
using MemoKu.POS.Mvc.Controller;
using MemoKu.POS.Mvc.Interface;
using MemoKu.POS.Mvc.Sessions;
using MemoKu.POS.Reporting;
using MemoKu.POS.Repositories;
using MemoKu.POS.Views;
using StructureMap;

namespace MemoKu.POS
{
    static class Program
    {
        public static Mutex mutex;
        [STAThread]
        static void Main()
        {
            mutex = new Mutex(true, "POS Memoku");
            if (mutex.WaitOne(0, false))
            {
                try
                {
                    Application_Start();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    LoginView loginView = new LoginView();
                    ILoginController loginController = new LoginController(loginView);
                    loginController.ShowLoginView();
                    if (loginView.DialogResult.Equals(DialogResult.OK))
                    {
                        loginView.Dispose();
                        InitializeComponent();
                        Application.Run(MainView.Instance(PosSettingRepository.Get().IsFullScreen));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, string.Format("{0} - (1)",
                                Application.ProductName, Application.ProductVersion), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private static void InitializeComponent()
        {
            IMainView m_view = MainView.Instance(PosSettingRepository.Get().IsFullScreen);
            ISearchPartView searchPart_view = SearchPartView.Instance;
            IMainController m_controller = new MainController(m_view, searchPart_view);
            searchPart_view.SetController(m_controller);
            m_view.SetController(m_controller);
        }

        private static void Application_Start()
        {
            StructureMapConfig.RegisterServices();
            StructureMapConfig.RegisterSessionControl();
        }

        private static POSSettingRepository PosSettingRepository
        {
            get { return ObjectFactory.GetInstance<POSSettingRepository>(); }
        }
    }
}
