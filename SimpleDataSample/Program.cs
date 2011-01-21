using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleDataSample.Samples;

namespace SimpleDataSample
{
    class Program
    {
        static void Main(string[] args)
        {
            CallingStoredProcedureExamples.MultipleResultSetExample();
            CallingStoredProcedureExamples.ReturnValueExample();
            CallingStoredProcedureExamples.SimpleCallExample();

            FindByExamples.AllExample();
            FindByExamples.BasicFindBy();
            FindByExamples.FindAcrossMultipleTablesWithForeignKeys();
            FindByExamples.FindAllByReturnsMultipleRows();
            FindByExamples.FindWithLikeOperator();
            FindByExamples.FindWithMultipleOperators();
            FindByExamples.FindWithOperators();
            FindByExamples.TwoColumnFindBy();

            InferredHierarchyExample.PrintCustomerOrders(1);

            MagicCastingExamples.ImplicitCastExample();

            InsertExamples.InsertUsingExpandoObject();
            InsertExamples.InsertUsingNamedParameters();
            InsertExamples.InsertUsingStaticTypedObject();

            UpdateExamples.UpdateUsingDynamicObjectWithExplicitCriteria();
            UpdateExamples.UpdateUsingDynamicObjectWithImplicitKey();
            UpdateExamples.UpdateUsingNamedParameters();

            LinqFakeExamples.FakeLinqOperatorsCastExample();
            LinqFakeExamples.FakeLinqOperatorsExample();
            LinqFakeExamples.FakeLinqOperatorsWithTypesExample();

            Console.WriteLine("Fin");
            Console.ReadLine();
        }
    }
}
