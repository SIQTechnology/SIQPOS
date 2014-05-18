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
    public class when_count_row : behave_like_data_example_inserted
    {
        static long result;
        Because of = () =>
        {
            result = SQLCeDb.AgregateOf("SELECT Count(*) FROM Example").ReturnAs<long>();
        };

        It should_be_counted = () =>
        {
            result.ShouldBeGreaterThan(0);
        };
    }
}
