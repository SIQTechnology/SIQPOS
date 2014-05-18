using System;
using System.Data.SqlServerCe;
using System.Threading;

namespace MemoKu.POS.Database.Query
{
    public class SQLCeExecuteDataReader : SQLCeBaseCommand
    {
        private SQLCeExecuteDataReader() { }
        internal SQLCeExecuteDataReader(string commandText) : base(commandText) { }

        public SQLiteCondition<SQLCeExecuteDataReader> AddParameter(string name, object value)
        {
            if (name.IsNullOrWhiteSpace()) throw new NullReferenceException("Parameter name is null");
            return new SQLiteCondition<SQLCeExecuteDataReader>(this, name, value);
        }
        public void ReadTo(Action<SqlCeDataReader> readerAction)
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
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    readerAction.Invoke(reader);
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlCeLockTimeoutException ex)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                ReadTo(readerAction);
            }
            catch (Exception ex)
            {
                LogOrSendMailToAdmin(ex);
                throw;
            }
        }
    }
}