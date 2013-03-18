namespace SimpleDataSample
{
    internal class ColumnSelectionSamples
    {
        internal void RunAll()
        {
            // select count(*) from OrderDetails using .Star().Count()
            ExampleRunner.RunQuery(
                "select * from Albums using db.Albums.Star()",
                db => db.Albums.All()
                        .Select(
                            db.Albums.Star()));

            // select count(*) from OrderDetails using .Star().Count()
            ExampleRunner.RunQuery(
                "select * from Albums using db.Albums.AllColumns()",
                db => db.Albums.All()
                        .Select(
                            db.Albums.AllColumns()));


            ExampleRunner.RunQuery(
                "Use indexer syntax: Get all AlbumIds and Titles in the Album table",
                db => db["Albums"].All()
                                  .Select(
                                      db["Albums"]["AlbumId"],
                                      db["Albums"]["Title"])
                );

            ExampleRunner.RunQuery(
                "Get all AlbumIds and Titles in the Album table",
                db => db.Albums.All()
                        .Select(
                            db.Albums.AlbumId,
                            db.Albums.Title)
                );

            ExampleRunner.RunQuery(
                "Get all AlbumIds and Titles in the Album table including schema name in column ids",
                db => db.Albums.All()
                        .Select(
                            db.dbo.Albums.AlbumId,
                            db.dbo.Albums.Title)
                );

            ExampleRunner.RunQuery(
                "Get all AlbumIds and Titles in the Album table using FindAllByGenreId(1)",
                db => db.Albums.FindAllByGenreId(1)
                        .Select(
                            db.dbo.Albums.AlbumId,
                            db.dbo.Albums.Title)
                );

            ExampleRunner.RunQuery(
                "Get all AlbumIds and Titles in the Album table using FindAll(db.Albums.GenreId == 1)",
                db => db.Albums.FindAll(db.Albums.GenreId == 1)
                        .Select(
                            db.dbo.Albums.AlbumId,
                            db.dbo.Albums.Title)
                );

            ExampleRunner.RunQuery(
                "Run Select by itself without a command to qualify",
                db => db.Albums.Select(
                    db.Albums.AlbumId,
                    db.Albums.Title));

            ExampleRunner.RunQuery(
                "Try to access a data field not included in a Select command",
                db => db.Albums.All()
                        .Select(
                            db.Albums.AlbumId)
                );

            ExampleRunner.RunQuery(
                "Try to select a column that doesn't exist in the table",
                db => db.Albums.All()
                        .Select(
                            db.Albums.OrderId)
                );

            ExampleRunner.RunQuery(
                "Use alias to reference Artist.Name column as 'Title'",
                db => db.Artists.All()
                        .Select(
                            db.Artists.Name.As("Title")
                          ));

            ExampleRunner.RunQuery(
                "Give As method a non-string alias",
                db => db.Albums.All()
                        .Select(
                            db.Albums.AlbumId,
                            db.Albums.Title.As(123)
                          ));

            ExampleRunner.RunQuery(
                "Abuse As method to set one field name to that of another and then access one",
                db => db.Albums.All()
                        .Select(
                            db.Albums.AlbumId.As("Title"),
                            db.Albums.Title)
                );

            ExampleRunner.RunQuery(
                "Abuse As method to set two field names to the same value and then access one",
                db => db.Albums.All()
                        .Select(
                            db.Albums.AlbumId.As("Title"),
                            db.Albums.GenreId.As("Title"))
                );

            ExampleRunner.RunQuery(
                "Use As method to give column name an alias and then reference its original name",
                db => db.Albums.All()
                        .Select(
                            db.Albums.AlbumId,
                            db.Albums.Title.As("AlbumName"))
                );
        }
    }
}