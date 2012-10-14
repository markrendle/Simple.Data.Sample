using System.Collections.Generic;
namespace $rootnamespace$
{
  class LeftJoinSamples
  {
    internal void RunAll()
    {
      #region Valid calls
      ExampleRunner.RunQuery(
        "Explicit LeftJoin between two tables using LeftJoin only (before Select method)",
        db => db.Albums.FindAllByGenreId(1)
        .LeftJoin(db.Genre, GenreId: db.Albums.GenreId)
        .Select(
        db.Albums.Title,
        db.Genre.Name),
        new List<string> { "Title", "Name" });

      ExampleRunner.RunQuery(
        "Explicit LeftJoin between two tables using LeftJoin only (after Select method)",
        db => db.Albums.FindAllByGenreId(1)
          .Select(
            db.Albums.Title,
            db.Genre.Name)
          .LeftJoin(db.Genre, GenreId: db.Albums.GenreId),
            new List<string> { "Title", "Name" });

      ExampleRunner.RunQuery(
        "Explicit LeftJoin between two tables using LeftJoin and On",
        db => db.Albums.FindAllByGenreId(1)
          .Select(
            db.Albums.Title,
            db.Genre.Name)
          .LeftJoin(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId),
            new List<string> { "Title", "Name" });

      ExampleRunner.RunQuery(
        "Explicit LeftJoin between two tables using LeftJoin only (indexer style)",
        db => db.Albums.FindAllByGenreId(1)
        .Select(
          db["Albums"]["Title"],
          db["Genre"]["Name"])
        .LeftJoin(db["Genre"], GenreId: db["Albums"]["GenreId"]),
        new List<string> { "Title", "Name" });



      ExampleRunner.RunQuery(
      "Explicit Inner LeftJoin between three tables: orderDetails, albums and genre",
      db => db.OrderDetails.FindAllByOrderId(1)
        .Select(
          db.OrderDetails.OrderId,
          db.OrderDetails.Albums.Title,
          db.OrderDetails.Albums.Genre.Name)
        .LeftJoin(db.Albums, AlbumId: db.OrderDetails.AlbumId)
        .LeftJoin(db.Genre, GenreId: db.Albums.GenreId),
        new List<string> { "Title", "Name" });


      ExampleRunner.RunQuery(
        "Explicit LeftJoin between two tables using LeftJoin only and aliases using expression in the On clause",
        db => TwoTableLeftJoinWithAliasUsingExpressions(db),
            new List<string> { "Title", "Name" });

      ExampleRunner.RunQuery(
        "Explicit LeftJoin between two tables using LeftJoin only and aliases using named parameters in the On clause",
        db => TwoTableLeftJoinWithAliasUsingNamedParameters(db),
        new List<string> { "Title", "Name" });

      ExampleRunner.RunQuery(
      "Explicit Inner LeftJoin between three tables: orderDetails, albums and genre",
      db => db.OrderDetails.FindAllByOrderId(1)
        .Select(
          db.OrderDetails.OrderId,
          db.OrderDetails.Albums.Title,
          db.OrderDetails.Albums.Genre.Name)
        .LeftJoin(db.Albums, AlbumId: db.OrderDetails.AlbumId)
        .LeftJoin(db.Genre, GenreId: db.Albums.GenreId),
        new List<string> { "Title", "Name" });
      #endregion

      #region Invalid Calls

      //Throws NullReferenceException
      ExampleRunner.RunQuery(
        "Explicit LeftJoin between two tables using LeftJoin only (trying to LeftJoin the wrong table. Throws NullReferenceException)",
        db => db.Albums.FindAllByGenreId(1)
        .Select(
        db.Albums.Title,
        db.Genre.Name)
        .LeftJoin(db.Albums, GenreId: db.Genre.GenreId),
        new List<string> { "Title", "Name" });

      //Throws NullReferenceException
      ExampleRunner.RunQuery(
"Explicit LeftJoin between two tables using LeftJoin only (target table key column name doesn't exist. )",
db => db.Albums.FindAllByGenreId(1)
.Select(
db.Albums.Title,
db.Genre.Name)
.LeftJoin(db.Genre, NotPresent: db.Albums.GenreId),
new List<string> { "Title", "Name" });

      //Throws NullReferenceException
      ExampleRunner.RunQuery(
"Explicit LeftJoin between two tables using LeftJoin only (start table key column name doesn't exist.)",
db => db.Albums.FindAllByGenreId(1)
.Select(
db.Albums.Title,
db.Genre.Name)
.LeftJoin(db.Genre, GenreId: db.Albums.NotPresent),
new List<string> { "Title", "Name" });

      //Throws NullReferenceException
      ExampleRunner.RunQuery(
"Explicit LeftJoin between two tables using LeftJoin only (key column types don't match). Throws NullReferenceException",
db => db.Albums.FindAllByGenreId(1)
.Select(
db.Albums.Title,
db.Genre.Name)
.LeftJoin(db.Genre, GenreId: db.Albums.Title),
new List<string> { "Title", "Name" });

      // Throws System.InvalidOperationException
      ExampleRunner.RunQuery(
"Explicit LeftJoin between two tables using LeftJoin and On. On not immediately after LeftJoin. Throws InvalidOperationException",
db => db.Albums.FindAllByGenreId(1)
  .LeftJoin(db.Genre)
  .Select(
    db.Albums.Title,
    db.Genre.Name)
  .On(db.Genre.GenreId == db.Albums.GenreId),
    new List<string> { "Title", "Name" });

      // Throws IndexOutOfRangeException
      ExampleRunner.RunQuery(
"Run LeftJoin with no arguments",
db => db.Albums.FindAllByGenreId(1)
.LeftJoin()
.Select(
db.Albums.Title,
db.Genre.Name),
new List<string> { "Title", "Name" });

      // Throws Simple.Data.Ado.AdapterException
      // The multi-part identifier "dbo.Genres.Name" could not be bound.
      ExampleRunner.RunQuery(
"Run LeftJoin with only targetTable named",
db => db.Albums.FindAllByGenreId(1)
.LeftJoin(db.Genre)
.Select(
db.Albums.Title,
db.Genre.Name),
new List<string> { "Title", "Name" });

      // Throws Simple.Data.Ado.AdapterException
      // The multi-part identifier "dbo.Genres.Name" could not be bound.
      ExampleRunner.RunQuery(
"Run LeftJoin with only targetTable and column named wrongly",
db => db.Albums.FindAllByGenreId(1)
.LeftJoin(db.Genre.GenreId)
.Select(
db.Albums.Title,
db.Genre.Name),
new List<string> { "Title", "Name" });

      // Throws Simple.Data.Ado.AdapterException
      // The multi-part identifier "dbo.Genres.Name" could not be bound.
      ExampleRunner.RunQuery(
"Run LeftJoin with only startTable and column named",
db => db.Albums.FindAllByGenreId(1)
.LeftJoin(db.Albums.GenreId)
.Select(
db.Albums.Title,
db.Genre.Name),
new List<string> { "Title", "Name" });

      //System.ArgumentOutOfRangeException
      //Index was out of range. Must be non-negative and less than the size of the collection.
      //Parameter name: index
      ExampleRunner.RunQuery(
"Run LeftJoin with no arguments for LeftJoin or On",
db => db.Albums.FindAllByGenreId(1)
.Select(
db.Albums.Title,
db.Genre.Name)
.LeftJoin(db.Genre)
.On(),
new List<string> { "Title", "Name" });

      //System.ArgumentOutOfRangeException
      //Index was out of range. Must be non-negative and less than the size of the collection.
      //Parameter name: index
      ExampleRunner.RunQuery(
"Run LeftJoin with no arguments for On",
db => db.Albums.FindAllByGenreId(1)
.Select(
db.Albums.Title,
db.Genre.Name)
.LeftJoin(db.Genre)
.On(),
new List<string> { "Title", "Name" });

      //System.ArgumentOutOfRangeException
      //Index was out of range. Must be non-negative and less than the size of the collection.
      //Parameter name: index
      ExampleRunner.RunQuery(
"Run LeftJoin with just column name as argument for On",
db => db.Albums.FindAllByGenreId(1)
.Select(
db.Albums.Title,
db.Genre.Name)
.LeftJoin(db.Genre)
.On(db.Albums.GenreId),
new List<string> { "Title", "Name" });

      //System.ArgumentOutOfRangeException
      //Index was out of range. Must be non-negative and less than the size of the collection.
      //Parameter name: index
      ExampleRunner.RunQuery(
"Run LeftJoin with just literal as argument for On",
db => db.Albums.FindAllByGenreId(1)
.Select(
db.Albums.Title,
db.Genre.Name)
.LeftJoin(db.Genre)
.On(true),
new List<string> { "Title", "Name" });


      ExampleRunner.RunQuery(
"Run LeftJoin with simpleexpression for On but not between two columns",
db => db.Albums.FindAllByGenreId(1)
.Select(
db.Albums.Title,
db.Genre.Name)
.LeftJoin(db.Genre)
.On(db.Albums.GenreId == null),
new List<string> { "Title", "Name" });

      //Microsoft.CSharp.RuntimeBinder.RuntimeBinderException
      //'Simple.Data.DynamicTable' does not contain a definition for 'GenreId'
      ExampleRunner.RunQuery(
"Run LeftJoin with malformed simpleexpression for On",
db => db.Albums.FindAllByGenreId(1)
.Select(
db.Albums.Title,
db.Genre.Name)
.LeftJoin(db.Genre)
.On(db.Albums.GenreId = db.Genre.GenreId),
new List<string> { "Title", "Name" });

      #endregion

    }

    private static dynamic TwoTableLeftJoinWithAliasUsingExpressions(dynamic db)
    {
      dynamic GenreAlias;
      return db.Albums.FindAllByGenreId(1)
        .LeftJoin(db.Genre.As("g"), out GenreAlias).On(GenreAlias.GenreId == db.Albums.GenreId)
        .Select(
          db.Albums.Title,
          GenreAlias.Name)
;
    }

    private static dynamic TwoTableLeftJoinWithAliasUsingNamedParameters(dynamic db)
    {
      dynamic GenreAlias;
      return db.Albums.FindAllByGenreId(1)
        .LeftJoin(db.Genre.As("g"), out GenreAlias).On(GenreId: db.Albums.GenreId)
        .Select(
          db.Albums.Title,
          GenreAlias.Name);
    }


  }
}
