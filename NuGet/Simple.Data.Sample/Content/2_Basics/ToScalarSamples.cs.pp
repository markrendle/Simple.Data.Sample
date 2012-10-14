using System.Collections.Generic;
namespace $rootnamespace$
{
  class ToScalarSamples
  {
    internal void RunAll()
    {
      // ToScalar
      // Throws RuntimeBinderException. 
      ExampleRunner.RunQuery(
            "Get a single album. Return null. Cast with ToScalar()",
            db => db.Albums.Get(1000).ToScalar(),
            new List<string>(), "string");

      ExampleRunner.RunQuery(
            "Get a single album. Cast with ToScalar()",
            db => db.Albums.Get(1).ToScalar(),
            new List<string>(), "string");

      // Throws InvalidCastException
      ExampleRunner.RunQuery(
            "Get a single album title. Cast with ToScalar<int>(). Throws InvalidCastException",
            db => db.Albums.Select(db.Albums.Title).Get(1).ToScalar<int>(),
            new List<string>(), "string");

      ExampleRunner.RunQuery(
            "Get a single album title. Cast with ToScalar<string>()",
            db => db.Albums.Select(db.Albums.Title).Get(1).ToScalar<string>(),
            new List<string>(), "string");

      ExampleRunner.RunQuery(
            "Get a list of album titles. Return null. Cast with ToScalar(). Throws Exception",
            db => db.Albums.FindAllByGenreId(100).Select(db.Albums.Title).ToScalar());

      ExampleRunner.RunQuery(
            "Get a list of many album titles. Cast with ToScalar(). Throws Exception",
            db => db.Albums.FindAllByGenreId(1).Select(db.Albums.Title).ToScalar());

      ExampleRunner.RunQuery(
            "Get a list of one album title. Cast with ToScalar(). Returns album title as string",
            db => db.Albums.FindAllByAlbumId(1).Select(db.Albums.Title).ToScalar());

      ExampleRunner.RunQuery(
            "Get a list of one album. Cast with ToScalar(). Returns albumid as int",
            db => db.Albums.FindAllByAlbumId(1).ToScalar());

      ExampleRunner.RunQuery(
            "Get a list of one album title. Cast with ToScalar<string>(). Returns album title as string",
            db => db.Albums.FindAllByAlbumId(1).Select(db.Albums.Title).ToScalar<string>());

      ExampleRunner.RunQuery(
            "Get a list of one album. Cast with ToScalar<string>(). Throws InvalidCastException",
            db => db.Albums.FindAllByAlbumId(1).ToScalar<string>());

      // ToScalarOrDefault
      ExampleRunner.RunQuery(
            "Get a single album. Return null. Cast with ToScalarOrDefault(). Throws RuntimeBinderException",
            db => db.Albums.Get(1000).ToScalarOrDefault(),
            new List<string>(), "string");

      ExampleRunner.RunQuery(
            "Get a single album. Cast with ToScalarOrDefault(). Throws UnresolvableObjectException",
            db => db.Albums.Get(1).ToScalarOrDefault(),
            new List<string>(), "string");

      ExampleRunner.RunQuery(
            "Get a single album title. Cast with ToScalarOrDefault<int>(). Throws UnresolvableObjectException",
            db => db.Albums.Select(db.Albums.Title).Get(1).ToScalarOrDefault<int>(),
            new List<string>(), "string");

      ExampleRunner.RunQuery(
            "Get a single album title. Cast with ToScalarOrDefault<string>(). Throws UnresolvableObjectException",
            db => db.Albums.Select(db.Albums.Title).Get(1).ToScalarOrDefault<string>(),
            new List<string>(), "string");

      ExampleRunner.RunQuery(
            "Get a list of zero album titles. Return null. Cast with ToScalarOrDefault(). Returns null",
            db => db.Albums.FindAllByGenreId(100).Select(db.Albums.Title).ToScalarOrDefault());

      ExampleRunner.RunQuery(
            "Get a list of many album titles. Cast with ToScalarOrDefault(). Throws SimpleDataException",
            db => db.Albums.FindAllByGenreId(1).Select(db.Albums.Title).ToScalarOrDefault());

      ExampleRunner.RunQuery(
            "Get a list of one album title. Cast with ToScalarOrDefault(). Returns album title as string",
            db => db.Albums.FindAllByAlbumId(1).Select(db.Albums.Title).ToScalarOrDefault());

      ExampleRunner.RunQuery(
            "Get a list of one album. Cast with ToScalarOrDefault(). Returns albumid as int",
            db => db.Albums.FindAllByAlbumId(1).ToScalarOrDefault());

      ExampleRunner.RunQuery(
            "Get a list of one album title. Cast with ToScalarOrDefault<string>(). Returns album title as string",
            db => db.Albums.FindAllByAlbumId(1).Select(db.Albums.Title).ToScalarOrDefault<string>());

      ExampleRunner.RunQuery(
            "Get a list of one album. Cast with ToScalarOrDefault<string>(). Throws InvalidCastException",
            db => db.Albums.FindAllByAlbumId(1).ToScalarOrDefault<string>());
 

    }
  }
}
