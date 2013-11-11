namespace SimpleDataSample
{
    internal class ExistsByMethodSamples
    {
        internal void RunAll()
        {
            ExampleRunner.RunQuery(
                "Run ExistsBy(). No parameters. Throws System.ArgumentException",
                db => db.Albums.ExistsBy());

            ExampleRunner.RunQuery(
                "AlbumCovers.ExistsByGenreId(1) - table doesn't exist. Throws UnresolvableObjectException",
                db => db.AlbumCovers.ExistsByGenreId(1));

            ExampleRunner.RunQuery(
                "Run ExistsByGenreId() - just the column name. Throws System.ArgumentException",
                db => db.Albums.ExistsByGenreId());

            ExampleRunner.RunQuery(
                "Run ExistsBy(1) - no column names. Throws System.ArgumentException",
                db => db.Albums.ExistsBy(1));

            ExampleRunner.RunQuery(
                "Albums.ExistsByGenreId(null).",
                db => db.Albums.ExistsByGenreId(null));

            // To flag - issue 319
            ExampleRunner.RunQuery(
                "Albums.ExistsBy(GenreId: null). - Should Work. Throws ArgumentException instead",
                db => db.Albums.ExistsBy(GenreId: null));

            // To flag - Issue 318
            ExampleRunner.RunQuery(
                "Albums.ExistsByGenreId(null).ExistsByGenreId(null). - Throws RuntimeBinderException",
                db => db.Albums.ExistsByGenreId(null).ExistsByGenreId(null));

            ExampleRunner.RunQuery(
                "Albums.ExistsByGenreId(\"a\"). Malformed Simple Expression. Throws System.FormatException",
                db => db.Albums.ExistsByGenreId("a"));

            // To flag - issue 319
            ExampleRunner.RunQuery(
                "Albums.ExistsBy(GenreId:\"a\"). Malformed Simple Expression. Should throws System.FormatException. Throws ArgumentException instead.",
                db => db.Albums.ExistsBy(GenreId: "a"));

            ExampleRunner.RunQuery(
                "Albums.ExistsByGenreId(1)",
                db => db.Albums.ExistsByGenreId(1));

            // To flag - issue 319
            ExampleRunner.RunQuery(
                "Albums.ExistsBy(GenreId :1) - Should work. Throws ArgumentException instead",
                db => db.Albums.ExistsBy(GenreId: 1));

            // To flag - issue 320
            ExampleRunner.RunQuery(
                "Albums.ExistsByGenreId(GenreId :1) - two forms mixed up. Shouldn't work but does.",
                db => db.Albums.ExistsByGenreId(GenreId: 1));

            ExampleRunner.RunQuery(
                "Albums.ExistsByGenreIdAndArtistId(1, 120)",
                db => db.Albums.ExistsByGenreIdAndArtistId(1, 120));

            // To flag - issue 319
            ExampleRunner.RunQuery(
                "Albums.ExistsBy(GenreId: 1, ArtistId: 120) - Should work. Throws ArgumentException instead.",
                db => db.Albums.ExistsBy(GenreId: 1, ArtistId: 120));
        }
    }
}