using System;
using Simple.Data;

namespace SimpleDataSample.Samples
{
    internal class InferredHierarchyExample
    {
        /*
         * When you've got foreign keys set up in your database, Simple.Data will try to infer
         * object hierarchy for you from the schema
         */

        public static void PrintCustomerOrders(int customerId)
        {
            dynamic db = Database.Open();
            dynamic customer = db.Customers.FindByCustomerId(customerId);

            foreach (dynamic order in customer.Orders)
            {
                Console.WriteLine("Order {0} ({1})", order.OrderId, order.OrderDate);

                foreach (dynamic orderItem in order.OrderItems)
                {
                    Console.WriteLine("\t{0} of {1} at {2} = {3}",
                                      orderItem.Quantity, orderItem.Item.Name, orderItem.Item.Price,
                                      orderItem.Quantity*orderItem.Item.Price);
                }
            }

            // This will only work with the dynamic type. Once you magic-cast into a static type,
            // the lazy-loading stops.
        }
    }
}