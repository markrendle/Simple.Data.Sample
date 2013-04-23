using System;
using $rootnamespace$.POCO;

namespace $rootnamespace$
{
    internal class LazyVsEagerLoadingSamples
    {
        internal void RunAll()
        {
            JoinRunner.RunDemo(
              "db.Artists.Get(22) - SimpleRecord lazy loaded accessed as dynamic object",
              db => db.Artists.Get(22),
              String.Empty, false);

            JoinRunner.RunDemo(
              "db.Artists.Get(22) - SimpleRecord lazy loaded accessed as artist POCO",
              db => db.Artists.Get(22),
              "singleArtist", false);

            JoinRunner.RunDemo(
              "db.Artists.All() - SimpleQuery lazy loaded accessed as dynamic object",
              db => db.Artists.All(),
              String.Empty, false);

            JoinRunner.RunDemo(
              "db.Artists.All() - SimpleQuery lazy loaded with explicit join accessed as dynamic object",
              db => db.Artists.All().Join(db.Albums).On(db.Artists.ArtistId == db.Albums.ArtistId).Select(db.Albums.Title, db.Artists.Name, db.Artists.ArtistId),
              String.Empty, false);


            JoinRunner.RunDemo(
              "db.Artists.All() - SimpleQuery lazy loaded accessed as dynamic object, cast to IEnumerable<Artist>",
              db => db.Artists.All().Cast<Artist>(),
              "IEnumerableArtist", false);

            JoinRunner.RunDemo(
              "db.Artists.All() - SimpleQuery lazy loaded accessed as dynamic object, cast to List<dynamic>",
              db => db.Artists.All().ToList(),
              "ListDynamic", false);

            JoinRunner.RunDemo(
              "db.Artists.FindAllByArtistId(22).WithAlbums().FirstOrDefault(). SimpleRecord eager loaded accessed as dynamic object.",
              db => db.Artists.FindAllByArtistId(22).WithAlbums().FirstOrDefault(),
              String.Empty, true);

            JoinRunner.RunDemo(
                "db.Artists.FindAllByArtistId(22).WithAlbums().FirstOrDefault(). SimpleRecord eager loaded accessed as Artist POCO. ",
                db => db.Artists.FindAllByArtistId(15).WithAlbums().FirstOrDefault(),
                "singleArtist", true);

            JoinRunner.RunDemo(
                "db.Artists.All().WithAlbums() - SimpleQuery eaqer loaded & accessed as dynamic object",
                db => db.Artists.All().WithAlbums(),
                String.Empty, true);

            JoinRunner.RunDemo(
                "db.Artists.All().WithAlbums().Cast<Artist>() - SimpleQuery lazy loaded accessed as dynamic object, cast to IEnumerable<Artist>",
                db => db.Artists.All().WithAlbums().Cast<Artist>(),
                "IEnumerableArtist", true);

            JoinRunner.RunDemo(
                "db.Artists.All().WithAlbums().ToList() - SimpleQuery lazy loaded accessed as dynamic object, cast to List<dynamic>",
                db => db.Artists.All().WithAlbums().ToList(),
                "ListDynamic", true);
        }
    }
}