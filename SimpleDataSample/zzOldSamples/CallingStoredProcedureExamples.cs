using System;
using Simple.Data;

namespace SimpleDataSample.Samples
{
  class CallingStoredProcedureExamples
  {
    public static void SimpleCallExample()
    {
      var db = Database.Open();
      foreach (var artist in db.GetArtists())
      {
        Console.WriteLine(artist.Name);
      }
    }

    public static void ReturnValueExample()
    {
      var db = Database.Open();
      int count = db.GetArtistCount().ReturnValue;
    }

    public static void MultipleResultSetExample()
    {
      var db = Database.Open();
      var results = db.GetArtistAndAlbums(1);
      var artist = results.FirstOrDefault();

      // Call NextResult on the results to move to the next result set, as with ADO DataReader
      if (results.NextResult())
      {
        foreach (var album in results)
        {
          Console.WriteLine(album.Title);
        }
      }
    }
  }
}
