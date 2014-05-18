namespace MemoKu.POS.Reporting.Models
{
    public class PrinterSetting
    {
        public string PrinterName { get; set; }
        public bool IsUseCashdrawer { get; set; }

        public PrinterSetting()
        {
            this.PrinterName = string.Empty;
            this.IsUseCashdrawer = true;
        }

        public void ChangePrinterName(string printerName)
        {
            this.PrinterName = printerName;
        }

        public void ChangeIsUsingCashdrawer(bool isUseCashdrawer)
        {
            this.IsUseCashdrawer = isUseCashdrawer;
        }
    }
}
