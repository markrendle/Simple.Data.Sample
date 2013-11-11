namespace SimpleDataSample
{
    internal class AllMethodSamples
    {
        internal void RunAll()
        {
            ExampleRunner.RunQuery(
                "Run All with no arguments. Query runs OK",
                db => db.Albums.All());

            ExampleRunner.RunQuery(
                "Run All(db.Albums.GenreId) - just the column name. Argument ignored, query runs OK",
                db => db.Albums.All(db.Albums.GenreId));

            ExampleRunner.RunQuery(
                "Run All(1) - no column names. Argument ignored, query runs OK",
                db => db.Albums.All(1));

            ExampleRunner.RunQuery(
                "Albums.All(db.Albums.GenreId = null). Malformed Simple Expression. Throws BadExpressionException",
                db => db.Albums.All(db.Albums.GenreId = null));

            ExampleRunner.RunQuery(
                "Albums.All(db.Albums.GenreId == \"a\"). Malformed Simple Expression. Argument ignored, query runs OK",
                db => db.Albums.All(db.Albums.GenreId == "a"));

            ExampleRunner.RunQuery(
                "Albums.All(db.Albums.GenreId != null). Valid criteria ignored. Returns all albums",
                db => db.Albums.All(db.Albums.GenreId != null));

            ExampleRunner.RunQuery(
                "Albums.All(db.Albums.GenreId == 1). Valid criteria ignored. Returns all albums",
                db => db.Albums.All(db.Albums.GenreId == 1));

            ExampleRunner.RunQuery(
                "Albums.All(db.Albums.GenreId > 3). Valid criteria ignored. Returns all albums",
                db => db.Albums.All(db.Albums.GenreId > 3));

            ExampleRunner.RunQuery(
                "Albums.All(db.Albums.GenreId == 1 && db.Albums.ArtistId == 120). Valid criteria ignored. Returns all albums",
                db => db.Albums.All(db.Albums.GenreId == 1 && db.Albums.ArtistId == 120));

            ExampleRunner.RunQuery(
                "Albums.All(db.Albums.GenreId == 1 & db.Albums.ArtistId == 120). Valid criteria ignored. Returns all albums",
                db => db.Albums.All(db.Albums.GenreId == 1 & db.Albums.ArtistId == 120));

            ExampleRunner.RunQuery(
                "Albums.All(db.Albums.GenreId == 2 || db.Albums.ArtistId == 160). Valid criteria ignored. Returns all albums",
                db => db.Albums.All(db.Albums.GenreId == 2 || db.Albums.ArtistId == 160));

            ExampleRunner.RunQuery(
                "Albums.All(db.Albums.GenreId == 2 | db.Albums.ArtistId == 160). Valid criteria ignored. Returns all albums",
                db => db.Albums.All(db.Albums.GenreId == 2 | db.Albums.ArtistId == 160));

            ExampleRunner.RunQuery(
                "Albums.All(db.Albums.GenreId == 1, db.Albums.ArtistId == 120). Only one SimpleExpression should be allowed, but criteria ignored anyway. Returns all albums",
                db => db.Albums.All(db.Albums.GenreId == 1, db.Albums.ArtistId == 120));
        }
    }
}