using System;
using System.IO;
using MemoKu.POS.Utils;

namespace MemoKu.POS.Reporting.Configurations
{
    public static class DatabaseConfiguration
    {
        public static string ConnectionString
        {
            get
            {
                return string.Format("Data Source={0};Version=3;Sync=Off;Read Only=false;", DBPath.ResolveDir() + "memoku.sqlite");
            }
        }

        public static string DBPath
        {
            get
            {
                string appDataLocation = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                string posDataLocation = string.Format(appDataLocation.ResolveDir() + "SIQPOS");
                if (!Directory.Exists(posDataLocation))
                    System.IO.Directory.CreateDirectory(posDataLocation);
                return posDataLocation;
            }
        }

        public static string ResolveDir(this string dir)
        {
            if (dir[dir.Length - 1] != Path.DirectorySeparatorChar)
                return dir + Path.DirectorySeparatorChar;
            else
                return dir;
        }
    }
}
