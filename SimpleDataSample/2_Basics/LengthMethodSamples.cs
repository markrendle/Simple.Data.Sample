using System.Collections.Generic;
namespace SimpleDataSample
{
    internal class LengthMethodSamples
    {
        internal void RunAll()
        {
            ExampleRunner.RunQuery(
                "Len applied to table as select function",
                db => db.Albums.Length(),
                new List<string> { "" });

            ExampleRunner.RunQuery(
                "Len applied to table within select function",
                db => db.Albums.Select(db.Albums.Length()),
                new List<string> { "" });

            ExampleRunner.RunQuery(
                "Len applied to table column within select function",
                db => db.Albums.Select(db.Albums.Title.Length().As("NameLength")),
                new List<string> { "NameLength" });

            ExampleRunner.RunQuery(
                "Len applied to table column within select function",
                db => db.Albums.Select(db.Albums.Title.Length()),
                new List<string> { "" });

            ExampleRunner.RunQuery(
                "Length given argument",
                db => db.Albums.Select(db.Albums.Title.Length(123)),
                new List<string> { "" });

            ExampleRunner.RunQuery(
                "Len applied to numerical column",
                db => db.Albums.Select(db.Albums.Price.Length()),
                new List<string> { "" });

            ExampleRunner.RunQuery(
                "Len applied to datetime",
                db => db.Carts.Select(db.Carts.DateCreated.Length()),
                new List<string> { "" });

        }
    }
}