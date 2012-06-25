namespace SimpleDataSample
{
  class ColumnSelectionSamples
  {
    internal void RunAll()
    {
      ExampleRunner.QueryAlbums(
            "Get all AlbumIds and Titles in the Album table",
            db => db.Albums.All()
              .Select(
                db.Albums.AlbumId,
                db.Albums.Title)
            );

      ExampleRunner.QueryAlbums(
            "Get all AlbumIds and Titles in the Album table including schema name in column ids",
            db => db.Albums.All()
              .Select(
                db.dbo.Albums.AlbumId,
                db.dbo.Albums.Title)
            );

      ExampleRunner.QueryAlbums(
            "Get all AlbumIds and Titles in the Album table using FindAllByGenreId(1)",
            db => db.Albums.FindAllByGenreId(1)
              .Select(
                db.dbo.Albums.AlbumId,
                db.dbo.Albums.Title)
            );

      ExampleRunner.QueryAlbums(
      "Get all AlbumIds and Titles in the Album table using FindAll(db.Albums.GenreId == 1)",
      db => db.Albums.FindAll(db.Albums.GenreId == 1)
        .Select(
          db.dbo.Albums.AlbumId,
          db.dbo.Albums.Title)
      );

      ExampleRunner.QueryAlbums(
          "Run Select by itself without a command to qualify",
          db => db.Albums.Select(
            db.Albums.AlbumId,
            db.Albums.Title));

      ExampleRunner.QueryAlbums(
        "Try to access a data field not included in a Select command",
        db => db.Albums.All()
          .Select(
            db.Albums.AlbumId)
        );

      ExampleRunner.QueryAlbums(
        "Try to select a column that doesn't exist in the table",
        db => db.Albums.All()
          .Select(
            db.Albums.OrderId)
            );

      ExampleRunner.QueryAlbums(
        "Use alias to reference Artist.Name column as 'Title'",
        db => db.Artists.All()
          .Select(
            db.Artists.Name.As("Title")
            ));

      ExampleRunner.QueryAlbums(
        "Give As method a non-string alias",
        db => db.Albums.All()
          .Select(
            db.Albums.AlbumId,
            db.Albums.Title.As(123)
            ));

      ExampleRunner.QueryAlbums(
        "Abuse As method to set one field name to that of another and then access one",
        db => db.Albums.All()
          .Select(
            db.Albums.AlbumId.As("Title"),
            db.Albums.Title)
            );

      ExampleRunner.QueryAlbums(
        "Abuse As method to set two field names to the same value and then access one",
      db => db.Albums.All()
        .Select(
          db.Albums.AlbumId.As("Title"),
          db.Albums.GenreId.As("Title"))
          );

      ExampleRunner.QueryAlbums(
        "Use As method to give column name an alias and then reference its original name",
        db => db.Albums.All()
          .Select(
            db.Albums.AlbumId,
            db.Albums.Title.As("AlbumName"))
            );
    }
  }
}
