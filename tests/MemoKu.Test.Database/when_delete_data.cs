using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using MemoKu.POS.Database;
using MemoKu.Test.Database.contexts;
using MemoKu.Test.Database.Models;

namespace MemoKu.Test.Database
{
    public class when_delete_data : behave_like_data_example_inserted
    {
        Establish cxt = () =>
        {
        };

        Because of = () =>
        {
            SQLCeDb.Do("DELETE FROM Example where id = @id").AddParameter("id", dataExample.Id).Than.Execute();
        };

        It should_be_deleted = () =>
        {
            var result = SQLCeDb.Find<Example>("select * from Example where id = @id").AddParameter("id", dataExample.Id).Than.DeserializeUsing(ExampleDeserializer).ReturnOne();
            result.ShouldBeNull();
        };
    }
}
