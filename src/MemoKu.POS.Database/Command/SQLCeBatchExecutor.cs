using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Threading;

namespace MemoKu.POS.Database.Command
{
    public class SQLCeBatchExecutor<T> : SQLCeBaseCommand
    {
        private SQLCeBatchExecutor() { }
        internal SQLCeBatchExecutor(string commandText)
            : base(commandText)
        {
        }

        public void ForData(IEnumerable<T> datas, Action<SqlCeParameterCollection, T> setParameterValue)
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
                            command.CommandText = _commandText;
                            CreateParametersToCommand(command);
                            try
                            {
                                foreach (var item in datas)
                                {
                                    setParameterValue.Invoke(command.Parameters, item);
                                    command.ExecuteNonQuery();
                                }
                                transaction.Commit();
                            }
                            catch
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                }
            }
            catch (SqlCeLockTimeoutException ex)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                ForData(datas, setParameterValue);
            }
            catch (Exception ex)
            {
                LogOrSendMailToAdmin(ex);
                throw;
            }
        }
    }
}