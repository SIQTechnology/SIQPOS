using MemoKu.POS.Utils;

namespace MemoKu.POS.Reporting.Configurations
{
    public static class POSSettingConfiguration
    {
        public static string Filename
        {
            get
            {
                return string.Format("{0}possetting.json", DatabaseConfiguration.DBPath.ResolveDir());
            }
        }
    }
}
