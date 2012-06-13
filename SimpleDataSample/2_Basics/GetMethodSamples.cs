namespace SimpleDataSample
{
  class GetMethodSamples
  {
    internal void RunAll()
    {
      ExampleRunner.QueryAlbums(
            "Run Get(). No parameters. Throws exception",
            db => db.Albums.Get());

      ExampleRunner.QueryAlbums(
        "Run Get(\"AlbumId\"). AlbumId wrong type.",
      db => db.Albums.Get("AlbumId"));

      ExampleRunner.QueryAlbums(
        "Run Get(1). AlbumId does not exist.",
      db => db.Albums.Get(1));

      ExampleRunner.QueryAlbums(
          "Run Get(386, 1). Wrong number of key values",
      db => db.Albums.Get(386,1));

      ExampleRunner.QueryAlbums(
            "Run Get(386). AlbumId exists.",
            db => db.Albums.Get(386));
    }
  }
}
