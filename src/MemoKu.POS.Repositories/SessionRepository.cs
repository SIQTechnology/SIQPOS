using System;
using System.Data.SqlServerCe;
using MemoKu.POS.Database;
using MemoKu.POS.Domain.Entities;
using MemoKu.POS.Domain.Repository;
using MemoKu.POS.Domain.ValueObjects;

namespace MemoKu.POS.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        public POSSession GetSessionOpened(string userName)
        {
            var sqlStatement = "SELECT * FROM tblsession WHERE username = '@username' and sessionstate = 1";
            return SQLCeDb.Find<POSSession>(sqlStatement).DeserializeUsing(POSSessionDeserializer).AddParameter("username", userName).Than.ReturnOne();
        }

        public void Save(POSSession session)
        {
            SQLCeDb.Do(@"INSERT INTO tblsession (id,username,sessionstate,closedate,opendate) values (@id, @username, @sessionstate, @closedate,@opendate)")
                .AddParameter("id", session.Id)
                .And("username", session.UserName)
                .And("sessionstate", session.SessionState)
                .And("closedate", session.CloseDate)
                .And("opendate", session.OpenDate).Than.Execute();
        }

        public DateTime GetLastCloseDate(string userName)
        {
            DateTime date = new DateTime();
            var sqlStatement = "SELECT closedate FROM tblsession where username = '@username' and sessionstate = 0 order by closedate";
            SQLCeDb.Find(sqlStatement).AddParameter("username", userName).Than.ReadTo(reader =>
            {
                date = Convert.ToDateTime(reader["closedate"].ToString());
            });
            return date;
        }

        public void Update(POSSession session)
        {
            SQLCeDb.Do(@"UPDATE session set sessionstate=@sessionstate, opendate=@opendate, closedate =@closedate WHERE id = @id")
                .AddParameter("sessionstate", session.SessionState)
                .And("opendate", session.SessionState)
                .And("closedate", session.OpenDate)
                .And("id", session.Id).Than.Execute();
        }
        
        private POSSession POSSessionDeserializer(SqlCeDataReader reader)
        {
            var id = Guid.Parse(reader["id"].ToString());
            var username = reader["username"].ToString();
            var openDate = Convert.ToDateTime(reader["opendate"].ToString());
            var closeDate = Convert.ToDateTime(reader["closedate"].ToString());
            var state = (SessionState)Convert.ToInt32(reader["sessionstate"]);

            var session = new POSSession(id, username, openDate, closeDate, state);
            return session;
        }
    }
}
