using Simple.Data;
using System;
using System.Diagnostics;

namespace SimpleDataSample
{
  class AwSamples
  {
    private readonly string AwConnection =
      @"Data Source=.\SQL2K8;Initial Catalog=AdventureWorksLT2008R2;Integrated Security=True";

    internal void GetFromCompoundKeyTable()
    {
      var listener = new ExampleTraceListener();
      Trace.Listeners.Add(listener);
      var awDb = Database.OpenConnection(AwConnection);
      var addr = awDb.SalesLT.CustomerAddress.Get(29485, 1086);
      Console.WriteLine(addr.AddressType);
      Console.WriteLine("--------");
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("SQL Sent to database was:");
      Console.WriteLine(listener.Output);
      Console.ResetColor();
      Trace.Listeners.Remove(listener);
    }


  }
}
