using System;
using Simple.Data;

namespace SimpleDataSample.Samples
{
    internal class MagicCastingExamples
    {
        public static void ImplicitCastExample()
        {
            // When you assign the dynamic record to a static type, any matching properties are auto-mapped.
            dynamic db = Database.Open();
            Customer customer = db.Customers.FindByCustomerId(1);
            Console.WriteLine(customer.Name);
        }
    }
}