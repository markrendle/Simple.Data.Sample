using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Data;

namespace $rootnamespace$.Samples
{
    class MagicCastingExamples
    {
        public static void ImplicitCastExample()
        {
            // When you assign the dynamic record to a static type, any matching properties are auto-mapped.
            var db = Database.Open();
            Customer customer = db.Customers.FindByCustomerId(1);
            Console.WriteLine(customer.Name);
        }
    }
}
