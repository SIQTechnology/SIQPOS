using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using MemoKu.POS.Database;
using MemoKu.Test.Database.Models;

namespace MemoKu.Test.Database.contexts
{
    public class create_table_example : create_database
    {
        static string tableName = "Example";
        Establish context = () =>
        {
            if (!SQLCeDb.IsTableExist(tableName))
            {
                SQLCeDb.Do("CREATE TABLE Example (id NVARCHAR(40) PRIMARY KEY, name NVARCHAR(120))").Execute();
            }
        };

        Cleanup drop_table = () =>
        {
            if (SQLCeDb.IsTableExist(tableName))
            {
                SQLCeDb.Do("DROP TABLE Example").Execute();
            }
        };
    }
}
