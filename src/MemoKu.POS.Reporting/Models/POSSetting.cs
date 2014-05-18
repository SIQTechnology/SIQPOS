using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoKu.POS.Reporting.Models
{
    public class POSSetting
    {
        public string PrinterName { get; set; }
        public bool IsUseCashdrawer { get; set; }
        public bool HasBeenLoggedIn { get; set; }
        public bool IsFullScreen { get; set; }

        public POSSetting()
        {
            this.HasBeenLoggedIn = false;
            this.IsFullScreen = false;
            this.PrinterName = string.Empty;
            this.IsUseCashdrawer = true;
        }

        public void LoggedIn()
        {
            this.HasBeenLoggedIn = true;
        }

        public void ChangePrinter(string printerName)
        {
            this.PrinterName = printerName;
        }

        public void UseCashdrawer()
        {
            this.IsUseCashdrawer = true;
        }

        public void NoUseCashdrawer()
        {
            this.IsUseCashdrawer = false;
        }

        public void SetToFullScreen()
        {
            this.IsFullScreen = true;
        }

        public void SetToDefaultScreen()
        {
            this.IsFullScreen = false;
        }
    }
}
