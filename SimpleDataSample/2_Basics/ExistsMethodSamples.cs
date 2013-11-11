using System.Collections.Generic;

namespace SimpleDataSample
{
    internal class ExistsMethodSamples
    {
        internal void RunAll()
        {
            ExampleRunner.RunQuery(
                "Run db.Albums.Exists - returns true",
                db => db.Albums.Exists());

            // To flag - issue 315
            ExampleRunner.RunQuery(
                "Run db.Albums.Exists.Exists - Throws RuntimeBinderException",
                db => db.Albums.Exists().Exists());

            ExampleRunner.RunQuery(
                "Run db.AlbumCovers.Exists - table doesn't exist. Throws UnresolvableObjectException",
                db => db.AlbumCovers.Exists());

            // To flag - issue 316
            ExampleRunner.RunQuery(
                 "Run db.Albums.Exists(db.Albums.GenreId) - just the column name. Should throw BadExpressionException. Returns true instead.",
                 db => db.Albums.Exists(db.Albums.GenreId));

            // To flag - issue 316
            ExampleRunner.RunQuery(
                "Run db.Albums.Exists(1) - no column names. Should throw BadExpressionException. Returns true instead.",
                db => db.Albums.Exists(1));

            //To flag - issue 316
            ExampleRunner.RunQuery(
                "Run db.Albums.Exists(true) - no column names. Should throw BadExpressionException. Returns true instead.",
                db => db.Albums.Exists(true));

            //To flag - issue 317
            ExampleRunner.RunQuery(
                 "Run db.Albums.Exists(two expressions). Should throw ArgumentException. Returns true instead.",
                 db => db.Albums.Exists(db.Albums.GenreId == 1, db.Albums.AlbumId == 1));

            ExampleRunner.RunQuery(
                "Run db.Albums.Exists(db.Albums.GenreId == \"a\"). Malformed Simple Expression. Throws FormatException",
                db => db.Albums.Exists(db.Albums.GenreId == "a"));

            ExampleRunner.RunQuery(
                "Run db.Albums.Exists(db.Albums.GenreId != null).",
                db => db.Albums.Exists(db.Albums.GenreId != null));

            ExampleRunner.RunQuery(
                "Run db.Albums.Exists(db.Albums.GenreId == 1)",
                db => db.Albums.Exists(db.Albums.GenreId == 1));

            ExampleRunner.RunQuery(
                "Run db.Albums.Exists(db.Albums.GenreId > 3)",
                db => db.Albums.Exists(db.Albums.GenreId > 3));

            ExampleRunner.RunQuery(
                "Run db.Albums.Exists(db.Albums.GenreId == 1 && db.Albums.ArtistId == 120)",
                db => db.Albums.Exists(db.Albums.GenreId == 1 && db.Albums.ArtistId == 120));

            ExampleRunner.RunQuery(
                "Run db.Albums.Exists(db.Albums.GenreId == 1 & db.Albums.ArtistId == 120)",
                db => db.Albums.Exists(db.Albums.GenreId == 1 & db.Albums.ArtistId == 120));

            ExampleRunner.RunQuery(
                "Run db.Albums.Exists(db.Albums.GenreId == 2 || db.Albums.ArtistId == 160)",
                db => db.Albums.Exists(db.Albums.GenreId == 2 || db.Albums.ArtistId == 160));

            ExampleRunner.RunQuery(
                "Run db.Albums.Exists(db.Albums.GenreId == 2 | db.Albums.ArtistId == 160)",
                db => db.Albums.Exists(db.Albums.GenreId == 2 | db.Albums.ArtistId == 160));


        }
    }
}