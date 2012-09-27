using System;
using System.Diagnostics;
using Simple.Data;
using System.Collections.Generic;
using System.Text;

namespace SimpleDataSample
{
  static class ExampleRunner
  {
    /// <summary>
    /// Runs a query and displays the nominated properties
    /// </summary>
    /// <param name="explanation">Text description of query being made</param>
    /// <param name="dbQuery">Function taking db and running query over it</param>
    /// <param name="propertyNamesToList">List of properties to display</param>
    public static void RunQuery(string explanation, Func<dynamic, dynamic> dbQuery, params string[] propertyNamesToList)
    {
      try
      {
        ShowExplanation(explanation);

        var listener = new ExampleTraceListener();
        Trace.Listeners.Add(listener);

        var db = Database.Open();
        var results = dbQuery(db);
        ListReturnedProperties(results, propertyNamesToList);

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

    public static void RunQuery(string explanation, Func<dynamic, dynamic> dbQuery)
    {
      RunQuery(explanation, dbQuery, "Title");
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

    private static void ListReturnedProperties(dynamic results, params string[] propertyNamesToList)
    {
      if (results == null)
      {
        Console.WriteLine("Query returned null");
        return;
      }

      Console.WriteLine("Query returned a {0}", results.GetType().FullName);

      if (results is SimpleRecord)
      {
        Console.WriteLine(GetPropertyValues(results, propertyNamesToList));
      }
      else
      {
        foreach (var result in results)
        {
          Console.WriteLine(GetPropertyValues(result, propertyNamesToList));
        }
      }
    }

    private static string GetPropertyValues(dynamic result, string[] propertyNamesToList)
    {
      StringBuilder sb = new StringBuilder();
      IDictionary<string, object> resultAsDictionary = (IDictionary<string, object>)result;
      foreach (string propertyName in propertyNamesToList)
      {
        sb.AppendFormat("{0} = {1}; ", propertyName, resultAsDictionary[propertyName]);
      }
      return sb.ToString();
    }

  }
}