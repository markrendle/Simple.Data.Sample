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

            ExampleRunner.RunQuery(
                "Run db.Albums.Exists.Exists - returns true",
                db => db.Albums.Exists().Exists());

            ExampleRunner.RunQuery(
                "Run db.AlbumCovers.Exists table exists. Throws UnresolvableObjectException",
                db => db.AlbumCovers.Exists());

            ExampleRunner.RunQuery(
                 "Run Exists(db.Albums.GenreId) - just the column name. Throws BadExpressionException",
                 db => db.Albums.Exists(db.Albums.GenreId));

            ExampleRunner.RunQuery(
                "Run Exists(1) - no column names. Throws BadExpressionException",
                db => db.Albums.Exists(1));

            ExampleRunner.RunQuery(
                "Run Exists(1) - no column names. Throws BadExpressionException",
                db => db.Albums.Exists(true));

            ExampleRunner.RunQuery(
                 "Run Exists(two expressions). Throws BadExpressionException",
                 db => db.Albums.Exists(db.Albums.GenreId == 1, db.Albums.AlbumId == 1));

            ExampleRunner.RunQuery(
                "Albums.Exists(db.Albums.GenreId == \"a\"). Malformed Simple Expression. Throws FormatException",
                db => db.Albums.Exists(db.Albums.GenreId == "a"));

            ExampleRunner.RunQuery(
                "Albums.Exists(db.Albums.GenreId != null).",
                db => db.Albums.Exists(db.Albums.GenreId != null));

            ExampleRunner.RunQuery(
                "Albums.Exists(db.Albums.GenreId == 1)",
                db => db.Albums.Exists(db.Albums.GenreId == 1));

            ExampleRunner.RunQuery(
                "Albums.Exists(db.Albums.GenreId > 3)",
                db => db.Albums.Exists(db.Albums.GenreId > 3));

            ExampleRunner.RunQuery(
                "Albums.Exists(db.Albums.GenreId == 1 && db.Albums.ArtistId == 120)",
                db => db.Albums.Exists(db.Albums.GenreId == 1 && db.Albums.ArtistId == 120));

            ExampleRunner.RunQuery(
                "Albums.Exists(db.Albums.GenreId == 1 & db.Albums.ArtistId == 120)",
                db => db.Albums.Exists(db.Albums.GenreId == 1 & db.Albums.ArtistId == 120));

            ExampleRunner.RunQuery(
                "Albums.Exists(db.Albums.GenreId == 2 || db.Albums.ArtistId == 160)",
                db => db.Albums.Exists(db.Albums.GenreId == 2 || db.Albums.ArtistId == 160));

            ExampleRunner.RunQuery(
                "Albums.Exists(db.Albums.GenreId == 2 | db.Albums.ArtistId == 160)",
                db => db.Albums.Exists(db.Albums.GenreId == 2 | db.Albums.ArtistId == 160));


        }
    }
}