using Simple.Data;
using SimpleDataSample.POCO;
using System.Collections.Generic;
namespace SimpleDataSample
{
    internal class FirstMethodSamples
    {
        internal void RunAll()
        {
            ExampleRunner.RunQuery(
                "First used as select function rather than appended to it",
                db => db.Albums.First());

            ExampleRunner.RunQuery(
                "First applied to table within select function",
                db => db.Albums.Select(db.Albums.First()));

            ExampleRunner.RunQuery(
                "First applied to table within select function after All()",
                db => db.Albums.All().Select(db.Albums.First()));

            ExampleRunner.RunQuery(
                "First applied to table column within select function",
                db => db.Albums.All().Select(db.Albums.Title.First()));

            ExampleRunner.RunQuery(
                "First appended to select function",
                db => db.Albums.All().Select(db.Albums.Title).First());

            ExampleRunner.RunQuery(
                "First given bad argument",
                db => db.Albums.All().Select(db.Albums.Title).First(123));

            ExampleRunner.RunQuery(
                "First<T> appended to select function ",
                db => db.Albums.All().Select(db.Albums.Title).First<Album>(),
                null, "Album");

            ExampleRunner.RunQuery(
                "First<T> given bad argument",
                db => db.Albums.All().Select(db.Albums.Title).First<Album>(123),
                null, "Album");

            ExampleRunner.RunQuery(
                "First(func) replacing where clause",
                db => GetFirstAlbumStartingWithA(db),
                null, "Album");

            ExampleRunner.RunQuery(
                "First() called against a null result",
                db => db.Albums.All().Where(db.Albums.Price > 9).First());

            ExampleRunner.RunQuery(
                "First<T>() called against a null result",
                db => db.Albums.All().Where(db.Albums.Price > 9).First<Album>(),
                null, "Album");

            ExampleRunner.RunQuery(
                "First() called against a null result",
                db => GetFirstAlbumMoreThanNine(db),
                null, "Album");

        }

        private dynamic GetFirstAlbumMoreThanNine(dynamic db)
        {
            SimpleQuery sq = db.Albums.All();
            return sq.First<Album>(a => a.Price > 9);
        }

        private dynamic GetFirstAlbumStartingWithA(dynamic db)
        {
            SimpleQuery sq = db.Albums.All().Select(db.Albums.Title);
            return sq.First<Album>(a => a.Title.StartsWith("A"));
        }
    }

    internal class FirstOrDefaultMethodSamples
    {
        internal void RunAll()
        {
            ExampleRunner.RunQuery(
                "FirstOrDefault used as select function rather than appended to it",
                db => db.Albums.FirstOrDefault());

            ExampleRunner.RunQuery(
                "FirstOrDefault applied to table within select function",
                db => db.Albums.Select(db.Albums.FirstOrDefault()));

            ExampleRunner.RunQuery(
                "FirstOrDefault applied to table within select function after All()",
                db => db.Albums.All().Select(db.Albums.FirstOrDefault()));

            ExampleRunner.RunQuery(
                "FirstOrDefault applied to table column within select function",
                db => db.Albums.All().Select(db.Albums.Title.FirstOrDefault()));

            ExampleRunner.RunQuery(
                "FirstOrDefault appended to select function",
                db => db.Albums.All().Select(db.Albums.Title).FirstOrDefault());

            ExampleRunner.RunQuery(
                "FirstOrDefault given bad argument",
                db => db.Albums.All().Select(db.Albums.Title).FirstOrDefault(123));

            ExampleRunner.RunQuery(
                "FirstOrDefault<T> appended to select function ",
                db => db.Albums.All().Select(db.Albums.Title).FirstOrDefault<Album>(),
                null, "Album");

            ExampleRunner.RunQuery(
                "FirstOrDefault<T> given bad argument",
                db => db.Albums.All().Select(db.Albums.Title).FirstOrDefault<Album>(123),
                null, "Album");

            ExampleRunner.RunQuery(
                "FirstOrDefault(func) replacing where clause",
                db => GetFirstOrDefaultAlbumStartingWithA(db),
                null, "Album");

            ExampleRunner.RunQuery(
                "FirstOrDefault() called against a null result",
                db => db.Albums.All().Where(db.Albums.Price > 9).FirstOrDefault());

            ExampleRunner.RunQuery(
                "FirstOrDefault<T>() called against a null result",
                db => db.Albums.All().Where(db.Albums.Price > 9).FirstOrDefault<Album>(),
                null, "Album");

            ExampleRunner.RunQuery(
                "FirstOrDefault() called against a null result",
                db => GetFirstAlbumMoreThanNine(db),
                null, "Album");

        }

        private dynamic GetFirstAlbumMoreThanNine(dynamic db)
        {
            SimpleQuery sq = db.Albums.All();
            return sq.FirstOrDefault<Album>(a => a.Price > 9);
        }

        private dynamic GetFirstOrDefaultAlbumStartingWithA(dynamic db)
        {
            SimpleQuery sq = db.Albums.All().Select(db.Albums.Title);
            return sq.FirstOrDefault<Album>(a => a.Title.StartsWith("A"));
        }
    }
}

