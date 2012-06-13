namespace SimpleDataSample
{
  class FindAllMethodSamples
  {
    internal void RunAll()
    {
      ExampleRunner.QueryAlbums(
        "Run FindAll with no arguments. Returns null",
        db => db.Albums.FindAll());

      ExampleRunner.QueryAlbums(
        "Run FindAll(db.Albums.GenreId) - just the column name. Returns null",
        db => db.Albums.FindAll(db.Albums.GenreId));

      ExampleRunner.QueryAlbums(
        "Run FindAll(1) - no column names. Returns null",
        db => db.Albums.FindAll(1));

      ExampleRunner.QueryAlbums(
        "Albums.FindAll(db.Albums.GenreId = null). Malformed Simple Expression. Throws Exception",
        db => db.Albums.FindAll(db.Albums.GenreId = null));

      ExampleRunner.QueryAlbums(
          "Albums.FindAll(db.Albums.GenreId == \"a\"). Malformed Simple Expression. Throws Exception",
          db => db.Albums.FindAll(db.Albums.GenreId == "a"));

      ExampleRunner.QueryAlbums(
        "Albums.FindAll(db.Albums.GenreId != null).",
        db => db.Albums.FindAll(db.Albums.GenreId != null));

      ExampleRunner.QueryAlbums(
          "Albums.FindAll(db.Albums.GenreId == 1)",
          db => db.Albums.FindAll(db.Albums.GenreId == 1));

      ExampleRunner.QueryAlbums(
          "Albums.FindAll(db.Albums.GenreId > 3)",
          db => db.Albums.FindAll(db.Albums.GenreId > 3));

      ExampleRunner.QueryAlbums(
          "Albums.FindAll(db.Albums.GenreId == 1 && db.Albums.ArtistId == 120)",
          db => db.Albums.FindAll(db.Albums.GenreId == 1 && db.Albums.ArtistId == 120));

      ExampleRunner.QueryAlbums(
          "Albums.FindAll(db.Albums.GenreId == 1 & db.Albums.ArtistId == 120)",
          db => db.Albums.FindAll(db.Albums.GenreId == 1 & db.Albums.ArtistId == 120));

      ExampleRunner.QueryAlbums(
          "Albums.FindAll(db.Albums.GenreId == 2 || db.Albums.ArtistId == 160)",
          db => db.Albums.FindAll(db.Albums.GenreId == 2 || db.Albums.ArtistId == 160));

      ExampleRunner.QueryAlbums(
          "Albums.FindAll(db.Albums.GenreId == 2 | db.Albums.ArtistId == 160)",
          db => db.Albums.FindAll(db.Albums.GenreId == 2 | db.Albums.ArtistId == 160));

      ExampleRunner.QueryAlbums(
          "Albums.FindAll(db.Albums.GenreId == 1, db.Albums.ArtistId == 120). Returns null as only one SimpleExpression allowed in FindAll",
          db => db.Albums.FindAll(db.Albums.GenreId == 1, db.Albums.ArtistId == 120));
    }
  }
}
