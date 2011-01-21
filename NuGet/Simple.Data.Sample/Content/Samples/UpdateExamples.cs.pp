using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Simple.Data;

namespace $rootnamespace$.Samples
{
    class UpdateExamples
    {
        public static void UpdateUsingNamedParameters()
        {
            var db = Database.Open();
            int updatedCount = db.Customers.UpdateByCustomerId(CustomerId: 1, Address: "Milton Keynes");
            Console.WriteLine(updatedCount);
        }

        public static void UpdateUsingDynamicObjectWithExplicitCriteria()
        {
            var db = Database.Open();
            var customer = db.Customers.FindByCustomerId(1);
            customer.Address = "Changed";
            db.Customers.UpdateByCustomerId(customer);

            // Of course, this will work with a static-typed object too
        }


        public static void UpdateUsingDynamicObjectWithImplicitKey()
        {
            // When the table has a primary key, you don't need to explicitly specify the criteria

            var db = Database.Open();
            var customer = db.Customers.FindByCustomerId(1);
            customer.Address = "Changed";
            db.Customers.Update(customer);
        }
    }
}
