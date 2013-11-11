using Simple.Data;
using SimpleDataSample.POCO;
using System.Collections.Generic;
namespace SimpleDataSample
{
    internal class SingleMethodSamples
    {
        internal void RunAll()
        {
            ExampleRunner.RunQuery(
                "Single used as select function rather than appended to it",
                db => db.Albums.Single());

            ExampleRunner.RunQuery(
                "Single applied to table within select function",
                db => db.Albums.Select(db.Albums.Single()));

            ExampleRunner.RunQuery(
                "Single applied to table within select function after All()",
                db => db.Albums.All().Select(db.Albums.Single()));

            ExampleRunner.RunQuery(
                "Single applied to table column within select function",
                db => db.Albums.All().Select(db.Albums.Title.Single()));

            ExampleRunner.RunQuery(
                "Single appended to select function",
                db => db.Albums.All().Select(db.Albums.Title).Single());

            ExampleRunner.RunQuery(
                "Single given bad argument",
                db => db.Albums.All().Select(db.Albums.Title).Single(123));

            ExampleRunner.RunQuery(
                "Single<T> appended to select function ",
                db => db.Albums.All().Select(db.Albums.Title).Single<Album>(),
                null, "Album");

            ExampleRunner.RunQuery(
                "Single<T> given bad argument",
                db => db.Albums.All().Select(db.Albums.Title).Single<Album>(123),
                null, "Album");

            ExampleRunner.RunQuery(
                "Single(func) replacing where clause",
                db => GetSingleAlbumStartingWithA(db),
                null, "Album");

            ExampleRunner.RunQuery(
                "Single() called against a null result",
                db => db.Albums.All().Where(db.Albums.Price > 9).Single());

            ExampleRunner.RunQuery(
                "Single<T>() called against a null result",
                db => db.Albums.All().Where(db.Albums.Price > 9).Single<Album>(),
                null, "Album");

            ExampleRunner.RunQuery(
                "Single() called against a null result",
                db => GetSingleAlbumMoreThanNine(db),
                null, "Album");

        }

        private dynamic GetSingleAlbumMoreThanNine(dynamic db)
        {
            SimpleQuery sq = db.Albums.All();
            return sq.Single<Album>(a => a.Price > 9);
        }

        private dynamic GetSingleAlbumStartingWithA(dynamic db)
        {
            SimpleQuery sq = db.Albums.All().Select(db.Albums.Title);
            return sq.Single<Album>(a => a.Title.StartsWith("A"));
        }
    }

    internal class SingleOrDefaultMethodSamples
    {
        internal void RunAll()
        {
            ExampleRunner.RunQuery(
                "SingleOrDefault used as select function rather than appended to it",
                db => db.Albums.SingleOrDefault());

            ExampleRunner.RunQuery(
                "SingleOrDefault applied to table within select function",
                db => db.Albums.Select(db.Albums.SingleOrDefault()));

            ExampleRunner.RunQuery(
                "SingleOrDefault applied to table within select function after All()",
                db => db.Albums.All().Select(db.Albums.SingleOrDefault()));

            ExampleRunner.RunQuery(
                "SingleOrDefault applied to table column within select function",
                db => db.Albums.All().Select(db.Albums.Title.SingleOrDefault()));

            ExampleRunner.RunQuery(
                "SingleOrDefault appended to select function",
                db => db.Albums.All().Select(db.Albums.Title).SingleOrDefault());

            ExampleRunner.RunQuery(
                "SingleOrDefault given bad argument",
                db => db.Albums.All().Select(db.Albums.Title).SingleOrDefault(123));

            ExampleRunner.RunQuery(
                "SingleOrDefault<T> appended to select function ",
                db => db.Albums.All().Select(db.Albums.Title).SingleOrDefault<Album>(),
                null, "Album");

            ExampleRunner.RunQuery(
                "SingleOrDefault<T> given bad argument",
                db => db.Albums.All().Select(db.Albums.Title).SingleOrDefault<Album>(123),
                null, "Album");

            ExampleRunner.RunQuery(
                "SingleOrDefault(func) replacing where clause",
                db => GetSingleOrDefaultAlbumStartingWithA(db),
                null, "Album");

            ExampleRunner.RunQuery(
                "SingleOrDefault() called against a null result",
                db => db.Albums.All().Where(db.Albums.Price > 9).SingleOrDefault());

            ExampleRunner.RunQuery(
                "SingleOrDefault<T>() called against a null result",
                db => db.Albums.All().Where(db.Albums.Price > 9).SingleOrDefault<Album>(),
                null, "Album");

            ExampleRunner.RunQuery(
                "SingleOrDefault() called against a null result",
                db => GetSingleAlbumMoreThanNine(db),
                null, "Album");

        }

        private dynamic GetSingleAlbumMoreThanNine(dynamic db)
        {
            SimpleQuery sq = db.Albums.All();
            return sq.SingleOrDefault<Album>(a => a.Price > 9);
        }

        private dynamic GetSingleOrDefaultAlbumStartingWithA(dynamic db)
        {
            SimpleQuery sq = db.Albums.All().Select(db.Albums.Title);
            return sq.SingleOrDefault<Album>(a => a.Title.StartsWith("A"));
        }
    }
}

