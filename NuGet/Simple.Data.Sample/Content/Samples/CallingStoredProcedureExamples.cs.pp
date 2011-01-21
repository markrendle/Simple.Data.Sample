using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Simple.Data;

namespace $rootnamespace$.Samples
{
    class CallingStoredProcedureExamples
    {
        public static void SimpleCallExample()
        {
            var db = Database.Open();
            foreach (var customer in db.GetCustomers())
            {
                Console.WriteLine(customer.Name);
            }
        }

        public static void ReturnValueExample()
        {
            var db = Database.Open();
            int count = db.GetCustomerCount().ReturnValue;
        }

        public static void MultipleResultSetExample()
        {
            var db = Database.Open();
            var results = db.GetCustomerAndOrders(1);
            var customer = results.FirstOrDefault();

            // Call NextResult on the results to move to the next result set, as with ADO DataReader
            if (results.NextResult())
            {
                foreach (var order in results)
                {
                    Console.WriteLine(order.OrderDate);
                }
            }
        }
    }
}
