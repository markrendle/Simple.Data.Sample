using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Simple.Data;
using SimpleDataSample.POCO;

namespace SimpleDataSample
{
    internal static class ExampleRunner
    {
        /// <summary>
        ///     Runs a query and displays the nominated properties
        /// </summary>
        /// <param name="explanation">Text description of query being made</param>
        /// <param name="dbQuery">Function taking db and running query over it</param>
        /// <param name="propertyNamesToList">List of properties to display</param>
        /// <param name="pocoType">Type of POCO being created</param>
        public static void RunQuery(string explanation, Func<dynamic, dynamic> dbQuery, List<string> propertyNamesToList,
                                    string pocoType)
        {
            try
            {
                ShowExplanation(explanation);

                var listener = new ExampleTraceListener();
                Trace.Listeners.Add(listener);

                dynamic db = Database.Open();
                dynamic results = dbQuery(db);
                ListReturnedProperties(results, propertyNamesToList, pocoType);

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

        public static void RunQuery(string explanation, Func<dynamic, dynamic> dbQuery, List<string> propertyNamesToList)
        {
            RunQuery(explanation, dbQuery, propertyNamesToList, String.Empty);
        }

        public static void RunQuery(string explanation, Func<dynamic, dynamic> dbQuery)
        {
            RunQuery(explanation, dbQuery, new List<string> { "Title" }, String.Empty);
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

        private static void ListReturnedProperties(dynamic results, List<string> propertyNamesToList, string pocoType)
        {
            if (results == null)
            {
                Console.WriteLine("Query returned null");
                return;
            }

            switch (pocoType)
            {
                case "Album":
                    Album album = results;
                    Console.WriteLine(album.ToString());
                    break;
                case "AlbumList":
                    List<Album> albumList = results;
                    Console.WriteLine("Number of items: {0}", albumList.Count);
                    foreach (Album lp in albumList)
                    {
                        Console.WriteLine(lp.ToString());
                    }
                    break;
                case "AlbumArray":
                    Album[] albumArray = results;
                    Console.WriteLine("Number of items: {0}", albumArray.Length);
                    foreach (Album lp in albumArray)
                    {
                        Console.WriteLine(lp.ToString());
                    }
                    break;
                case "Order":
                    Order order = results;
                    Console.WriteLine(order.ToString());
                    break;
                case "DynamicList":
                    List<dynamic> dynamicList = results;
                    Console.WriteLine("Number of items: {0}", dynamicList.Count);
                    foreach (dynamic item in dynamicList)
                    {
                        ListReturnedPropertiesInDynamicObject(item, propertyNamesToList);
                    }
                    break;
                case "DynamicArray":
                    dynamic[] dynamicArray = results;
                    Console.WriteLine("Number of items: {0}", dynamicArray.Length);
                    foreach (dynamic item in dynamicArray)
                    {
                        ListReturnedPropertiesInDynamicObject(item, propertyNamesToList);
                    }
                    break;
                case "AlbumEnumerable":
                    IEnumerable<Album> albums = results;
                    foreach (Album lp in albums)
                    {
                        Console.WriteLine(lp.ToString());
                    }
                    break;
                case "StringList":
                    List<string> stringList = results;
                    Console.WriteLine("Number of items: {0}", stringList.Count);
                    foreach (string item in results)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "StringArray":
                    string[] stringArray = results;
                    Console.WriteLine("Number of items: {0}", stringArray.Length);
                    foreach (string item in results)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                default:
                    ListReturnedPropertiesInDynamicObject(results, propertyNamesToList);
                    break;
            }
        }

        private static void ListReturnedPropertiesInDynamicObject(dynamic results, List<string> propertyNamesToList)
        {
            Console.WriteLine("Query returned a {0}", results.GetType().FullName);

            if (results is bool)
            {
                Console.WriteLine("A boolean: " + results.ToString());
                return;                
            }
            if (results is int)
            {
                Console.WriteLine("An integer: " + results.ToString());
                return;
            }

            if (results is string)
            {
                Console.WriteLine("A string: " + results);
                return;
            }
            if (results is float)
            {
                Console.WriteLine("A float: " + results);
                return;
            }
            if (results is double)
            {
                Console.WriteLine("A double: " + results);
                return;
            }
            if (results is Decimal)
            {
                Console.WriteLine("A Decimal: " + results.ToString());
                return;
            }
            if (results is SimpleRecord)
            {
                Console.WriteLine(GetPropertyValues(results, propertyNamesToList));
                return;
            }

            // Assume is SimpleQuery
            foreach (dynamic result in results)
            {
                Console.WriteLine(GetPropertyValues(result, propertyNamesToList));
            }
        }

        private static string GetPropertyValues(dynamic result, IEnumerable<string> propertyNamesToList)
        {
            var sb = new StringBuilder();
            var resultAsDictionary = (IDictionary<string, object>)result;
            foreach (string propertyName in propertyNamesToList)
            {
                sb.AppendFormat("{0} = {1}; ", propertyName, resultAsDictionary[propertyName]);
            }
            return sb.ToString();
        }
    }
}