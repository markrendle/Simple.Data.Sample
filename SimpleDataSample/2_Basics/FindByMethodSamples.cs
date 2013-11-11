using System;
namespace SimpleDataSample
{
    internal class FindByMethodSamples
    {
        internal void RunAll()
        {
            Console.WriteLine("FindBy is now deprecated in favour of using FindAllBy.FirstOrDefault() or Get.");

            ExampleRunner.RunQuery(
                "Run FindBy with no arguments. Throws ArgumentException",
                db => db.Albums.FindBy());

            ExampleRunner.RunQuery(
                "Run FindByGenreId() with no parameters. Throws ArgumentException",
                db => db.Albums.FindByGenreId());

            ExampleRunner.RunQuery(
                "Run FindBy(1) with no parameters. Throws ArgumentException",
                db => db.Albums.FindBy(1));

            ExampleRunner.RunQuery(
                "Albums.FindByGenreId(null).",
                db => db.Albums.FindByGenreId(null));

            ExampleRunner.RunQuery(
                "Albums.FindBy(GenreId:null).",
                db => db.Albums.FindBy(GenreId: null));

            ExampleRunner.RunQuery(
                "Albums.FindByGenreId(1)",
                db => db.Albums.FindByGenreId(1));

            ExampleRunner.RunQuery(
                "Albums.FindBy(GenreId:1)",
                db => db.Albums.FindBy(GenreId: 1));

            ExampleRunner.RunQuery(
                "Albums.FindByGenreIdAndArtistId(1,120)",
                db => db.Albums.FindByGenreIdAndArtistId(1, 120));

            ExampleRunner.RunQuery(
                "Albums.FindBy(GenreId:1,ArtistId:120)",
                db => db.Albums.FindBy(GenreId: 1, ArtistId: 120));
        }
    }
}