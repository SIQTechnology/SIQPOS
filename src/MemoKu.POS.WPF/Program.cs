using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemoKu.POS.WPF
{
    public class Program
    {
        internal const string APPLICATION_NAME = "Global\\SIQ Technology Limited";
        internal static Mutex AppMutex;
        [STAThread]
        public static void Main()
        {
            bool otherEPOSIsNotRunning = false;
            AppMutex = new Mutex(false, APPLICATION_NAME, out otherEPOSIsNotRunning);
            if (AppMutex.WaitOne(0, false))
            {
                LoginView loginView = new LoginView();
                loginView.ShowDialog();
                if (loginView.DialogResult.Equals(true))
                {
                    loginView.Close();
                    App app = new App();
                    app.InitializeComponent();
                    app.Run();
                }
            }
        }
    }
}
