namespace $rootnamespace$
{
    internal class GetCountMethodSamples
    {
        internal void RunAll()
        {
            // Runs select count(*) from albums
            ExampleRunner.RunQuery(
                "Run GetCount(). No parameters. Runs select count(*) from albums",
                db => db.Albums.GetCount());

            // Runs select count(*) from albums
            ExampleRunner.RunQuery(
                "Run GetCount(db.Albums.GenreId) - just the column name. Throws Simple.Data.BadExpressionException",
                db => db.Albums.GetCount(db.Albums.GenreId));

            // Runs select count(*) from albums
            ExampleRunner.RunQuery(
                "Run GetCount(1) - no column names. Throws Simple.Data.BadExpressionException",
                db => db.Albums.GetCount(1));

            ExampleRunner.RunQuery(
                "Albums.GetCount(db.Albums.GenreId = null). Throws Simple.Data.BadExpressionException",
                db => db.Albums.GetCount(db.Albums.GenreId = null));

            ExampleRunner.RunQuery(
                "Albums.GetCount(db.Albums.GenreId == \"a\"). Malformed Simple Expression. Throws System.FormatException.",
                db => db.Albums.GetCount(db.Albums.GenreId == "a"));

            // select COUNT(*) from [dbo].[Albums] WHERE [dbo].[Albums].[GenreId] IS NOT NULL
            ExampleRunner.RunQuery(
                "Albums.GetCount(db.Albums.GenreId != null).",
                db => db.Albums.GetCount(db.Albums.GenreId != null));

            // select COUNT(*) from [dbo].[Albums] WHERE [dbo].[Albums].[GenreId] = @p1
            // @p1 (Int32) = 1
            ExampleRunner.RunQuery(
                "Albums.GetCount(db.Albums.GenreId == 1)",
                db => db.Albums.GetCount(db.Albums.GenreId == 1));

            // select COUNT(*) from [dbo].[Albums] WHERE [dbo].[Albums].[GenreId] > @p1
            // @p1 (Int32) = 3
            ExampleRunner.RunQuery(
                "Albums.GetCount(db.Albums.GenreId > 3)",
                db => db.Albums.GetCount(db.Albums.GenreId > 3));

            // select COUNT(*) from [dbo].[Albums] WHERE ([dbo].[Albums].[GenreId] = @p1 AND [dbo].[Albums].[ArtistId] = @p2)
            //@p1 (Int32) = 1
            //@p2 (Int32) = 120
            ExampleRunner.RunQuery(
                "Albums.GetCount(db.Albums.GenreId == 1 && db.Albums.ArtistId == 120)",
                db => db.Albums.GetCount(db.Albums.GenreId == 1 && db.Albums.ArtistId == 120));

            // select COUNT(*) from [dbo].[Albums] WHERE ([dbo].[Albums].[GenreId] = @p1 AND [dbo].[Albums].[ArtistId] = @p2)
            //@p1 (Int32) = 1
            //@p2 (Int32) = 120
            ExampleRunner.RunQuery(
                "Albums.GetCount(db.Albums.GenreId == 1 & db.Albums.ArtistId == 120)",
                db => db.Albums.GetCount(db.Albums.GenreId == 1 & db.Albums.ArtistId == 120));

            //select COUNT(*) from [dbo].[Albums] WHERE ([dbo].[Albums].[GenreId] = @p1 OR [dbo].[Albums].[ArtistId] = @p2)
            //@p1 (Int32) = 2
            //@p2 (Int32) = 160
            ExampleRunner.RunQuery(
                "Albums.GetCount(db.Albums.GenreId == 2 || db.Albums.ArtistId == 160)",
                db => db.Albums.GetCount(db.Albums.GenreId == 2 || db.Albums.ArtistId == 160));

            //select COUNT(*) from [dbo].[Albums] WHERE ([dbo].[Albums].[GenreId] = @p1 OR [dbo].[Albums].[ArtistId] = @p2)
            //@p1 (Int32) = 2
            //@p2 (Int32) = 160
            ExampleRunner.RunQuery(
                "Albums.GetCount(db.Albums.GenreId == 2 | db.Albums.ArtistId == 160)",
                db => db.Albums.GetCount(db.Albums.GenreId == 2 | db.Albums.ArtistId == 160));

            // Runs select count(*) from albums
            ExampleRunner.RunQuery(
                "Albums.GetCount(db.Albums.GenreId == 1, db.Albums.ArtistId == 120). Throws System.ArgumentException as only one SimpleExpression allowed in GetCount",
                db => db.Albums.GetCount(db.Albums.GenreId == 1, db.Albums.ArtistId == 120));
        }
    }
}