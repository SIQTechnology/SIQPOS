using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Threading;

namespace MemoKu.POS.Database.Query
{
    public class SQLCeQuery<T> : SQLCeBaseCommand
    {
        Func<SqlCeDataReader, T> _deserializer;
        int _pageSize;
        int _pageIndex;

        private SQLCeQuery() { }
        internal SQLCeQuery(string commandText) : base(commandText) { }

        public SQLCeQuery<T> DeserializeUsing(Func<SqlCeDataReader, T> deserializer)
        {
            _deserializer = deserializer;
            return this;
        }
        /// <summary>
        /// Limit = page size = row count
        /// </summary>
        public SQLCeQuery<T> LimitTo(int limit)
        {
            _pageSize = limit;
            return this;
        }
        /// <summary>
        /// Offset = page index = row index >> return row from offset
        /// </summary>
        public SQLCeQuery<T> OffsetFrom(int offset)
        {
            _pageIndex = offset;
            return this;
        }
        public SQLiteCondition<SQLCeQuery<T>> AddParameter(string name, object value)
        {
            if (name.IsNullOrWhiteSpace()) throw new NullReferenceException("Parameter name is null");
            name = name.Replace("@", "");
            return new SQLiteCondition<SQLCeQuery<T>>(this, name, value);
        }
        public T ReturnOne()
        {
            return ReturnAll().FirstOrDefault();
        }
        public IList<T> ReturnAll()
        {
            try
            {
                if (_deserializer.IsNull())
                    throw new NullReferenceException(string.Format("Deserializer {0} has not set", typeof(T).Name));
                using (var connection = new SqlCeConnection(ConnectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        using (var command = connection.CreateCommand())
                        {
                            var commandNotHaveLimitation = !_commandText.ToLowerInvariant().Contains("limit");
                            var commandNotHaveOffset = !_commandText.ToLowerInvariant().Contains("offset");
                            if (_pageSize > 0 && commandNotHaveLimitation)
                            {
                                _commandText = _commandText.TrimEnd(';');
                                _commandText += " ROWS FETCH NEXT @pageSize ROWS ONLY";
                            }
                            if (_pageIndex > 0 && commandNotHaveOffset)
                            {
                                _commandText = _commandText.TrimEnd(';');
                                _commandText += " OFFSET @pageIndex";
                            }
                            command.CommandText = _commandText;
                            SetParametersToCommand(command);
                            if (commandNotHaveLimitation && _pageSize > 0)
                                command.Parameters.Add(new SqlCeParameter("@pageSize", _pageSize));
                            if (commandNotHaveOffset && _pageIndex > 0)
                                command.Parameters.Add(new SqlCeParameter("@pageIndex", _pageIndex));

                            using (var reader = command.ExecuteReader())
                            {
                                List<T> entities = new List<T>();
                                while (reader.Read())
                                {
                                    var entity = _deserializer.Invoke(reader);
                                    entities.Add(entity);
                                }
                                return entities;
                            }
                        }
                    }
                }
            }
            catch (SqlCeLockTimeoutException ex)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                return ReturnAll();
            }
            catch (Exception ex)
            {
                LogOrSendMailToAdmin(ex);
                throw;
            }
        }
    }
}