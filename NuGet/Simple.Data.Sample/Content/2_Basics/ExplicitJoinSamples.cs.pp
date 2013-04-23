using System.Collections.Generic;

namespace $rootnamespace$
{
    internal class ExplicitJoinSamples
    {
        internal void RunAll()
        {
            #region Valid calls

            ExampleRunner.RunQuery(
                "Explicit Join between two tables using Join only (before Select method)",
                db => db.Albums.FindAllByGenreId(1)
                        .Join(db.Genre, GenreId: db.Albums.GenreId)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name),
                new List<string> {"Title", "Name"});

            ExampleRunner.RunQuery(
                "Explicit Join between two tables using Join only (after Select method)",
                db => db.Albums.FindAllByGenreId(1)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .Join(db.Genre, GenreId: db.Albums.GenreId),
                new List<string> {"Title", "Name"});

            ExampleRunner.RunQuery(
                "Explicit Join between two tables using Join and On",
                db => db.Albums.FindAllByGenreId(1)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .Join(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId),
                new List<string> {"Title", "Name"});

            ExampleRunner.RunQuery(
                "Explicit Join between two tables using Join only (indexer style)",
                db => db.Albums.FindAllByGenreId(1)
                        .Select(
                            db["Albums"]["Title"],
                            db["Genre"]["Name"])
                        .Join(db["Genre"], GenreId: db["Albums"]["GenreId"]),
                new List<string> {"Title", "Name"});


            ExampleRunner.RunQuery(
                "Explicit Inner Join between three tables: orderDetails, albums and genre",
                db => db.OrderDetails.FindAllByOrderId(1)
                        .Select(
                            db.OrderDetails.OrderId,
                            db.OrderDetails.Albums.Title,
                            db.OrderDetails.Albums.Genre.Name)
                        .Join(db.Albums, AlbumId: db.OrderDetails.AlbumId)
                        .Join(db.Genre, GenreId: db.Albums.GenreId),
                new List<string> {"Title", "Name"});


            ExampleRunner.RunQuery(
                "Explicit Join between two tables using Join only and aliases using expression in the On clause",
                db => TwoTableJoinWithAliasUsingExpressions(db),
                new List<string> {"Title", "Name"});

            ExampleRunner.RunQuery(
                "Explicit Join between two tables using Join only and aliases using named parameters in the On clause",
                db => TwoTableJoinWithAliasUsingNamedParameters(db),
                new List<string> {"Title", "Name"});

            ExampleRunner.RunQuery(
                "Explicit Inner Join between three tables: orderDetails, albums and genre",
                db => db.OrderDetails.FindAllByOrderId(1)
                        .Select(
                            db.OrderDetails.OrderId,
                            db.OrderDetails.Albums.Title,
                            db.OrderDetails.Albums.Genre.Name)
                        .Join(db.Albums, AlbumId: db.OrderDetails.AlbumId)
                        .Join(db.Genre, GenreId: db.Albums.GenreId),
                new List<string> {"Title", "Name"});

            #endregion

            #region Invalid Calls

            //Throws NullReferenceException
            ExampleRunner.RunQuery(
                "Explicit Join between two tables using Join only (trying to join the wrong table)",
                db => db.Albums.FindAllByGenreId(1)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .Join(db.Albums, GenreId: db.Genre.GenreId),
                new List<string> {"Title", "Name"});

            ExampleRunner.RunQuery(
                "Explicit Join between two tables using Join only (target table key column name doesn't exist)",
                db => db.Albums.FindAllByGenreId(1)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .Join(db.Genre, NotPresent: db.Albums.GenreId),
                new List<string> {"Title", "Name"});

            ExampleRunner.RunQuery(
                "Explicit Join between two tables using Join only (start table key column name doesn't exist)",
                db => db.Albums.FindAllByGenreId(1)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .Join(db.Genre, GenreId: db.Albums.NotPresent),
                new List<string> {"Title", "Name"});

            ExampleRunner.RunQuery(
                "Explicit Join between two tables using Join only (key column types don't match)",
                db => db.Albums.FindAllByGenreId(1)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .Join(db.Genre, GenreId: db.Albums.Title),
                new List<string> {"Title", "Name"});

            // Throws System.InvalidOperationException
            ExampleRunner.RunQuery(
                "Explicit Join between two tables using Join and On. On not immediately after Join",
                db => db.Albums.FindAllByGenreId(1)
                        .Join(db.Genre)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .On(db.Genre.GenreId == db.Albums.GenreId),
                new List<string> {"Title", "Name"});

            // Throws IndexOutOfRangeException
            ExampleRunner.RunQuery(
                "Run Join with no arguments",
                db => db.Albums.FindAllByGenreId(1)
                        .Join()
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name),
                new List<string> {"Title", "Name"});

            // Throws Simple.Data.Ado.AdapterException
            // The multi-part identifier "dbo.Genres.Name" could not be bound.
            ExampleRunner.RunQuery(
                "Run Join with only targetTable named",
                db => db.Albums.FindAllByGenreId(1)
                        .Join(db.Genre)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name),
                new List<string> {"Title", "Name"});

            // Throws Simple.Data.Ado.AdapterException
            // The multi-part identifier "dbo.Genres.Name" could not be bound.
            ExampleRunner.RunQuery(
                "Run Join with only targetTable and column named wrongly",
                db => db.Albums.FindAllByGenreId(1)
                        .Join(db.Genre.GenreId)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name),
                new List<string> {"Title", "Name"});

            // Throws Simple.Data.Ado.AdapterException
            // The multi-part identifier "dbo.Genres.Name" could not be bound.
            ExampleRunner.RunQuery(
                "Run Join with only startTable and column named",
                db => db.Albums.FindAllByGenreId(1)
                        .Join(db.Albums.GenreId)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name),
                new List<string> {"Title", "Name"});

            //System.ArgumentOutOfRangeException
            //Index was out of range. Must be non-negative and less than the size of the collection.
            //Parameter name: index
            ExampleRunner.RunQuery(
                "Run Join with no arguments for Join or On",
                db => db.Albums.FindAllByGenreId(1)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .Join(db.Genre)
                        .On(),
                new List<string> {"Title", "Name"});

            //System.ArgumentOutOfRangeException
            //Index was out of range. Must be non-negative and less than the size of the collection.
            //Parameter name: index
            ExampleRunner.RunQuery(
                "Run Join with no arguments for On",
                db => db.Albums.FindAllByGenreId(1)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .Join(db.Genre)
                        .On(),
                new List<string> {"Title", "Name"});

            //System.ArgumentOutOfRangeException
            //Index was out of range. Must be non-negative and less than the size of the collection.
            //Parameter name: index
            ExampleRunner.RunQuery(
                "Run Join with just column name as argument for On",
                db => db.Albums.FindAllByGenreId(1)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .Join(db.Genre)
                        .On(db.Albums.GenreId),
                new List<string> {"Title", "Name"});

            //System.ArgumentOutOfRangeException
            //Index was out of range. Must be non-negative and less than the size of the collection.
            //Parameter name: index
            ExampleRunner.RunQuery(
                "Run Join with just literal as argument for On",
                db => db.Albums.FindAllByGenreId(1)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .Join(db.Genre)
                        .On(true),
                new List<string> {"Title", "Name"});


            ExampleRunner.RunQuery(
                "Run Join with simpleexpression for On but not between two columns",
                db => db.Albums.FindAllByGenreId(1)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .Join(db.Genre)
                        .On(db.Albums.GenreId == null),
                new List<string> {"Title", "Name"});

            //Microsoft.CSharp.RuntimeBinder.RuntimeBinderException
            //'Simple.Data.DynamicTable' does not contain a definition for 'GenreId'
            ExampleRunner.RunQuery(
                "Run Join with malformed simpleexpression for On",
                db => db.Albums.FindAllByGenreId(1)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .Join(db.Genre)
                        .On(db.Albums.GenreId = db.Genre.GenreId),
                new List<string> {"Title", "Name"});

            #endregion
        }

        private static dynamic TwoTableJoinWithAliasUsingExpressions(dynamic db)
        {
            dynamic genreAlias;
            return db.Albums.FindAllByGenreId(1)
                     .Join(db.Genre.As("g"), out genreAlias).On(genreAlias.GenreId == db.Albums.GenreId)
                     .Select(
                         db.Albums.Title,
                         genreAlias.Name)
                ;
        }

        private static dynamic TwoTableJoinWithAliasUsingNamedParameters(dynamic db)
        {
            dynamic genreAlias;
            return db.Albums.FindAllByGenreId(1)
                     .Join(db.Genre.As("g"), out genreAlias).On(GenreId: db.Albums.GenreId)
                     .Select(
                         db.Albums.Title,
                         genreAlias.Name);
        }
    }
}