using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading;

namespace MemoKu.POS.Database.Query
{
    public class SQLCeTableExistQuery : SQLCeBaseCommand
    {
        private string tableName;
        private SQLCeTableExistQuery() { }

        internal SQLCeTableExistQuery(string tableName)
        {
            this.tableName = tableName;
        }

        public bool IsExist()
        {
            try
            {
                using (var connection = new SqlCeConnection(ConnectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        using (var command = connection.CreateCommand())
                        {
                            var statement = "SELECT COUNT(*) FROM information_schema.tables WHERE table_name = @tableName";
                            command.CommandText = statement;
                            command.Parameters.AddWithValue("tableName", tableName);
                            var count = Convert.ToInt32(command.ExecuteScalar());
                            return count > 0;
                        }
                    }
                }
            }
            catch (SqlCeLockTimeoutException ex)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                return IsExist();
            }
            catch (Exception ex)
            {
                LogOrSendMailToAdmin(ex);
                throw;
            }
        }
    }
}
