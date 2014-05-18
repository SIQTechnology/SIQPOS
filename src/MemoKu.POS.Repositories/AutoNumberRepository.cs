using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using MemoKu.POS.Database;
using MemoKu.POS.Domain.Aggregate;
using MemoKu.POS.Domain.Repositories;

namespace MemoKu.POS.Repositories
{
    public class AutoNumberRepository : IAutoNumberRepository
    {
        public AutoNumber Get(DateTime transactionDate)
        {
            var autoNumber = SQLCeDb.Find<AutoNumber>("SELECT * FROM tblautonumber where date = @date").DeserializeUsing(AutoNumberDeserializer)
                .AddParameter("date", transactionDate.Date).Than.ReturnOne();
            return autoNumber;
        }

        public void Insert(AutoNumber autoNumber)
        {
            SQLCeDb.Do("INSERT INTO tblautonumber (organizationid, clientid, date, number) VALUES (@organizationid, @clientid, @date, @number)")
                .AddParameter("organizationid", autoNumber.OrganizationId)
                .And("clientid", autoNumber.ClientId)
                .And("date", autoNumber.Date)
                .And("number", autoNumber.Number).Than.Execute();
        }

        public void Update(AutoNumber autoNumber)
        {
            SQLCeDb.Do("UPDATE tblautonumber SET number = @number WHERE date = @date")
                .AddParameter("number", autoNumber.Number)
                .And("date", autoNumber.Date).Than.Execute();
        }

        private AutoNumber AutoNumberDeserializer(SqlCeDataReader reader)
        {
            string organizationId = reader["organizationid"].ToString();
            string clientId = reader["clientid"].ToString();
            DateTime date = Convert.ToDateTime(reader["date"].ToString());
            long number = Convert.ToInt64(reader["number"]);
            return new AutoNumber(organizationId, clientId, date, number);
        }
    }
}
