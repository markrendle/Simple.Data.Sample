namespace SimpleDataSample
{
  class FindAllByMethodSamples
  {
    internal void RunAll()
    {
      ExampleRunner.QueryAlbums(
          "Run FindAllBy with no column names or values. Throws exception",
          db => db.Albums.FindAllBy());

      ExampleRunner.QueryAlbums(
        "Run FindAllByGenreId() with no column values. Throws exception",
        db => db.Albums.FindAllByGenreId());

      ExampleRunner.QueryAlbums(
        "Run FindAllBy(1) with no column names. Throws exception",
        db => db.Albums.FindAllBy(1));

      ExampleRunner.QueryAlbums(
      "Albums.FindAllByGenreId(null)",
      db => db.Albums.FindAllByGenreId(null));

      ExampleRunner.QueryAlbums(
        "Albums.FindAllBy(GenreId:null)",
        db => db.Albums.FindAllBy(GenreId:null));

      ExampleRunner.QueryAlbums(
          "Albums.FindAllByGenreId(1)",
          db => db.Albums.FindAllByGenreId(1));

      ExampleRunner.QueryAlbums(
          "Albums.FindAllBy(GenreId:1)",
          db => db.Albums.FindAllBy(GenreId: 1));

      ExampleRunner.QueryAlbums(
          "Albums.FindAllByGenreIdAndArtistId(1,120)",
          db => db.Albums.FindAllByGenreIdAndArtistId(1, 120));

      ExampleRunner.QueryAlbums(
          "Albums.FindAllBy(GenreId:1,ArtistId:120)",
          db => db.Albums.FindAllBy(GenreId: 1, ArtistId: 120));      
    }
  }
}
