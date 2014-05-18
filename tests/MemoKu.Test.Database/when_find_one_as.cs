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
    class when_find_one_as : behave_like_data_example_inserted
    {
        static Example example;
        Because of = () =>
        {
            example = SQLCeDb.Find<Example>("select * from Example where id = @id").AddParameter("id", dataExample.Id).Than.DeserializeUsing(ExampleDeserializer).ReturnOne();
        };

        It should_be_found = () =>
        {
            example.ShouldNotBeNull();
        };
    }
}
