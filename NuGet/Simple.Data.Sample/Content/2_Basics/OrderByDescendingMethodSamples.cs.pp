using System.Collections.Generic;
namespace $rootnamespace$
{
    internal class OrderByDescendingMethodSamples
    {
        internal void RunAll()
        {
            // Throws NullReferenceException
            ExampleRunner.RunQuery(
                "Run OrderByDescending() without base command or column name.",
                db => db.Albums.OrderByDescending());

            // Runs All.OrderByArtistId()
            ExampleRunner.RunQuery(
                "Run OrderByArtistIdDescending() without base command.",
                db => db.Albums.OrderByArtistIdDescending());

            // Throws NullReferenceException
            ExampleRunner.RunQuery(
                "Run OrderByDescending(db.Albums.ArtistId) without base command.",
                db => db.Albums.OrderByDescending(db.Albums.ArtistId));

            // Throws NullReferenceException
            ExampleRunner.RunQuery(
                "Run All.OrderByDescending() without column name.",
                db => db.Albums.All().OrderByDescending());

            // Runs All.OrderByArtistId()
            ExampleRunner.RunQuery(
                "Run All.OrderByArtistIdDescending().",
                db => db.Albums.All().OrderByArtistIdDescending());

            // Runs All.OrderByArtistId()
            ExampleRunner.RunQuery(
                "Run All.OrderByDescending(db.Albums.ArtistId).",
                db => db.Albums.All().OrderByDescending(db.Albums.ArtistId));

            // Throws NullReferenceException
            ExampleRunner.RunQuery(
                "Run All.OrderByDescending(1) - no column names.",
                db => db.Albums.All().OrderByDescending(1));

            // Runs All.OrderByGenreId()
            ExampleRunner.RunQuery(
                "Run All.OrderByGenreIdDescending(1).",
                db => db.Albums.All().OrderByGenreIdDescending(1));

            // Runs All.OrderByGenreId()
            ExampleRunner.RunQuery(
                "Run All.OrderByGenreIdDescending(db.Albums.Title).",
                db => db.Albums.All().OrderByGenreIdDescending(db.Albums.Title));

            // Throws Ado.AdoAdapterException 
            ExampleRunner.RunQuery(
                "Run All.OrderByDescending(db.Artists.Name) - column not related to query.",
                db => db.Albums.All().OrderByDescending(db.Artists.Name));

            // Throws NullReferenceException
            ExampleRunner.RunQuery(
                "Run All.OrderByDescending(db.Albums.GenreId == 1) - erroneous SimpleExpression.",
                db => db.Albums.All().OrderByDescending(db.Albums.GenreId == 1));

            // Throws UnresolvableObjectException - Column not found
            ExampleRunner.RunQuery(
                "Run All.OrderByArtistIdAndTitleDescending() - should use ThenBy() for second column.",
                db => db.Albums.All().OrderByArtistIdAndTitleDescending());

            // Throws NullReferenceException
            ExampleRunner.RunQuery(
                "Run All.OrderByDescending(db.Albums.ArtistId, db.Albums.Title) - should use ThenBy() for second column.",
                db => db.Albums.All().OrderByDescending(db.Albums.ArtistId, db.Albums.Title));

            // Runs All.OrderByDescending(ArtistId, Title)
            ExampleRunner.RunQuery(
                "Run All.OrderByDescending(db.Albums.ArtistId).OrderByDescending(db.Albums.Title) - should use ThenBy() for second column.",
                db => db.Albums.All().OrderByDescending(db.Albums.ArtistId).OrderByDescending(db.Albums.Title));

            // Joins and aliases and out params
            // Runs All.OrderByDescending(Title)
            ExampleRunner.RunQuery(
                "Run All.OrderByDescending on explicit LeftJoin ordering on primary table field - named parameter",
                db => db.Albums.All()
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .LeftJoin(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId)
                        .OrderByDescending(db.Albums.Title),
                new List<string> { "Title", "Name" });

            // Runs All.OrderByDescending(Title)
            ExampleRunner.RunQuery(
                "Run All.OrderByDescending on explicit LeftJoin ordering on primary table field - fluid style",
                db => db.Albums.All()
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .LeftJoin(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId)
                        .OrderByTitleDescending(),
                new List<string> { "Title", "Name" });

            // Runs All.OrderByDescending(Name)
            ExampleRunner.RunQuery(
                "Run OrderByDescending on explicit LeftJoin ordering on secondary table field - named parameter",
                db => db.Albums.All()
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .LeftJoin(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId)
                        .OrderByDescending(db.Genre.Name),
                new List<string> { "Title", "Name" });

            // Throws UnresolvableObjectException
            ExampleRunner.RunQuery(
                "Run OrderByDescending on explicit LeftJoin ordering on secondary table field - fluid style",
                db => db.Albums.All()
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .LeftJoin(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId)
                        .OrderByNameDescending(),
                new List<string> { "Title", "Name" });

            // Runs All.OrderByDescending(Name)
            ExampleRunner.RunQuery(
                "Run OrderByDescending on explicit LeftJoin ordering on aliased column expression - named parameter",
                db => db.Albums.All()
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name.As("GenreName"))
                        .LeftJoin(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId)
                        .OrderByDescending(db.Genre.Name),
                new List<string> { "Title", "GenreName" });

            // Runs All.OrderByGenreName
            ExampleRunner.RunQuery(
                "Run OrderByDescending on explicit LeftJoin ordering on aliased column expression - fluid style",
                db => db.Albums.All()
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name.As("GenreName"))
                        .LeftJoin(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId)
                        .OrderByGenreNameDescending(),
                new List<string> { "Title", "GenreName" });

            // Runs All.OrderByDescending(g.Name)
            ExampleRunner.RunQuery(
                "Run OrderByDescending on explicit LeftJoin ordering on aliased table expression - named parameter",
                db => TwoTableLeftJoinWithAliasUsingExpressionsNamed(db),
                new List<string> { "Title", "Name" });

            // Throws UnresolvableObjectException
            ExampleRunner.RunQuery(
                "Run OrderByDescending on explicit LeftJoin ordering on aliased table expression - fluid style",
                db => TwoTableLeftJoinWithAliasUsingExpressionsFluid(db),
                new List<string> { "Title", "Name" });        
        }

        private dynamic TwoTableLeftJoinWithAliasUsingExpressionsNamed(dynamic db)
        {
            dynamic genreAlias;
            return db.Albums.All()
                     .LeftJoin(db.Genre.As("g"), out genreAlias).On(genreAlias.GenreId == db.Albums.GenreId)
                     .Select(
                         db.Albums.Title,
                         genreAlias.Name)
                     .OrderByDescending(genreAlias.Name);
        }

        private dynamic TwoTableLeftJoinWithAliasUsingExpressionsFluid(dynamic db)
        {
            dynamic genreAlias;
            return db.Albums.All()
                     .LeftJoin(db.Genre.As("g"), out genreAlias).On(genreAlias.GenreId == db.Albums.GenreId)
                     .Select(
                         db.Albums.Title,
                         genreAlias.Name)
                     .OrderByNameDescending();
        }

    }
}