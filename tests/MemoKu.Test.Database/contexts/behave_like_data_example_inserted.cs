using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using MemoKu.POS.Database;
using MemoKu.Test.Database.Models;

namespace MemoKu.Test.Database.contexts
{
    [Subject(typeof(SQLCeDb))]
    public class behave_like_data_example_inserted : create_table_example
    {
        protected static Example dataExample;
        Establish ctx = () =>
        {
            var id = Guid.NewGuid().ToString();
            dataExample = new Example(id, "Test");
            SQLCeDb.Do("INSERT INTO Example (id, name) VALUES (@id, @name)").AddParameter("id", id).And("name", dataExample.Name).Than.Execute();
        };

        Cleanup clear_data_example = () =>
        {
            SQLCeDb.Do("DELETE FROM Example where id = @id").AddParameter("id", dataExample.Id);
        };
    }
}
