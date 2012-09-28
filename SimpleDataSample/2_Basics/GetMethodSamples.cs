namespace SimpleDataSample
{
  class GetMethodSamples
  {
    internal void RunAll()
    {
      ExampleRunner.RunQuery(
            "Run Get(). No parameters. Throws exception",
            db => db.Albums.Get());

      ExampleRunner.RunQuery(
        "Run Get(\"AlbumId\"). AlbumId wrong type.",
      db => db.Albums.Get("AlbumId"));

      ExampleRunner.RunQuery(
        "Run Get(1). AlbumId does not exist.",
      db => db.Albums.Get(1));

      ExampleRunner.RunQuery(
          "Run Get(386, 1). Wrong number of key values",
      db => db.Albums.Get(386,1));

      ExampleRunner.RunQuery(
            "Run Get(386). AlbumId exists.",
            db => db.Albums.Get(386));
    }
  }
}
