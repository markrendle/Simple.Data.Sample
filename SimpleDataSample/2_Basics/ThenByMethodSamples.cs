using System.Collections.Generic;
namespace SimpleDataSample
{
    internal class ThenByMethodSamples
    {
        internal void RunAll()
        {
            // Throws InvalidOperationException
            ExampleRunner.RunQuery(
                "Run ThenBy() without base command or column name.",
                db => db.Albums.ThenBy());

            // Throws InvalidOperationException
            ExampleRunner.RunQuery(
                "Run ThenByArtistId() without base command.",
                db => db.Albums.ThenByArtistId());

            // Throws InvalidOperationException
            ExampleRunner.RunQuery(
                "Run ThenBy(db.Albums.ArtistId) without base command.",
                db => db.Albums.ThenBy(db.Albums.ArtistId));

            // Throws InvalidOperationException
            ExampleRunner.RunQuery(
                "Run All.ThenBy() without orderby.",
                db => db.Albums.All().ThenBy());

            // Throws InvalidOperationException
            ExampleRunner.RunQuery(
                "Run All.ThenByArtistId() without orderby.",
                db => db.Albums.All().ThenByArtistId());

            // Throws NullReferenceException
            ExampleRunner.RunQuery(
                "Run All.ThenBy(db.Albums.ArtistId) without orderby.",
                db => db.Albums.All().ThenBy(db.Albums.ArtistId));





            // Throws NullReferenceException
            ExampleRunner.RunQuery(
                "Run All.ThenBy() without column name.",
                db => db.Albums.All().OrderBy(db.Albums.AlbumId).ThenBy());

            // Runs All.OrderByAlbumId.ThenByArtistId()
            ExampleRunner.RunQuery(
                "Run All.OrderBy(AlbumId).ThenByArtistId().",
                db => db.Albums.All().OrderBy(db.Albums.AlbumId).ThenByArtistId());

            // Runs All.OrderByAlbumId.ThenByArtistId()
            ExampleRunner.RunQuery(
                "Run All.OrderBy(AlbumId).ThenBy(db.Albums.ArtistId).",
                db => db.Albums.All().OrderBy(db.Albums.AlbumId).ThenBy(db.Albums.ArtistId));

            // Throws NullReferenceException
            ExampleRunner.RunQuery(
                "Run All.OrderBy(AlbumId).ThenBy(1) - no column names.",
                db => db.Albums.All().OrderBy(db.Albums.AlbumId).ThenBy(1));

            // Runs All.OrderByAlbumId.ThenByGenreId()
            ExampleRunner.RunQuery(
                "Run All.OrderBy(AlbumId).ThenByGenreId(1).",
                db => db.Albums.All().OrderBy(db.Albums.AlbumId).ThenByGenreId(1));

            // Runs All.OrderByAlbumId.ThenByGenreId()
            ExampleRunner.RunQuery(
                "Run All.OrderBy(AlbumId).ThenByGenreId(db.Albums.Title).",
                db => db.Albums.All().OrderBy(db.Albums.AlbumId).ThenByGenreId(db.Albums.Title));

            // Throws Ado.AdoAdapterException 
            ExampleRunner.RunQuery(
                "Run All.OrderBy(AlbumId).ThenBy(db.Artists.Name) - column not related to query.",
                db => db.Albums.All().OrderBy(db.Albums.AlbumId).ThenBy(db.Artists.Name));

            // Throws NullReferenceException
            ExampleRunner.RunQuery(
                "Run All.OrderBy(AlbumId).ThenBy(db.Albums.GenreId == 1) - erroneous SimpleExpression.",
                db => db.Albums.All().OrderBy(db.Albums.AlbumId).ThenBy(db.Albums.GenreId == 1));

            // Throws UnresolvableObjectException - Column not found
            ExampleRunner.RunQuery(
                "Run All.OrderBy(AlbumId).ThenByArtistIdAndTitle()",
                db => db.Albums.All().OrderBy(db.Albums.AlbumId).ThenByArtistIdAndTitle());

            // Throws NullReferenceException
            ExampleRunner.RunQuery(
                "Run All.OrderBy(AlbumId).ThenBy(db.Albums.ArtistId, db.Albums.Title)",
                db => db.Albums.All().OrderBy(db.Albums.AlbumId).ThenBy(db.Albums.ArtistId, db.Albums.Title));

            // Runs All.OrderBy(AlbumId).ThenBy(ArtistId, Title)
            ExampleRunner.RunQuery(
                "Run All.OrderBy(AlbumId).ThenBy(db.Albums.ArtistId).ThenBy(db.Albums.Title)",
                db => db.Albums.All().OrderBy(db.Albums.AlbumId).ThenBy(db.Albums.ArtistId).ThenBy(db.Albums.Title));

            // Joins and aliases and out params
            // Runs All.OrderBy(AlbumId).ThenBy(Title)
            ExampleRunner.RunQuery(
                "Run All.OrderBy(AlbumId).ThenBy on explicit LeftJoin ordering on primary table field - named parameter",
                db => db.Albums.All().OrderBy(db.Albums.AlbumId)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .LeftJoin(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId)
                        .ThenBy(db.Albums.Title),
                new List<string> { "Title", "Name" });

            // Runs All.OrderBy(AlbumId).ThenBy(Title)
            ExampleRunner.RunQuery(
                "Run All.OrderBy(AlbumId).ThenBy on explicit LeftJoin ordering on primary table field - fluid style",
                db => db.Albums.All().OrderBy(db.Albums.AlbumId)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .LeftJoin(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId)
                        .ThenByTitle(),
                new List<string> { "Title", "Name" });

            // Runs All.OrderBy(AlbumId).ThenBy(Name)
            ExampleRunner.RunQuery(
                "Run ThenBy on explicit LeftJoin ordering on secondary table field - named parameter",
                db => db.Albums.All().OrderBy(db.Albums.AlbumId)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .LeftJoin(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId)
                        .ThenBy(db.Genre.Name),
                new List<string> { "Title", "Name" });

            // Throws UnresolvableObjectException
            ExampleRunner.RunQuery(
                "Run ThenBy on explicit LeftJoin ordering on secondary table field - fluid style",
                db => db.Albums.All().OrderBy(db.Albums.AlbumId)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name)
                        .LeftJoin(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId)
                        .ThenByName(),
                new List<string> { "Title", "Name" });

            // Runs All.OrderBy(AlbumId).ThenBy(Name)
            ExampleRunner.RunQuery(
                "Run ThenBy on explicit LeftJoin ordering on aliased column expression - named parameter",
                db => db.Albums.All().OrderBy(db.Albums.AlbumId)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name.As("GenreName"))
                        .LeftJoin(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId)
                        .ThenBy(db.Genre.Name),
                new List<string> { "Title", "GenreName" });

            // Runs All.OrderBy(AlbumId).ThenByGenreName
            ExampleRunner.RunQuery(
                "Run ThenBy on explicit LeftJoin ordering on aliased column expression - fluid style",
                db => db.Albums.All().OrderBy(db.Albums.AlbumId)
                        .Select(
                            db.Albums.Title,
                            db.Genre.Name.As("GenreName"))
                        .LeftJoin(db.Genre).On(db.Genre.GenreId == db.Albums.GenreId)
                        .ThenByGenreName(),
                new List<string> { "Title", "GenreName" });

            // Runs All.ThenBy(g.Name)
            ExampleRunner.RunQuery(
                "Run ThenBy on explicit LeftJoin ordering on aliased table expression - named parameter",
                db => TwoTableLeftJoinWithAliasUsingExpressionsNamed(db),
                new List<string> { "Title", "Name" });

            // Throws UnresolvableObjectException
            ExampleRunner.RunQuery(
                "Run ThenBy on explicit LeftJoin ordering on aliased table expression - fluid style",
                db => TwoTableLeftJoinWithAliasUsingExpressionsFluid(db),
                new List<string> { "Title", "Name" });        
        }

        private dynamic TwoTableLeftJoinWithAliasUsingExpressionsNamed(dynamic db)
        {
            dynamic genreAlias;
            return db.Albums.All().OrderBy(db.Albums.AlbumId)
                     .LeftJoin(db.Genre.As("g"), out genreAlias).On(genreAlias.GenreId == db.Albums.GenreId)
                     .Select(
                         db.Albums.Title,
                         genreAlias.Name)
                     .ThenBy(genreAlias.Name);
        }

        private dynamic TwoTableLeftJoinWithAliasUsingExpressionsFluid(dynamic db)
        {
            dynamic genreAlias;
            return db.Albums.All().OrderBy(db.Albums.AlbumId)
                     .LeftJoin(db.Genre.As("g"), out genreAlias).On(genreAlias.GenreId == db.Albums.GenreId)
                     .Select(
                         db.Albums.Title,
                         genreAlias.Name)
                     .ThenByName();
        }

    }
}