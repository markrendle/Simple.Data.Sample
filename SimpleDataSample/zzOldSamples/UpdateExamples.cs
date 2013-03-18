using System;
using Simple.Data;

namespace SimpleDataSample.Samples
{
    internal class UpdateExamples
    {
        public static void UpdateUsingNamedParameters()
        {
            dynamic db = Database.Open();
            int updatedCount = db.Customers.UpdateByCustomerId(CustomerId: 1, Address: "Milton Keynes");
            Console.WriteLine(updatedCount);
        }

        public static void UpdateUsingDynamicObjectWithExplicitCriteria()
        {
            dynamic db = Database.Open();
            dynamic customer = db.Customers.FindByCustomerId(1);
            customer.Address = "Changed";
            db.Customers.UpdateByCustomerId(customer);

            // Of course, this will work with a static-typed object too
        }


        public static void UpdateUsingDynamicObjectWithImplicitKey()
        {
            // When the table has a primary key, you don't need to explicitly specify the criteria

            dynamic db = Database.Open();
            dynamic customer = db.Customers.FindByCustomerId(1);
            customer.Address = "Changed";
            db.Customers.Update(customer);
        }
    }
}