using System.Collections.Generic;
namespace $rootnamespace$
{
  class NaturalJoinSamples
  {
    internal void RunAll()
    {
      ExampleRunner.RunQuery(
      "Implicit Inner Join between two tables: albums and genre",
      db => db.Albums.FindAllByGenreId(1)
        .Select(
          db.Albums.Title,
          db.Albums.Genre.Name),
          new List<string> { "Title", "Name" });

      ExampleRunner.RunQuery(
      "Implicit Inner Join between three tables: orderDetails, albums and genre",
      db => db.OrderDetails.FindAllByOrderId(1)
        .Select(
          db.OrderDetails.OrderId,
          db.OrderDetails.Albums.Title,
          db.OrderDetails.Albums.Genre.Name),
          new List<string> { "Title", "Name" });

      ExampleRunner.RunQuery(
        "Implicit 1:n Join between two tables: genre and albums",
        db => db.Genre.FindAllByGenreId(1)
          .Select(
            db.Genre.Name,
            db.Genre.Albums.Title),
            new List<string> { "Name", "Title" });

      ExampleRunner.RunQuery(
        "Implicit m:n Join between two tables: order and albums",
        db => db.Orders.FindAllByOrderId(4)
          .Select(
            db.Orders.OrderId,
            db.Orders.OrderDetails.Albums.Title),
            new List<string> { "OrderId", "Title" });
    }
  }
}
