using System;
using Simple.Data;
using System.Data.SqlClient;

namespace SimpleDataSample.GettingStarted
{
  class OpenDatabase
  {
    public static readonly string MagicConnection =
      @"Data Source=.\SQL2K8;Initial Catalog=MvcMusicStore;Integrated Security=True";

    public static void UseStandardOpenMethods()
    {
      Console.WriteLine("Use Standard Open Methods");

      // Uses the default-named connection string in App.Config
      var defaultDb = Database.Open();
      var artist = defaultDb.Artists.FindByName("Aerosmith");
      Console.WriteLine("Id: {0}, Name: {1}", artist.ArtistId, artist.Name);

      // Uses the user-named connection string in App.Config
      var namedDb = Database.OpenNamedConnection("MvcMusicStoreDb");
      var artist2 = namedDb.Artists.FindByName("Metallica");
      Console.WriteLine("Id: {0}, Name: {1}", artist2.ArtistId, artist2.Name);

      // Uses a magic connection string set in code
      var magicDb = Database.OpenConnection(OpenDatabase.MagicConnection);
      var artist3 = magicDb.Artists.FindByName("Iron Maiden");
      Console.WriteLine("Id: {0}, Name: {1}", artist3.ArtistId, artist3.Name);
      Console.ReadLine();
    }

    private static SqlConnection GetOpenConnection()
    {
      var connection = new SqlConnection(OpenDatabase.MagicConnection);
      connection.Open();
      return connection;
    }

    public static void UseSharedConnection()
    {
      Console.WriteLine("Use Shared Connection");

      var db = Database.OpenConnection(OpenDatabase.MagicConnection);
      SqlConnection conn = OpenDatabase.GetOpenConnection();
      db.UseSharedConnection(conn);

      var artist = db.Artists.FindByName("Aerosmith");
      Console.WriteLine("Id: {0}, Name: {1}", artist.ArtistId, artist.Name);

      var artist2 = db.Artists.FindByName("Metallica");
      Console.WriteLine("Id: {0}, Name: {1}", artist2.ArtistId, artist2.Name);

      var artist3 = db.Artists.FindByName("Iron Maiden");
      Console.WriteLine("Id: {0}, Name: {1}", artist3.ArtistId, artist3.Name);

      db.StopUsingSharedConnection();
      conn.Close();
      Console.ReadLine();
    }
  }
}
