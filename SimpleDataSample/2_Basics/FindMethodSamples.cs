namespace SimpleDataSample
{
  class FindMethodSamples
  {
    internal void RunAll()
    {
      ExampleRunner.QueryAlbums(
        "Run Find with no arguments. Returns null",
        db => db.Albums.Find());

      ExampleRunner.QueryAlbums(
        "Run Find(db.Albums.GenreId) - just the column name. Returns null",
        db => db.Albums.Find(db.Albums.GenreId));

      ExampleRunner.QueryAlbums(
        "Run Find(1) - no column names. Returns null",
        db => db.Albums.Find(1));

      ExampleRunner.QueryAlbums(
        "Albums.Find(db.Albums.GenreId = null). Malformed Simple Expression. Throws Exception",
        db => db.Albums.Find(db.Albums.GenreId = null));

      ExampleRunner.QueryAlbums(
          "Albums.Find(db.Albums.GenreId == \"a\"). Malformed Simple Expression. Throws Exception",
          db => db.Albums.Find(db.Albums.GenreId == "a"));

      ExampleRunner.QueryAlbums(
        "Albums.Find(db.Albums.GenreId != null).",
        db => db.Albums.Find(db.Albums.GenreId != null));

      ExampleRunner.QueryAlbums(
          "Albums.Find(db.Albums.GenreId == 1)",
          db => db.Albums.Find(db.Albums.GenreId == 1));

      ExampleRunner.QueryAlbums(
          "Albums.Find(db.Albums.GenreId > 3)",
          db => db.Albums.Find(db.Albums.GenreId > 3));

      ExampleRunner.QueryAlbums(
          "Albums.Find(db.Albums.GenreId == 1 && db.Albums.ArtistId == 120)",
          db => db.Albums.Find(db.Albums.GenreId == 1 && db.Albums.ArtistId == 120));

      ExampleRunner.QueryAlbums(
          "Albums.Find(db.Albums.GenreId == 1 & db.Albums.ArtistId == 120)",
          db => db.Albums.Find(db.Albums.GenreId == 1 & db.Albums.ArtistId == 120));

      ExampleRunner.QueryAlbums(
          "Albums.Find(db.Albums.GenreId == 2 || db.Albums.ArtistId == 160)",
          db => db.Albums.Find(db.Albums.GenreId == 2 || db.Albums.ArtistId == 160));

      ExampleRunner.QueryAlbums(
          "Albums.Find(db.Albums.GenreId == 2 | db.Albums.ArtistId == 160)",
          db => db.Albums.Find(db.Albums.GenreId == 2 | db.Albums.ArtistId == 160));

      ExampleRunner.QueryAlbums(
          "Albums.Find(db.Albums.GenreId == 1, db.Albums.ArtistId == 120). Returns null as only one SimpleExpression allowed in Find",
          db => db.Albums.Find(db.Albums.GenreId == 1, db.Albums.ArtistId == 120));
    }
  }
}
