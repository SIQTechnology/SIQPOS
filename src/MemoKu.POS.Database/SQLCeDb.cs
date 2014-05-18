using System.Data;
using System.Linq;
using MemoKu.POS.Database.Command;
using MemoKu.POS.Database.Query;

namespace MemoKu.POS.Database
{
    public static class SQLCeDb
    {
        public static bool IsColumnExists(this DataTable schema, string columnName)
        {
            return schema.Rows.Cast<DataRow>().Count(r => r["name"].Equals(columnName)) > 0;
        }

        public static bool IsColumnNotExists(this DataTable schema, string columnName)
        {
            return schema.IsColumnExists(columnName) == false;
        }

        public static SQLCeQuery<T> Find<T>(string sql)
        {
            return new SQLCeQuery<T>(sql);
        }

        public static SQLCeExecuteDataReader Find(string commandText)
        {
            return new SQLCeExecuteDataReader(commandText);
        }

        public static SQLCeExecutor Do(string commandText)
        {
            return new SQLCeExecutor(commandText);
        }

        public static SQLCeBatchExecutor<T> DoBatch<T>(string commandText)
        {
            return new SQLCeBatchExecutor<T>(commandText);
        }

        public static SQLCeAgregator AgregateOf(string sql)
        {
            return new SQLCeAgregator(sql);
        }

        public static bool IsTableExist(string tableName)
        {
            return new SQLCeTableExistQuery(tableName).IsExist();
        }

        public static bool IsExists(string sql)
        {
            var count = AgregateOf(sql).ReturnAs<long>();
            return count > 0;
        }

        public static void CreateDatabase()
        {
            new SQLCeCreateDatabase().CreateDB();
        }

        //public static bool IsDatabaseIntegrityOke()
        //{
        //    var ok = false;
        //    Find("PRAGMA integrity_check").ReadTo(
        //        reader =>
        //        {
        //            var checkResult = reader[0].ToString().ToLowerInvariant().Trim();
        //            ok = checkResult == "ok";
        //        });
        //    return ok;
        //}

        //public static void Backup(bool throwOnFailed = false)
        //{
        //    if (IsDatabaseIntegrityOke())
        //    {
        //        try
        //        {
        //            DeleteDatabaseBackup();
        //            using (var source = new SQLiteConnection(AppSettings.ConnectionString))
        //            {
        //                source.OpenAndSetPassword();
        //                using (var destination = new SQLiteConnection(AppSettings.DatabaseBackupConnectionString))
        //                {
        //                    destination.OpenAndSetPassword();
        //                    source.BackupDatabase(destination, "main", "main", -1, null, 500);
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            ex.LogOrSendMailToAdmin();
        //            if (throwOnFailed)
        //                throw;
        //        }
        //    }
        //}
        //public static void RestoreDatabaseIfCorrupt()
        //{
        //    if (!SQLiteDb.IsDatabaseIntegrityOke())
        //    {
        //        if (File.Exists(AppSettings.DatabaseBackupFilePath))
        //            File.Move(AppSettings.DatabaseBackupFilePath, AppSettings.DatabaseFilePath);
        //    }
        //}
        //public static void DeleteDatabaseBackup()
        //{
        //    if (File.Exists(AppSettings.DatabaseBackupFilePath))
        //        File.Delete(AppSettings.DatabaseBackupFilePath);
        //}

        //public static DataTable GetSchema(string schemaName)
        //{
        //    var schema = new DataTable(schemaName);
        //    schema.Columns.Add("name", typeof(String));
        //    schema.Columns.Add("type", typeof(String));
        //    schema.Columns.Add("notnull", typeof(bool));
        //    schema.Columns.Add("dflt_value", typeof(String));
        //    schema.Columns.Add("pk", typeof(bool));

        //    Find(String.Format("PRAGMA table_info({0})", schemaName))
        //        .ReadTo(reader =>
        //        {
        //            var name = reader["name"] is DBNull ? "" : (string)reader["name"];
        //            var type = reader["type"] is DBNull ? "" : (string)reader["type"];
        //            var notnull = reader["notnull"] is DBNull ? false : Convert.ToBoolean(reader["notnull"]);
        //            var dflt_value = reader["dflt_value"] is DBNull ? "" : (string)reader["dflt_value"];
        //            var pk = reader["pk"] is DBNull ? false : Convert.ToBoolean(reader["pk"]);
        //            schema.Rows.Add(name, type, notnull, dflt_value, pk);
        //        });

        //    return schema;
        //}
    }
}