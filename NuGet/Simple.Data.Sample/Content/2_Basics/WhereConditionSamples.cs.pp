namespace $rootnamespace$
{
  using Simple.Data;
  using System;
using System.Data.SqlTypes;

  class WhereConditionSamples
  {
    internal void RunAll()
    {
      ExampleRunner.QueryAlbums(
            "Comparison Operators. 1.Equals : Where(db.Albums.ArtistId == 120)",
            db => db.Albums.All().Where(db.Albums.ArtistId == 120));

      ExampleRunner.QueryAlbums(
            "Comparison Operators. 2.Not Equals : Where(db.Albums.GenreId != 1)",
            db => db.Albums.All().Where(db.Albums.GenreId != 1));

      ExampleRunner.QueryAlbums(
            "Comparison Operators. 3.Less Than : Where(db.Albums.Price < 8.99)",
            db => db.Albums.All().Where(db.Albums.Price < 8.99));

      ExampleRunner.QueryAlbums(
            "Comparison Operators. 4.Less Than Or Equals : Where(db.Albums.Price <= 8.99)",
            db => db.Albums.All().Where(db.Albums.Price <= 8.99));

      ExampleRunner.QueryAlbums(
            "Comparison Operators. 5.Greater Than : Where(db.Albums.Price > 7.99)",
            db => db.Albums.All().Where(db.Albums.Price > 7.99));

      ExampleRunner.QueryAlbums(
            "Comparison Operators. 6.Greaer Than Or Equals : Where(db.Albums.Price >= 7.99)",
            db => db.Albums.All().Where(db.Albums.Price >= 7.99));

      ExampleRunner.QueryAlbums(
          "Math Operators. 1.Add : Where(db.Albums.AlbumId + db.Albums.ArtistId > 120)",
          db => db.Albums.All().Where(db.Albums.AlbumId + db.Albums.ArtistId > 120));

      ExampleRunner.QueryAlbums(
          "Math Operators. 2.Subtract : Where(db.Albums.AlbumId - db.Albums.ArtistId < 130)",
          db => db.Albums.All().Where(db.Albums.AlbumId - db.Albums.ArtistId < 130));

      ExampleRunner.QueryAlbums(
        "Math Operators. 3. Multiply : Where(db.OrderDetails.Quantity * db.OrderDetails.UnitPrice >= 50)",
        db => db.Albums.All().Where(db.OrderDetails.Quantity * db.OrderDetails.UnitPrice >= 50));

      ExampleRunner.QueryAlbums(
        "Math Operators. 4.Divide : Where(db.OrderDetails.UnitPrice / db.OrderDetails.Quantity <= 3)",
        db => db.Albums.All().Where(db.OrderDetails.UnitPrice / db.OrderDetails.Quantity <= 3));

      ExampleRunner.QueryAlbums(
        "Math Operators. 5.Modulo : Where(db.OrderDetails.UnitPrice % db.OrderDetails.Quantity != 4)",
        db => db.Albums.All().Where(db.OrderDetails.UnitPrice % db.OrderDetails.Quantity != 4));

      ExampleRunner.QueryAlbums(
        "Using LIKE : Where(db.Albums.Title.Like(\"%Side Of The%\")",
        db => db.Albums.All().Where(db.Albums.Title.Like("%Side Of The%")));

      ExampleRunner.QueryAlbums(
          "Using NOT LIKE : Where(db.Albums.Title.NotLike(\"%a%\")",
          db => db.Albums.All().Where(db.Albums.Title.NotLike("%a%")));

      ExampleRunner.QueryAlbums(
        "Using IN. 1.Embedded : db.Albums.FindAllByTitle(new[] {\"Nevermind\", \"Ten\"})",
        db => db.Albums.FindAllByTitle(new []{"Nevermind", "Ten"}));

      ExampleRunner.QueryAlbums(
        "Using IN. 2.In FindAll : db.Albums.FindAll(db.Albums.Title == new[] {\"Nevermind\", \"Ten\"})",
        db => db.Albums.FindAll(db.Albums.Title == new[] {"Nevermind", "Ten" }));

      ExampleRunner.QueryAlbums(
        "Using IN. 3.In Where method : db.Albums.All().Where(db.Albums.Title == new[] {\"Nevermind\", \"Ten\"})",
        db => db.Albums.All().Where(db.Albums.Title == new[] {"Nevermind", "Ten"}));

      ExampleRunner.QueryAlbums(
        "Using NOT IN. 1.In FindAll : db.Albums.FindAll(db.Albums.GenreId != new[] {1,3,7})",
        db => db.Albums.FindAll(db.Albums.GenreId != new[] { 1, 3, 7 }));

      ExampleRunner.QueryAlbums(
        "Using NOT IN. 2.In Where method : db.Albums.All().Where(db.Albums.GenreId != new[] {1,3,7})",
        db => db.Albums.All().Where(db.Albums.GenreId != new[] { 1, 3, 7 }));

      ExampleRunner.QueryAlbums(
          "Using BETWEEN. 1. Embedded : db.Albums.FindAllByAlbumId(400.to(410))",
          db => db.Albums.FindAllByAlbumId(400.to(410)));

      ExampleRunner.QueryAlbums(
        "Using BETWEEN. 2. In FIndAll : db.Albums.FindAll(db.Albums.AlbumId == 400.to(410))",
        db => db.Albums.FindAll(db.Albums.AlbumId == 400.to(410)));

      ExampleRunner.QueryAlbums(
        "Using BETWEEN. 3. In Where : db.Albums.All().Where(db.Albums.AlbumId == 400.to(410))",
        db => db.Albums.All().Where(db.Albums.AlbumId == 400.to(410)));

      ExampleRunner.QueryAlbums(
        "Using NOT BETWEEN. 1. In FindAll : db.Orders.FindAll(db.Orders.OrderDate != DateTime.MinValue.to(DateTime.Now))",
        db => db.Orders.FindAll(db.Orders.OrderDate != SqlDateTime.MinValue.Value.to(DateTime.Now)));

      ExampleRunner.QueryAlbums(
        "Using NOT BETWEEN. 2. In Where : db.Orders.All().Where(db.Orders.OrderDate != DateTime.MinValue.to(DateTime.Now))",
        db => db.Orders.All().Where(db.Orders.OrderDate != SqlDateTime.MinValue.Value.to(DateTime.Now)));

      ExampleRunner.RunQuery(
        "Using IS NULL. 1. Embedded : db.Albums.FindAllByGenreId(null);",
        db => db.Albums.FindAllByGenreId(null));

      ExampleRunner.RunQuery(
        "Using IS NULL. 2. Embedded : db.Albums.FindAllBy(GenreId:null);",
        db => db.Albums.FindAllBy(GenreId:null));

      ExampleRunner.RunQuery(
        "Using IS NULL. 3. In FindAll : db.Albums.FindAll(db.Albums.GenreId == null);",
        db => db.Albums.FindAll(db.Albums.GenreId == null));

      ExampleRunner.RunQuery(
        "Using IS NULL. 4. In Where : db.Albums.All().Where(db.Albums.GenreId == null);",
        db => db.Albums.All().Where(db.Albums.GenreId == null));


      ExampleRunner.RunQuery(
        "Using IS NOT NULL. 1. In FindAll : db.Albums.FindAll(db.Albums.GenreId != null);",
        db => db.Albums.FindAll(db.Albums.GenreId != null));

      ExampleRunner.RunQuery(
        "Using IS NOT NULL. 2. In Where : db.Albums.All().Where(db.Albums.GenreId != null);",
        db => db.Albums.All().Where(db.Albums.GenreId != null));
    }
  }
}
