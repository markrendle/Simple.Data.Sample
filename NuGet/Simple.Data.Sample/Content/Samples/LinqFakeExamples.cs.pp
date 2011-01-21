using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Data;

namespace $rootnamespace$.Samples
{
    class LinqFakeExamples
    {
        public static void FakeLinqOperatorsExample()
        {
            var db = Database.Open();
            var customers = db.Customers.All();

            var firstCustomer = customers.First();
            var firstCustomerOrNull = customers.FirstOrDefault();

            List<dynamic> customerList = customers.ToList();
            dynamic[] customerArray = customers.ToArray();
        }

        public static void FakeLinqOperatorsWithTypesExample()
        {
            var db = Database.Open();
            var customers = db.Customers.All();

            Customer firstCustomer = customers.First();
            Customer firstCustomerOrNull = customers.FirstOrDefault();

            List<Customer> customerList = customers.ToList<Customer>();
            Customer[] customerArray = customers.ToArray<Customer>();
        }

        public static void FakeLinqOperatorsCastExample()
        {
            var db = Database.Open();
            foreach (Customer customer in db.Customers.All().Cast<Customer>())
            {
                Console.WriteLine(customer.Name);
            }
        }
    }
}
