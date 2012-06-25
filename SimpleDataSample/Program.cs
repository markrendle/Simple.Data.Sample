using System;

namespace SimpleDataSample
{
  class Program
  {
    static void Main(string[] args)
    {
      do
      {
        ShowOptions();
        switch (Console.ReadLine())
        {
          case "1":
            var OpenDbDemo = new OpenDatabaseSamples();
            OpenDbDemo.RunAll();
            break;
          case "2":
            var AllMethodDemo = new AllMethodSamples();
            AllMethodDemo.RunAll();
            break;
          case "3":
            var FindByMethodDemo = new FindByMethodSamples();
            FindByMethodDemo.RunAll();
            break;
          case "4":
            var FindAllByMethodDemo = new FindAllByMethodSamples();
            FindAllByMethodDemo.RunAll();
            break;
          case "5":
            var GetMethodDemo = new GetMethodSamples();
            GetMethodDemo.RunAll();
            break;
          case "6":
            var FindMethodDemo = new FindMethodSamples();
            FindMethodDemo.RunAll();
            break;
          case "7":
            var FindAllMethodDemo = new FindAllMethodSamples();
            FindAllMethodDemo.RunAll();
            break;
          case "8":
            var ColumnSelectionDemo = new ColumnSelectionSamples();
            ColumnSelectionDemo.RunAll();
            break;
          case "a":
          case "A":
            var AwMethodDemo = new AwSamples();
            AwMethodDemo.GetFromCompoundKeyTable();
            break;
          case "x":
          case "X":
            Console.WriteLine("Fin");
            return;
          default:
            Console.WriteLine("Not a valid option. Choose again");
            break;
        }
      } while (true);
    }

    private static void ShowOptions()
    {
      Console.WriteLine();
      Console.WriteLine("--------");
      Console.WriteLine();
      Console.WriteLine("Simple.Data Samples");
      Console.WriteLine("Choose from the following options");
      Console.WriteLine();
      Console.WriteLine("1. Open Database Demos");
      Console.WriteLine("2. Basic Selection with All()");
      Console.WriteLine("3. Basic Selection with FindBy()");
      Console.WriteLine("4. Basic Selection with FindAllBy()");
      Console.WriteLine("5. Basic Selection with Get()");
      Console.WriteLine("6. Basic Selection with Find()");
      Console.WriteLine("7. Basic Selection with FindAll()");
      Console.WriteLine("8. Column Selection and Aliasing");
      Console.WriteLine("X. Quit");
      Console.WriteLine();

    }
  }
}
