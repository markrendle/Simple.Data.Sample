using System;
using Simple.Data;
using System.Data.SqlClient;

namespace SimpleDataSample
{
  class OpenDatabaseSamples
  {
    public readonly string MagicConnection =
      @"Data Source=.\SQL2K8;Initial Catalog=MvcMusicStore;Integrated Security=True";

    public void RunAll()
    {
      Console.WriteLine("Use Standard Open Methods");
      UseStandardOpenMethods();
      Console.WriteLine("Press a Key");
      Console.ReadLine();

      Console.WriteLine("Use Shared Connection");
      UseSharedConnection();
    }

    private void UseStandardOpenMethods()
    {
      // Uses the default-named connection string in App.Config
      var defaultDb = Database.Open();
      var artist = defaultDb.Artists.FindByName("Aerosmith");
      Console.WriteLine("Id: {0}, Name: {1}", artist.ArtistId, artist.Name);

      // Uses the user-named connection string in App.Config
      var namedDb = Database.OpenNamedConnection("MvcMusicStoreDb");
      var artist2 = namedDb.Artists.FindByName("Metallica");
      Console.WriteLine("Id: {0}, Name: {1}", artist2.ArtistId, artist2.Name);

      // Uses a magic connection string set in code
      var magicDb = Database.OpenConnection(MagicConnection);
      var artist3 = magicDb.Artists.FindByName("Iron Maiden");
      Console.WriteLine("Id: {0}, Name: {1}", artist3.ArtistId, artist3.Name);

    }

    private SqlConnection GetOpenConnection()
    {
      var connection = new SqlConnection(MagicConnection);
      connection.Open();
      return connection;
    }

    private void UseSharedConnection()
    {

      var db = Database.OpenConnection(MagicConnection);
      SqlConnection conn = GetOpenConnection();
      db.UseSharedConnection(conn);

      var artist = db.Artists.FindByName("Aerosmith");
      Console.WriteLine("Id: {0}, Name: {1}", artist.ArtistId, artist.Name);

      var artist2 = db.Artists.FindByName("Metallica");
      Console.WriteLine("Id: {0}, Name: {1}", artist2.ArtistId, artist2.Name);

      var artist3 = db.Artists.FindByName("Iron Maiden");
      Console.WriteLine("Id: {0}, Name: {1}", artist3.ArtistId, artist3.Name);

      db.StopUsingSharedConnection();
      conn.Close();
    }
  }
}
