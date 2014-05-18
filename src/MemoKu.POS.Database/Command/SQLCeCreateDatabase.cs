using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;

namespace MemoKu.POS.Database.Command
{
    public class SQLCeCreateDatabase : SQLCeBaseCommand
    {
        public SQLCeCreateDatabase()
            : base()
        {
        }

        public void CreateDB()
        {
            using (var engine = new SqlCeEngine(ConnectionString))
            {
                if (!File.Exists(DatabaseFilePath))
                {
                    engine.CreateDatabase();
                }
            }
        }
    }
}
