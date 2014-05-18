using System.Data.SqlServerCe;
using System.Text;
using MemoKu.POS.Database;
using MemoKu.POS.Reporting.Models;

namespace MemoKu.POS.Reporting
{
    public class CompanyProfileRepository : ICompanyProfileRepository
    {
        public CompanyProfile Get()
        {
            return SQLCeDb.Find<CompanyProfile>("SELECT * FROM tblcompanyprofile").DeserializeUsing(CompanyProfileDeserializer).ReturnOne();
        }

        private CompanyProfile CompanyProfileDeserializer(SqlCeDataReader reader)
        {
            string organizationId = reader["organizationid"].ToString();
            string clientId = reader["clientid"].ToString();
            string name = reader["name"].ToString();
            string address = reader["address"].ToString();
            byte[] logo = Encoding.ASCII.GetBytes(reader["logo"].ToString());
            return new CompanyProfile(organizationId, clientId, name, address,logo);
        }
    }
}
