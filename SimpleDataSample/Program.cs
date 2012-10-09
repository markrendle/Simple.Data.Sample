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
          case "9":
            var BasicWhereDemo = new WhereMethodSamples();
            BasicWhereDemo.RunAll();
            break;
          case "a":
          case "A":
            var CommonSearchesDemo = new WhereConditionSamples();
            CommonSearchesDemo.RunAll();
            break;
          case "b":
          case "B":
            var CountDistinctDemo = new CountDistinctSamples();
            CountDistinctDemo.RunAll();
            break;
          case "c":
          case "C":
            var GetCountDemo = new GetCountMethodSamples();
            GetCountDemo.RunAll();
            break;
          case "d":
          case "D":
            var GetCountByDemo = new GetCountByMethodSamples();
            GetCountByDemo.RunAll();
            break;
          case "e":
          case "E":
            var PocoDemo = new PocoMethodSamples();
            PocoDemo.RunAll();
            break;
          case "f":
          case "F":
            var ScalarDemo = new ToScalarSamples();
            ScalarDemo.RunAll();
            break;
          case "g":
          case "G":
            var ScalarCollectionDemo = new ToScalarCollectionSamples();
            ScalarCollectionDemo.RunAll();
            break;
          case "h":
          case "H":
            var NaturalJoinDemo = new NaturalJoinSamples();
            NaturalJoinDemo.RunAll();
            break;
          case "i":
          case "I":
            var ExplicitJoinDemo = new ExplicitJoinSamples();
            ExplicitJoinDemo.RunAll();
            break;
          case "j":
          case "J":
            var OuterJoinDemo = new OuterJoinSamples();
            OuterJoinDemo.RunAll();
            break;
          case "k":
          case "K":
            var LeftJoinDemo = new LeftJoinSamples();
            LeftJoinDemo.RunAll();
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
      Console.WriteLine("9. Basic use of Where()");
      Console.WriteLine("A. Common Search Conditions");
      Console.WriteLine("B. Count \\ Distinct Demos");
      Console.WriteLine("C. GetCount Demos");
      Console.WriteLine("D. GetCountBy Demos");
      Console.WriteLine("E. Poco Demos");
      Console.WriteLine("F. ToScalar Demos");
      Console.WriteLine("G. ToScalar Collection Demos");
      Console.WriteLine("H. Natural Join Demos");
      Console.WriteLine("I. Explicit Join Demos");
      Console.WriteLine("J. Outer Join Demos");
      Console.WriteLine("K. Left Join Demos");
      Console.WriteLine("X. Quit");
      Console.WriteLine();

    }
  }
}
