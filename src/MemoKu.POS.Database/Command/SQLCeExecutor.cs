using System;
using System.Data.SqlServerCe;
using System.Threading;

namespace MemoKu.POS.Database.Command
{
    public class SQLCeExecutor : SQLCeBaseCommand
    {
        private SQLCeExecutor() { }
        internal SQLCeExecutor(string commandText) : base(commandText) { }

        public SQLiteCondition<SQLCeExecutor> AddParameter(string name, object value)
        {
            if (name.IsNullOrWhiteSpace()) throw new NullReferenceException("Parameter name is null");
            return new SQLiteCondition<SQLCeExecutor>(this, name, value);
        }
        public void Execute()
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
                            SetParametersToCommand(command);
                            try
                            {
                                command.ExecuteNonQuery();
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
                Execute();
            }
            catch (Exception ex)
            {
                LogOrSendMailToAdmin(ex);
                throw;
            }
        }
    }
}