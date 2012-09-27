namespace SimpleDataSample
{
  class FindAllByMethodSamples
  {
    internal void RunAll()
    {
      ExampleRunner.RunQuery(
          "Run FindAllBy with no column names or values. Throws exception",
          db => db.Albums.FindAllBy());

      ExampleRunner.RunQuery(
        "Run FindAllByGenreId() with no column values. Throws exception",
        db => db.Albums.FindAllByGenreId());

      ExampleRunner.RunQuery(
        "Run FindAllBy(1) with no column names. Throws exception",
        db => db.Albums.FindAllBy(1));

      ExampleRunner.RunQuery(
      "Albums.FindAllByGenreId(null)",
      db => db.Albums.FindAllByGenreId(null));

      ExampleRunner.RunQuery(
        "Albums.FindAllBy(GenreId:null)",
        db => db.Albums.FindAllBy(GenreId:null));

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
