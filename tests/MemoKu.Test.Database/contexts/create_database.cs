using System.Data.SqlServerCe;
using Machine.Specifications;
using MemoKu.POS.Database;
using MemoKu.Test.Database.Models;

namespace MemoKu.Test.Database.contexts
{
    public class create_database
    {
        protected static Example ExampleDeserializer(SqlCeDataReader reader)
        {
            var id = reader["Id"].ToString();
            var name = reader["Name"].ToString();
            return new Example(id, name);
        }
        Establish ctx = () =>
        {
            SQLCeDb.CreateDatabase();
        };
    }
}
