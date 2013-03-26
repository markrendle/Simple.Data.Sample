using System;
using Simple.Data;

namespace SimpleDataSample.Samples
{
    internal class CallingStoredProcedureExamples
    {
        public static void SimpleCallExample()
        {
            dynamic db = Database.Open();
            foreach (dynamic artist in db.GetArtists())
            {
                Console.WriteLine(artist.Name);
            }
        }

        public static void ReturnValueExample()
        {
            dynamic db = Database.Open();
            int count = db.GetArtistCount().ReturnValue;
        }

        public static void MultipleResultSetExample()
        {
            dynamic db = Database.Open();
            dynamic results = db.GetArtistAndAlbums(1);
            dynamic artist = results.FirstOrDefault();

            // Call NextResult on the results to move to the next result set, as with ADO DataReader
            if (results.NextResult())
            {
                foreach (dynamic album in results)
                {
                    Console.WriteLine(album.Title);
                }
            }
        }
    }
}