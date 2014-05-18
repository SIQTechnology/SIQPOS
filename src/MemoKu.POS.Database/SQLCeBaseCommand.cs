using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;

namespace MemoKu.POS.Database
{
    public abstract class SQLCeBaseCommand
    {
        protected string _commandText;
        readonly protected List<SqlCeParameter> _parameters = new List<SqlCeParameter>();

        protected SQLCeBaseCommand() { }
        protected SQLCeBaseCommand(string commandText)
        {
            _commandText = commandText;
        }

        protected string ConnectionString
        {
            get
            {
                var connectionString = String.Format("DataSource={0};", DatabaseFilePath);
                return connectionString;
            }
        }

        protected string DatabaseFilePath
        {
            get
            {
                var databaseName = "siqdb.sdf";
                var databaseFilePath = Path.Combine(DataDirectory, databaseName);
                return databaseFilePath;
            }
        }

        private static string DataDirectory
        {
            get
            {
                string appDataLocation = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                string posDataLocation = Path.Combine(appDataLocation, "SIQPOS");
                if (!Directory.Exists(posDataLocation))
                    Directory.CreateDirectory(posDataLocation);
                return posDataLocation;
            }
        }

        protected void SetParametersToCommand(SqlCeCommand command)
        {
            _parameters.ForEach(p => command.Parameters.Add(p));
        }
        protected void CreateParametersToCommand(SqlCeCommand command)
        {
            var cmdText = command.CommandText;
            cmdText = cmdText.Remove(0, cmdText.IndexOf('@'));
            cmdText = cmdText.Remove(cmdText.LastIndexOf(')'), cmdText.Length - cmdText.LastIndexOf(')'));
            var paramNames = cmdText.Split(',');
            foreach (var pm in paramNames)
            {
                command.Parameters.Add(new SqlCeParameter(pm.Trim(), System.Data.SqlDbType.VarChar));
            }
        }
        private void AddParameter(SqlCeParameter parameter)
        {
            _parameters.Add(parameter);
        }

        protected void LogOrSendMailToAdmin(Exception ex)
        {
        }

        public class SQLiteCondition<T> where T : SQLCeBaseCommand
        {
            T _baseCommand;
            internal SQLiteCondition(T baseCommand, string name, object value)
            {
                _baseCommand = baseCommand;
                _baseCommand.AddParameter(new SqlCeParameter("@" + name, value));
            }
            public SQLiteCondition<T> And(string name, object value)
            {
                if (name.IsNullOrWhiteSpace()) throw new NullReferenceException("Parameter name is null");
                _baseCommand.AddParameter(new SqlCeParameter("@" + name, value));
                return this;
            }
            public T Than { get { return _baseCommand; } }
        }
    }
}