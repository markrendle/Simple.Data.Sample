using System.Collections.Generic;
namespace SimpleDataSample
{
    internal class OrderByMethodSamples
    {
        internal void RunAll()
        {
            // Throws NullReferenceException
            ExampleRunner.RunQuery(
                "Run OrderBy() without base command or column name.",
                db => db.Albums.OrderBy());

            // Runs All.OrderByArtistId()
            ExampleRunner.RunQuery(
                "Run OrderByArtistId() without base command.",
                db => db.Albums.OrderByArtistId());

            // Throws NullReferenceException
            ExampleRunner.RunQuery(
                "Run OrderBy(db.Albums.ArtistId) without base command.",
                db => db.Albums.OrderBy(db.Albums.ArtistId));

            // Throws NullReferenceException
            ExampleRunner.RunQuery(
                "Run All.OrderBy() without column name.",
                db => db.Albums.All().OrderBy());

            // Runs All.OrderByArtistId()
            ExampleRunner.RunQuery(
                "Run All.OrderByArtistId().",
                db => db.Albums.All().OrderByArtistId());

            // Runs All.OrderByArtistId()
            ExampleRunner.RunQuery(
                "Run All.OrderBy(db.Albums.ArtistId).",
                db => db.Albums.All().OrderBy(db.Albums.ArtistId));

            // Throws NullReferenceException
            ExampleRunner.RunQuery(
                "Run All.OrderBy(1) - no column names.",
                db => db.Albums.All().OrderBy(1));

            // Runs All.OrderByGenreId()
            ExampleRunner.RunQuery(
                "Run All.OrderByGenreId(1).",
                db => db.Albums.All().OrderByGenreId(1));

            // Runs All.OrderByGenreId()
            ExampleRunner.RunQuery(
                "Run All.OrderByGenreId(db.Albums.Title).",
                db => db.Albums.All().OrderByGenreId(db.Albums.Title));

            // Throws Ado.AdoAdapterException 
            ExampleRunner.RunQuery(
                "Run All.OrderBy(db.Artists.Name) - column not related to query.",
                db => db.Albums.All().OrderBy(db.Artists.Name));

            // Throws NullReferenceException
            ExampleRunner.RunQuery(
                "Run All.OrderBy(db.Albums.GenreId == 1) - erroneous SimpleExpression.",
                db => db.Albums.All().OrderBy(db.Albums.GenreId == 1));

            // Throws UnresolvableObjectException - Column not found
            ExampleRunner.RunQuery(
                "Run All.OrderByArtistIdAndTitle() - should use ThenBy() for second column.",
                db => db.Albums.All().OrderByArtistIdAndTitle());

            // Throws NullReferenceException
            ExampleRunner.RunQuery(
                "Run All.OrderBy(db.Albums.ArtistId, db.Albums.Title) - should use ThenBy() for second column.",
                db => db.Albums.All().OrderBy(db.Albums.ArtistId, db.Albums.Title));

            // Runs All.OrderBy(ArtistId, Title)
            ExampleRunner.RunQuery(
                "Run All.OrderBy(db.Albums.ArtistId).OrderBy(db.Albums.Title) - should use ThenBy() for second column.",
                db => db.Albums.All().OrderBy(db.Albums.ArtistId).OrderBy(db.Albums.Title));

            // Joins and aliases and out params
            // Runs All.OrderBy(Title)
            ExampleRunner.RunQuery(
                "Run All.OrderBy on explicit LeftJoin ordering on primary table field - named parameter",
                db => db.Albums.All()
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .LeftJoin(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId)
                        .OrderBy(db.Albums.Title),
                new List<string> { "Title", "Name" });

            // Runs All.OrderBy(Title)
            ExampleRunner.RunQuery(
                "Run All.OrderBy on explicit LeftJoin ordering on primary table field - fluid style",
                db => db.Albums.All()
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .LeftJoin(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId)
                        .OrderByTitle(),
                new List<string> { "Title", "Name" });

            // Runs All.OrderBy(Name)
            ExampleRunner.RunQuery(
                "Run OrderBy on explicit LeftJoin ordering on secondary table field - named parameter",
                db => db.Albums.All()
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .LeftJoin(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId)
                        .OrderBy(db.Genre.Name),
                new List<string> { "Title", "Name" });

            // Throws UnresolvableObjectException
            ExampleRunner.RunQuery(
                "Run OrderBy on explicit LeftJoin ordering on secondary table field - fluid style",
                db => db.Albums.All()
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .LeftJoin(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId)
                        .OrderByName(),
                new List<string> { "Title", "Name" });

            // Runs All.OrderBy(Name)
            ExampleRunner.RunQuery(
                "Run OrderBy on explicit LeftJoin ordering on aliased column expression - named parameter",
                db => db.Albums.All()
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name.As("GenreName"))
                        .LeftJoin(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId)
                        .OrderBy(db.Genre.Name),
                new List<string> { "Title", "GenreName" });

            // Runs All.OrderByGenreName
            ExampleRunner.RunQuery(
                "Run OrderBy on explicit LeftJoin ordering on aliased column expression - fluid style",
                db => db.Albums.All()
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name.As("GenreName"))
                        .LeftJoin(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId)
                        .OrderByGenreName(),
                new List<string> { "Title", "GenreName" });

            // Runs All.OrderBy(g.Name)
            ExampleRunner.RunQuery(
                "Run OrderBy on explicit LeftJoin ordering on aliased table expression - named parameter",
                db => TwoTableLeftJoinWithAliasUsingExpressionsNamed(db),
                new List<string> { "Title", "Name" });

            // Throws UnresolvableObjectException
            ExampleRunner.RunQuery(
                "Run OrderBy on explicit LeftJoin ordering on aliased table expression - fluid style",
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
                     .OrderBy(genreAlias.Name);
        }

        private dynamic TwoTableLeftJoinWithAliasUsingExpressionsFluid(dynamic db)
        {
            dynamic genreAlias;
            return db.Albums.All()
                     .LeftJoin(db.Genre.As("g"), out genreAlias).On(genreAlias.GenreId == db.Albums.GenreId)
                     .Select(
                         db.Albums.Title,
                         genreAlias.Name)
                     .OrderByName();
        }

    }
}