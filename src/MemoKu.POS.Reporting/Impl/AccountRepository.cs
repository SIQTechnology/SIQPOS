using System.Data.SqlServerCe;
using MemoKu.POS.Database;
using MemoKu.POS.Reporting.Models;
using MemoKu.POS.Utils;

namespace MemoKu.POS.Reporting
{
    public class AccountRepository : IAccountRepository
    {
        public bool ValidateUser(string username, string password)
        {
            bool authenticate = false;
            var sqlStatement = "SELECT * FROM tbluser WHERE username = @username";
            SQLCeDb.Find(sqlStatement).AddParameter("username", username).
                Than.ReadTo(reader =>
                {
                    string pwd = reader["password"].ToString().DecryptString();
                    authenticate = pwd == password;
                });
            return authenticate;
        }

        public POSUser Get(string username)
        {
            var sqlStatement = "SELECT * FROM tbluser WHERE username = @username";
            POSUser user = SQLCeDb.Find<POSUser>(sqlStatement).DeserializeUsing(POSUserDeserializer).AddParameter("username", username).Than.ReturnOne();
            return user;
        }

        private POSUser POSUserDeserializer(SqlCeDataReader reader)
        {
            var username = reader["username"].ToString();
            string[] roles = reader["roles"].ToString().DecryptString().Replace("\n", "").Split(',');
            string[] rules = reader["rules"].ToString().DecryptString().Replace("\n", "").Split(',');
            return new POSUser(username, roles, rules);
        }
    }
}
