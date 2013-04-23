using System.Collections.Generic;

namespace $rootnamespace$
{
    internal class ToScalarCollectionSamples
    {
        internal void RunAll()
        {
            // ToScalarList
            ExampleRunner.RunQuery(
                "Get a single album. Return null. Cast with ToScalarList(). Throws RuntimeBinderException",
                db => db.Albums.Get(1000).ToScalarList(),
                new List<string>(), "string");

            ExampleRunner.RunQuery(
                "Get a single album. Cast with ToScalarList(). Throws UnresolvableObjectException",
                db => db.Albums.Get(1).ToScalarList(),
                new List<string>(), "string");

            ExampleRunner.RunQuery(
                "Get a single album title. Cast with ToScalarList<string>(). Throws UnresolvableObjectException",
                db => db.Albums.Select(db.Albums.Title).Get(1).ToScalarList<string>(),
                new List<string>(), "string");

            ExampleRunner.RunQuery(
                "Get a list of albums. Return null. Cast with ToScalarList(). Returns empty List<dynamic>",
                db => db.Albums.FindAllByGenreId(100).ToScalarList(),
                new List<string> {"Title"}, "DynamicList");

            ExampleRunner.RunQuery(
                "Get a list of many albums. Cast with ToScalarList(). Returns List<dynamic> of integer AlbumIds",
                db => db.Albums.FindAllByGenreId(1).ToScalarList(),
                new List<string> {"Title"}, "DynamicList");

            ExampleRunner.RunQuery(
                "Get a list of many album titles. Cast with ToScalarList(). Returns List<dynamic>",
                db => db.Albums.FindAllByGenreId(1).Select(db.Albums.Title).ToScalarList(),
                new List<string> {"Title"}, "DynamicList");

            ExampleRunner.RunQuery(
                "Get a list of many album titles. Cast with ToScalarList<string>(). Returns List<string>",
                db => db.Albums.FindAllByGenreId(1).Select(db.Albums.Title).ToScalarList<string>(),
                new List<string> {"Title"}, "StringList");

            ExampleRunner.RunQuery(
                "Get a list of many album titles. Cast with ToScalarList<int>(). Throws InvalidCastException",
                db => db.Albums.FindAllByGenreId(1).Select(db.Albums.Title).ToScalarList<int>(),
                new List<string> {"Title"}, "StringList");

            // ToScalarArray
            ExampleRunner.RunQuery(
                "Get a single album. Return null. Cast with ToScalarArray(). Throws RuntimeBinderException",
                db => db.Albums.Get(1000).ToScalarArray(),
                new List<string>(), "string");

            ExampleRunner.RunQuery(
                "Get a single album. Cast with ToScalarArray(). Throws UnresolvableObjectException",
                db => db.Albums.Get(1).ToScalarArray(),
                new List<string>(), "string");

            ExampleRunner.RunQuery(
                "Get a single album title. Cast with ToScalarArray<string>(). Throws UnresolvableObjectException",
                db => db.Albums.Select(db.Albums.Title).Get(1).ToScalarArray<string>(),
                new List<string>(), "string");

            ExampleRunner.RunQuery(
                "Get a list of albums. Return null. Cast with ToScalarArray(). Returns empty dynamic[]",
                db => db.Albums.FindAllByGenreId(100).ToScalarArray(),
                new List<string> {"Title"}, "DynamicArray");

            ExampleRunner.RunQuery(
                "Get a list of many albums. Cast with ToScalarArray(). Returns dynamic[] of integer AlbumIds",
                db => db.Albums.FindAllByGenreId(1).ToScalarArray(),
                new List<string> {"Title"}, "DynamicArray");

            ExampleRunner.RunQuery(
                "Get a list of many album titles. Cast with ToScalarArray(). Returns dynamic[]",
                db => db.Albums.FindAllByGenreId(1).Select(db.Albums.Title).ToScalarArray(),
                new List<string> {"Title"}, "DynamicArray");

            ExampleRunner.RunQuery(
                "Get a list of many album titles. Cast with ToScalarArray<string>(). Returns string[]",
                db => db.Albums.FindAllByGenreId(1).Select(db.Albums.Title).ToScalarArray<string>(),
                new List<string> {"Title"}, "StringArray");

            ExampleRunner.RunQuery(
                "Get a list of many album titles. Cast with ToScalarArray<int>(). Throws InvalidCastException",
                db => db.Albums.FindAllByGenreId(1).Select(db.Albums.Title).ToScalarArray<int>(),
                new List<string> {"Title"}, "StringArray");
        }
    }
}