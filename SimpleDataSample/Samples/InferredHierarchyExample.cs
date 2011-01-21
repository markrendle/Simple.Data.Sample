using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Data;

namespace SimpleDataSample.Samples
{
    class InferredHierarchyExample
    {
        /*
         * When you've got foreign keys set up in your database, Simple.Data will try to infer
         * object hierarchy for you from the schema
         */ 

        public static void PrintCustomerOrders(int customerId)
        {
            var db = Database.Open();
            var customer = db.Customers.FindByCustomerId(customerId);

            foreach (var order in customer.Orders)
            {
                Console.WriteLine("Order {0} ({1})", order.OrderId, order.OrderDate);

                foreach (var orderItem in order.OrderItems)
                {
                    Console.WriteLine("\t{0} of {1} at {2} = {3}",
                        orderItem.Quantity, orderItem.Item.Name, orderItem.Item.Price, orderItem.Quantity * orderItem.Item.Price);
                }
            }

            // This will only work with the dynamic type. Once you magic-cast into a static type,
            // the lazy-loading stops.
        }
    }
}
