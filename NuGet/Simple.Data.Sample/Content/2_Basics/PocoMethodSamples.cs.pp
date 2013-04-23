using System.Collections.Generic;
using $rootnamespace$.POCO;

namespace $rootnamespace$
{
    internal class PocoMethodSamples
    {
        internal void RunAll()
        {
            ExampleRunner.RunQuery(
                "Get a single album. Magic cast it to an album",
                db => db.Albums.FindByGenreId(1), new List<string> {"Title"}, "Album");

            // Throws Microsoft.CSharp.RuntimeBinder.RuntimeBinderException
            // Cannot implicitly convert type 'Simple.Data.SimpleQuery' to 'SimpleDataSample.POCO.Album'
            ExampleRunner.RunQuery(
                "Get a list of albums. Magic cast it to a single album. Throws Exception",
                db => db.Albums.FindAllByGenreId(1), new List<string> {"Title"}, "Album");

            ExampleRunner.RunQuery(
                "Get a list of albums. Magic cast it to a list of albums.",
                db => db.Albums.FindAllByGenreId(1), new List<string> {"Title"}, "AlbumList");

            ExampleRunner.RunQuery(
                "Get a single album. Magic cast it to a list of albums",
                db => db.Albums.FindByGenreId(1), new List<string> {"Title"}, "AlbumList");

            // Throws Simple.Data.UnresolvableObjectException
            ExampleRunner.RunQuery(
                "Get a single album. Call Cast<Album>(). Throws Exception",
                db => db.Albums.FindByGenreId(1).Cast<Album>(), new List<string> {"Title"}, "Album");

            // Returns CastEnumerable<Album>
            ExampleRunner.RunQuery(
                "Get a list of albums. Call Cast<Album>(). Returns CastEnumerable<Album>",
                db => db.Albums.FindAllByGenreId(1).Cast<Album>(), new List<string> {"Title"}, "AlbumEnumerable");

            // Throws Simple.Data.UnresolvableObjectException
            ExampleRunner.RunQuery(
                "Get a single album. Call ToList(). Throws Exception",
                db => db.Albums.FindByGenreId(1).ToList(), new List<string> {"Title"}, "AlbumList");

            // Throws Simple.Data.UnresolvableObjectException
            ExampleRunner.RunQuery(
                "Get a single album. Call ToList<Album>(). Throws Exception",
                db => db.Albums.FindByGenreId(1).ToList<Album>(), new List<string> {"Title"}, "AlbumList");

            // Returns List<dynamic>
            ExampleRunner.RunQuery(
                "Get a list of albums. Call ToList(). Returns List<dynamic>",
                db => db.Albums.FindAllByGenreId(1).ToList(), new List<string> {"Title"}, "DynamicList");

            // Returns List<Album>
            ExampleRunner.RunQuery(
                "Get a list of albums. Call ToList<Album>(). Returns List<Album>",
                db => db.Albums.FindAllByGenreId(1).ToList<Album>(), new List<string> {"Title"}, "AlbumList");

            // Throws Simple.Data.UnresolvableObjectException
            ExampleRunner.RunQuery(
                "Get a single album. Call ToArray(). Throws Exception.",
                db => db.Albums.FindByGenreId(1).ToArray(), new List<string> {"Title"}, "AlbumArray");

            // Throws Simple.Data.UnresolvableObjectException
            ExampleRunner.RunQuery(
                "Get a single album. Call ToArray<Album>(). Throws Exception",
                db => db.Albums.FindByGenreId(1).ToArray<Album>(), new List<string> {"Title"}, "AlbumArray");

            // returns dynamic[]
            ExampleRunner.RunQuery(
                "Get a list of albums. Call ToArray(). Returns dynamic[]",
                db => db.Albums.FindAllByGenreId(1).ToArray(), new List<string> {"Title"}, "DynamicArray");

            // Returns Album[]
            ExampleRunner.RunQuery(
                "Get a list of albums. Call ToArray<Album>(). Returns Album[]",
                db => db.Albums.FindAllByGenreId(1).ToArray<Album>(), new List<string> {"Title"}, "AlbumArray");
        }
    }
}