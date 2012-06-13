namespace SimpleDataSample
{
  class FindByMethodSamples
  {
    internal void RunAll()
    {
      ExampleRunner.QueryAlbums(
        "Run FindBy with no arguments. Throws exception",
        db => db.Albums.FindBy());

      ExampleRunner.QueryAlbums(
        "Run FindByGenreId() with no parameters. Throws exception",
        db => db.Albums.FindByGenreId());

      ExampleRunner.QueryAlbums(
        "Run FindBy(1) with no parameters. Throws exception",
        db => db.Albums.FindBy(1));

      ExampleRunner.QueryAlbums(
      "Albums.FindByGenreId(null).",
      db => db.Albums.FindByGenreId(null));

      ExampleRunner.QueryAlbums(
        "Albums.FindBy(GenreId:null).",
      db => db.Albums.FindBy(GenreId: null));

      ExampleRunner.QueryAlbums(
          "Albums.FindByGenreId(1)", 
          db => db.Albums.FindByGenreId(1));

      ExampleRunner.QueryAlbums(
          "Albums.FindBy(GenreId:1)",
          db => db.Albums.FindBy(GenreId:1));

      ExampleRunner.QueryAlbums(
          "Albums.FindByGenreIdAndArtistId(1,120)",
          db => db.Albums.FindByGenreIdAndArtistId(1, 120));

      ExampleRunner.QueryAlbums(
          "Albums.FindBy(GenreId:1,ArtistId:120)",
          db => db.Albums.FindBy(GenreId: 1, ArtistId: 120));
    }
  }
}
