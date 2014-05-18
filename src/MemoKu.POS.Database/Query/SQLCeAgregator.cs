using System;
using System.Data.SqlServerCe;
using System.Threading;

namespace MemoKu.POS.Database.Query
{
    public class SQLCeAgregator : SQLCeBaseCommand
    {
        private SQLCeAgregator() { }
        internal SQLCeAgregator(string commandText) : base(commandText) { }

        public SQLiteCondition<SQLCeAgregator> Where(string name, object value)
        {
            if (name.IsNullOrWhiteSpace()) throw new NullReferenceException("Parameter name is null");
            return new SQLiteCondition<SQLCeAgregator>(this, name, value);
        }

        public T ReturnAs<T>()
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
                            return (T)Convert.ChangeType(command.ExecuteScalar(), typeof(T));
                        }
                    }
                }
            }
            catch (SqlCeLockTimeoutException ex)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                return ReturnAs<T>();
            }
            catch (Exception ex)
            {
                LogOrSendMailToAdmin(ex);
                throw;
            }
        }
    }
}