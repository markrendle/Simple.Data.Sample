namespace SimpleDataSample
{
    internal class FindAllMethodSamples
    {
        internal void RunAll()
        {
            ExampleRunner.RunQuery(
                "Run FindAll with no arguments. Throw BadExpressionException",
                db => db.Albums.FindAll());

            ExampleRunner.RunQuery(
                "Run FindAll(db.Albums.GenreId) - just the column name. Throws BadExpressionException",
                db => db.Albums.FindAll(db.Albums.GenreId));

            ExampleRunner.RunQuery(
                "Run FindAll(1) - no column names. Throws BadExpressionException",
                db => db.Albums.FindAll(1));

            ExampleRunner.RunQuery(
                "Albums.FindAll(db.Albums.GenreId = null). Malformed Simple Expression. Throws BadExpressionException",
                db => db.Albums.FindAll(db.Albums.GenreId = null));

            ExampleRunner.RunQuery(
                "Albums.FindAll(db.Albums.GenreId == \"a\"). Malformed Simple Expression. Throws FormatException",
                db => db.Albums.FindAll(db.Albums.GenreId == "a"));

            ExampleRunner.RunQuery(
                "Albums.FindAll(db.Albums.GenreId != null).",
                db => db.Albums.FindAll(db.Albums.GenreId != null));

            ExampleRunner.RunQuery(
                "Albums.FindAll(db.Albums.GenreId == 1)",
                db => db.Albums.FindAll(db.Albums.GenreId == 1));

            ExampleRunner.RunQuery(
                "Albums.FindAll(db.Albums.GenreId > 3)",
                db => db.Albums.FindAll(db.Albums.GenreId > 3));

            ExampleRunner.RunQuery(
                "Albums.FindAll(db.Albums.GenreId == 1 && db.Albums.ArtistId == 120)",
                db => db.Albums.FindAll(db.Albums.GenreId == 1 && db.Albums.ArtistId == 120));

            ExampleRunner.RunQuery(
                "Albums.FindAll(db.Albums.GenreId == 1 & db.Albums.ArtistId == 120)",
                db => db.Albums.FindAll(db.Albums.GenreId == 1 & db.Albums.ArtistId == 120));

            ExampleRunner.RunQuery(
                "Albums.FindAll(db.Albums.GenreId == 2 || db.Albums.ArtistId == 160)",
                db => db.Albums.FindAll(db.Albums.GenreId == 2 || db.Albums.ArtistId == 160));

            ExampleRunner.RunQuery(
                "Albums.FindAll(db.Albums.GenreId == 2 | db.Albums.ArtistId == 160)",
                db => db.Albums.FindAll(db.Albums.GenreId == 2 | db.Albums.ArtistId == 160));

            ExampleRunner.RunQuery(
                "Albums.FindAll(db.Albums.GenreId == 1, db.Albums.ArtistId == 120). Throws BadExpressionException as only one SimpleExpression allowed in FindAll",
                db => db.Albums.FindAll(db.Albums.GenreId == 1, db.Albums.ArtistId == 120));
        }
    }
}