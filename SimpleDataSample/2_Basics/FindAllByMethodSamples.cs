namespace SimpleDataSample
{
    internal class FindAllByMethodSamples
    {
        internal void RunAll()
        {
            ExampleRunner.RunQuery(
                "Run FindAllBy with no column names or values. Throws ArgumentException",
                db => db.Albums.FindAllBy());

            ExampleRunner.RunQuery(
                "Run FindAllByGenreId() with no column values. Throws ArgumentException",
                db => db.Albums.FindAllByGenreId());

            ExampleRunner.RunQuery(
                "Run FindAllBy(1) with no column names. Throws ArgumentException",
                db => db.Albums.FindAllBy(1));

            // Throws System.FormatException. Expected BadExpressionException
            ExampleRunner.RunQuery(
                "Albums.FindAllByGenreId(\"a\"). Malformed Simple Expression. Throws System.FormatException",
                db => db.Albums.FindAllByGenreId("a"));

            // Throws System.FormatException. Expected BadExpressionException
            ExampleRunner.RunQuery(
                "Albums.FindAllBy(GenreId:\"a\"). Malformed Simple Expression. Throws System.FormatException",
                db => db.Albums.FindAllBy(GenreId: "a"));

            ExampleRunner.RunQuery(
                "Albums.FindAllByGenreId(null)",
                db => db.Albums.FindAllByGenreId(null));

            ExampleRunner.RunQuery(
                "Albums.FindAllBy(GenreId:null)",
                db => db.Albums.FindAllBy(GenreId: null));

            ExampleRunner.RunQuery(
                "Albums.FindAllByGenreId(1)",
                db => db.Albums.FindAllByGenreId(1));

            ExampleRunner.RunQuery(
                "Albums.FindAllBy(GenreId:1)",
                db => db.Albums.FindAllBy(GenreId: 1));

            ExampleRunner.RunQuery(
                "Albums.FindAllByGenreIdAndArtistId(1,120)",
                db => db.Albums.FindAllByGenreIdAndArtistId(1, 120));

            ExampleRunner.RunQuery(
                "Albums.FindAllBy(GenreId:1,ArtistId:120)",
                db => db.Albums.FindAllBy(GenreId: 1, ArtistId: 120));
        }
    }
}