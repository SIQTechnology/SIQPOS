using MemoKu.POS.Utils;

namespace MemoKu.POS.Reporting.Configurations
{
    public static class PrinterConfiguration
    {
        public static string Filename
        {
            get
            {
                return string.Format("{0}printersetting.json", DatabaseConfiguration.DBPath.ResolveDir());
            }
        }
    }
}
