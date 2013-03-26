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
                "Run ExistsByGenreId() - just the column name. Throws System.ArgumentException",
                db => db.Albums.ExistsByGenreId());

            ExampleRunner.RunQuery(
                "Run ExistsBy(1) - no column names. Throws System.ArgumentException",
                db => db.Albums.ExistsBy(1));

            ExampleRunner.RunQuery(
                "Albums.ExistsByGenreId(null).",
                db => db.Albums.ExistsByGenreId(null));

            ExampleRunner.RunQuery(
                "Albums.ExistsBy(GenreId: null).",
                db => db.Albums.ExistsBy(GenreId: null));

            ExampleRunner.RunQuery(
                "Albums.ExistsByGenreId(\"a\"). Malformed Simple Expression. Throws System.FormatException",
                db => db.Albums.ExistsByGenreId("a"));

            ExampleRunner.RunQuery(
                "Albums.ExistsBy(GenreId:\"a\"). Malformed Simple Expression. Throws System.FormatException",
                db => db.Albums.ExistsBy(GenreId: "a"));

            ExampleRunner.RunQuery(
                "Albums.ExistsByGenreId(1)",
                db => db.Albums.ExistsByGenreId(1));

            ExampleRunner.RunQuery(
                "Albums.ExistsBy(GenreId :1)",
                db => db.Albums.ExistsBy(GenreId: 1));

            ExampleRunner.RunQuery(
                "Albums.ExistsByGenreIdAndArtistId(1, 120)",
                db => db.Albums.ExistsByGenreIdAndArtistId(1, 120));

            ExampleRunner.RunQuery(
                "Albums.ExistsBy(GenreId: 1, ArtistId: 120)",
                db => db.Albums.ExistsBy(GenreId: 1, ArtistId: 120));
        }
    }
}