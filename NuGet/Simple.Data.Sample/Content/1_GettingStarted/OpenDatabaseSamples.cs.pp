using System;
using System.Data.SqlClient;
using Simple.Data;

namespace $rootnamespace$
{
    internal class OpenDatabaseSamples
    {
        public readonly string MagicConnection =
            @"Data Source=.\SQLExpress;Initial Catalog=MvcMusicStore;Integrated Security=True";

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
            dynamic defaultDb = Database.Open();
            dynamic artist = defaultDb.Artists.FindByName("Aerosmith");
            Console.WriteLine("Id: {0}, Name: {1}", artist.ArtistId, artist.Name);

            // Uses the user-named connection string in App.Config
            dynamic namedDb = Database.OpenNamedConnection("MvcMusicStoreDb");
            dynamic artist2 = namedDb.Artists.FindByName("Metallica");
            Console.WriteLine("Id: {0}, Name: {1}", artist2.ArtistId, artist2.Name);

            // Uses a magic connection string set in code
            dynamic magicDb = Database.OpenConnection(MagicConnection);
            dynamic artist3 = magicDb.Artists.FindByName("Iron Maiden");
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
            dynamic db = Database.OpenConnection(MagicConnection);
            SqlConnection conn = GetOpenConnection();
            db.UseSharedConnection(conn);

            dynamic artist = db.Artists.FindByName("Aerosmith");
            Console.WriteLine("Id: {0}, Name: {1}", artist.ArtistId, artist.Name);

            dynamic artist2 = db.Artists.FindByName("Metallica");
            Console.WriteLine("Id: {0}, Name: {1}", artist2.ArtistId, artist2.Name);

            dynamic artist3 = db.Artists.FindByName("Iron Maiden");
            Console.WriteLine("Id: {0}, Name: {1}", artist3.ArtistId, artist3.Name);

            db.StopUsingSharedConnection();
            conn.Close();
        }
    }
}