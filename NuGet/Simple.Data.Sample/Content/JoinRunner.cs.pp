using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Simple.Data;
using $rootnamespace$.POCO;

namespace $rootnamespace$
{
    internal static class JoinRunner
    {
        public static void RunDemo(string explanation, Func<dynamic, dynamic> dbQuery, string pocoType, bool isEager)
        {
            try
            {
                ShowExplanation(explanation);

                var listener = new ExampleTraceListener();
                Trace.Listeners.Add(listener);

                dynamic db = Database.Open();
                dynamic results = dbQuery(db);
                ListReturnedProperties(results, pocoType, isEager);

                ShowSql(listener);

                Trace.Listeners.Remove(listener);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }

            Console.WriteLine("Press return");
            Console.ReadLine();
        }

        private static void ShowException(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.GetType().FullName);
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }

        private static void ShowExplanation(string explanation)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(explanation);
            Console.ResetColor();
            Console.ReadLine();
        }

        private static void ShowSql(ExampleTraceListener listener)
        {
            Console.WriteLine("--------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SQL Sent to database was:");
            Console.WriteLine(listener.Output);
            Console.ResetColor();
        }

        private static void ListReturnedProperties(dynamic results, string pocoType, bool isEager)
        {
            if (results == null)
            {
                Console.WriteLine("Query returned null");
                return;
            }

            Console.WriteLine("Query returned a {0}", results.GetType().FullName);

            switch (pocoType)
            {
                case "singleArtist":
                    Artist artist = results;
                    ShowArtistAndAlbum(artist, isEager);
                    break;
                case "IEnumerableArtist":
                    IEnumerable<Artist> artists = results;
                    foreach (Artist artist2 in artists)
                    {
                        Console.WriteLine(ShowArtistAndAlbum(artist2, isEager));
                    }
                    break;
                case "ListDynamic":
                    List<dynamic> artistList = results;
                    foreach (dynamic artist3 in artistList)
                    {
                        Console.WriteLine(ShowArtistAndAlbum(artist3, isEager));
                    }
                    break;
                default:
                    if (results is SimpleRecord)
                    {
                        Console.WriteLine(ShowArtistAndAlbum(results, isEager));
                    }
                    else
                    {
                        foreach (dynamic result in results)
                        {
                            Console.WriteLine(ShowArtistAndAlbum(result, isEager));
                        }
                    }
                    break;
            }
        }


        private static string ShowArtistAndAlbum(dynamic artist, bool isEager)
        {
            var sb = new StringBuilder();

            Console.WriteLine("Artist {0} ({1})", artist.ArtistId, artist.Name);

            if (!isEager || (artist.Albums != null))
            {
                foreach (dynamic album in artist.Albums)
                {
                    Console.WriteLine("\t{0}", album.Title);
                }
            }

            return sb.ToString();
        }

        private static string ShowArtistAndAlbum(Artist artist, bool isEager)
        {
            var sb = new StringBuilder();

            Console.WriteLine("Artist {0} ({1})", artist.ArtistId, artist.Name);

            if (!isEager || (artist.Albums != null))
            {
                foreach (Album album in artist.Albums)
                {
                    Console.WriteLine("\t{0}", album.Title);
                }
            }

            return sb.ToString();
        }
    }
}