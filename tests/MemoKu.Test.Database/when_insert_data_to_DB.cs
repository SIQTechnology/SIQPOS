using System;
using Machine.Specifications;
using MemoKu.POS.Database;
using MemoKu.Test.Database.contexts;
using MemoKu.Test.Database.Models;

namespace MemoKu.Test.Database
{
    [Subject(typeof(SQLCeDb))]
    public class when_insert_data_to_DB : create_table_example
    {
        static string id = Guid.NewGuid().ToString();
        Establish ctx = () =>
        {
        };

        Because of = () =>
        {
            Example test = new Example(id, "Test");
            SQLCeDb.Do("INSERT INTO Example (Id, Name) VALUES (@id, @name)").AddParameter("id", id).And("name", test.Name).Than.Execute();
        };

        It should_be_inserted = () =>
        {
            var result = SQLCeDb.Find<Example>("select * from Example where id = @id").AddParameter("id", id).Than.DeserializeUsing(ExampleDeserializer).ReturnOne();
            result.ShouldNotBeNull();
        };

        Cleanup delete_inserted_row = () =>
        {
            SQLCeDb.Do("DELETE FROM Example where id = @id").AddParameter("id", id);
        };
    }
}
