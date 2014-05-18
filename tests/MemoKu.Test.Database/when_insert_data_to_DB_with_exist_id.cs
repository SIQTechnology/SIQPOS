using System;
using System.Data.SqlServerCe;
using Machine.Specifications;
using MemoKu.POS.Database;
using MemoKu.Test.Database.contexts;
using MemoKu.Test.Database.Models;

namespace MemoKu.Test.Database
{
    [Subject("SQLite Insert Data")]
    public class when_insert_data_to_DB_with_exist_id : behave_like_data_example_inserted
    {
        static Exception ex;

        Because of = () =>
        {
            Example example = new Example(dataExample.Id, "Test Again");
            ex = Catch.Exception(() =>
            {
                SQLCeDb.Do("INSERT INTO Example (id, name) VALUES (@id, @name)").AddParameter("id", example.Id).And("name", example.Name).Than.Execute();
            });
        };

        It thow_exception_with_type_SqlCeException = () =>
        {
            ex.GetType().ShouldEqual(typeof(SqlCeException));
        };
    }
}
