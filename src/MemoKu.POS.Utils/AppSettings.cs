using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoKu.POS.Utils
{
    /// <summary>
    /// App Setting
    /// </summary>
    public static class AppSettings
    {
        public static string ConnectionString { get { return String.Format("Data Source={0};Version=3;Synchronous=Full;Cache Size=2000;Compress=true;", DatabaseFilePath); } }

        public static string DatabaseFilePath { get { return Path.Combine(DataDirectory, "posdb.sqlite"); } }

        private static string DataDirectory
        {
            get
            {
                string appDataLocation = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string posDataLocation = Path.Combine(appDataLocation, "MemoKuPOS");
                if (!Directory.Exists(posDataLocation))
                    Directory.CreateDirectory(posDataLocation);
                return posDataLocation;
            }
        }
    }
}
