using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Simple.Data;
using $rootnamespace$.POCO;

namespace $rootnamespace$
{
    internal static class WithRunner
    {
        public static void RunDemo(string explanation, Func<dynamic, dynamic> dbQuery)
        {
            RunDemo(explanation, dbQuery, string.Empty);
        }

        public static void RunDemo(string explanation, Func<dynamic, dynamic> dbQuery, string pocoType)
        {
            try
            {
                ShowExplanation(explanation);

                var listener = new ExampleTraceListener();
                Trace.Listeners.Add(listener);

                dynamic db = Database.Open();
                dynamic results = dbQuery(db);
                ListReturnedProperties(results, pocoType);

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

        private static void ListReturnedProperties(dynamic results, string pocoType)
        {
            if (results == null)
            {
                Console.WriteLine("Query returned null");
                return;
            }

            Console.WriteLine("Query returned a {0}", results.GetType().FullName);

            if (pocoType == "OrderDetailList")
            {
                IEnumerable<OrderDetails> ods = results;
                foreach (OrderDetails od in ods)
                {
                    Console.WriteLine(od.ToString());
                }
                return;
            }

            if (results is SimpleRecord)
            {
                Album album = results;
                Console.WriteLine(album.ToString());
            }
            else
            {
                IEnumerable<Album> albums = results;
                foreach (Album album in albums)
                {
                    Console.WriteLine(album.ToString());
                }
            }
        }
    }
}