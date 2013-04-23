using System.Collections.Generic;
using System.Text;

namespace SimpleDataSample
{
    internal class HavingMethodSamples
    {
        internal void RunAll()
        {
            ExampleRunner.RunQuery(
                "This works. Select all artist names and count of albums in system",
                db => db.Albums.All()
                    .Select(db.Albums.Artists.Name, db.Albums.AlbumId.Count().As("NumberOfAlbums"))
                    .Having(db.Albums.AlbumId.Count() > 2),
                new List<string> { "Name", "NumberOfAlbums" });

            // Should throw NullReferenceException()
            ExampleRunner.RunQuery(
                "Having() called without base command.",
                db => db.Albums.Having(db.Albums.Price.Avg() == 8.99));

            // Throws MS.CS.RB.RuntimeBinderException. Should throw ArgumentException
            ExampleRunner.RunQuery(
                "Having called with no parameters",
                db => db.Albums.All()
                    .Select(db.Albums.Artists.Name, db.Albums.AlbumId.Count().As("NumberOfAlbums"))
                    .Having(),
                new List<string> { "Name", "NumberOfAlbums" });

            // Throws MS.CS.RB.RuntimeBinderException. Should throw ArgumentException
            ExampleRunner.RunQuery(
                "Having called with invalid SimpleExpression .Having(123)",
                db => db.Albums.All()
                    .Select(db.Albums.Artists.Name, db.Albums.AlbumId.Count().As("NumberOfAlbums"))
                    .Having(123),
                new List<string> { "Name", "NumberOfAlbums" });

            // Throws Simple.Data.Ado.AdoAdapterException
            ExampleRunner.RunQuery(
                "Having called with invalid SimpleExpression. Should use Where() instead .Having(db.Albums.GenreId == 1)",
                db => db.Albums.All()
                    .Select(db.Albums.Artists.Name, db.Albums.AlbumId.Count().As("NumberOfAlbums"))
                    .Having(db.Albums.GenreId == 1),
                new List<string> { "Name", "NumberOfAlbums" });

            // Throws Simple.Data.UnresolvableObjectException
            ExampleRunner.RunQuery(
                "Having called with invalid SimpleExpression as parameter. Field name wrong .Having(db.Albums.NonExistentColumn.Max() > 1)",
                db => db.Albums.All()
                    .Select(db.Albums.Artists.Name, db.Albums.AlbumId.Count().As("NumberOfAlbums"))
                    .Having(db.Albums.NonExistentColumn.Max() > 1),
                new List<string> { "Name", "NumberOfAlbums" });

            // Throws System.InvalidOperationException. Should throw ArgumentException?
            ExampleRunner.RunQuery(
                "Having called with two valid SimpleExpressions as parameters.",
                db => db.Albums.All()
                    .Select(db.Albums.Artists.Name, db.Albums.AlbumId.Count().As("NumberOfAlbums"), db.Albums.Price.Sum().As("TotalCost"))
                    .Having(db.Albums.AlbumId.Count() > 2, db.Albums.Price.Sum() >= 16.99),
                new List<string> { "Name", "NumberOfAlbums", "TotalCost" });

            ExampleRunner.RunQuery(
                "Having called with two valid SimpleExpressions ORed together as one parameter.",
                db => db.Albums.All()
                    .Select(db.Albums.Artists.Name, db.Albums.AlbumId.Count().As("NumberOfAlbums"), db.Albums.Price.Sum().As("TotalCost"))
                    .Having(db.Albums.AlbumId.Count() > 2 || db.Albums.Price.Sum() >= 16.99),
                new List<string> { "Name", "NumberOfAlbums", "TotalCost" });

            // Concatenated using AND.
            ExampleRunner.RunQuery(
                "Having called twice with one valid SimpleExpression each. Should be concatenated with AND.",
                db => db.Albums.All()
                    .Select(db.Albums.Artists.Name, db.Albums.AlbumId.Count().As("NumberOfAlbums"), db.Albums.Price.Sum().As("TotalCost"))
                    .Having(db.Albums.AlbumId.Count() > 2).Having(db.Albums.Price.Sum() >= 16.99),
                new List<string> { "Name", "NumberOfAlbums", "TotalCost" });
        }
    }
}