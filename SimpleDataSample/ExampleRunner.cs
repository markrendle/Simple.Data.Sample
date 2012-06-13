using System;
using System.Diagnostics;
using Simple.Data;

namespace SimpleDataSample
{
  static class ExampleRunner
  {
    /// <summary>
    /// Runs a query against the albums table
    /// </summary>
    /// <param name="explanation">Text description of query being made</param>
    /// <param name="dbQuery">Function taking db and running query over it</param>
    public static void QueryAlbums(string explanation, Func<dynamic, dynamic> dbQuery)
    {
      try
      {
        ShowExplanation(explanation);

      var listener = new ExampleTraceListener();
      Trace.Listeners.Add(listener);


        var db = Database.Open();
        var albums = dbQuery(db);

        ListReturnedAlbumTitles(albums);

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

    private static void ListReturnedAlbumTitles(dynamic albums)
    {
      if (albums == null)
      {
        Console.WriteLine("Query returned null");
        return;
      }

      Console.WriteLine("Query returned a {0}", albums.GetType().FullName);

      if (albums is SimpleRecord)
      {
        Console.WriteLine(albums.Title);
      }
      else
      {
        foreach (var album in albums)
        {
          Console.WriteLine(album.Title);
        }
      }
    }

    private static void ShowSql(ExampleTraceListener listener)
    {
      Console.WriteLine("--------");
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("SQL Sent to database was:");
      Console.WriteLine(listener.Output);
      Console.ResetColor();
    }
  }    
}