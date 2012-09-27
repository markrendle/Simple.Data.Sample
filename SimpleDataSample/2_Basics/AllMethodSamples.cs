namespace SimpleDataSample
{
  class AllMethodSamples
  {
    internal void RunAll()
    {
      ExampleRunner.RunQuery(
            "Get all items in the Album table",
            db => db.Albums.All());

      ExampleRunner.RunQuery(
            "Parameter added (GenreId=1) but is ignored",
            db => db.Albums.All(db.Albums.GenreId == "1"));
    }
  }
}
