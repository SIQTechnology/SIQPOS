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
    [Subject(typeof(SQLCeDb))]
    class when_update_data : behave_like_data_example_inserted
    {
        Establish ctx = () =>
        {
            dataExample.ChangeName("Test 1 2 3");
        };

        Because of = () =>
        {
            SQLCeDb.Do("UPDATE Example SET name = @name where id = @id").AddParameter("name", dataExample.Name).And("id", dataExample.Id).Than.Execute();
        };

        It should_be_updated = () =>
        {
            var result = SQLCeDb.Find<Example>("select * from Example where id = @id").AddParameter("id", dataExample.Id).Than.DeserializeUsing(ExampleDeserializer).ReturnOne();
            result.Name.ShouldEqual("Test 1 2 3");
        };
    }
}
