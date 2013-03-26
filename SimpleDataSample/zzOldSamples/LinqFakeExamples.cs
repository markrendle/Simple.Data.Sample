using System;
using System.Collections.Generic;
using Simple.Data;

namespace SimpleDataSample.Samples
{
    internal class LinqFakeExamples
    {
        public static void FakeLinqOperatorsExample()
        {
            dynamic db = Database.Open();
            dynamic customers = db.Customers.All();

            dynamic firstCustomer = customers.First();
            dynamic firstCustomerOrNull = customers.FirstOrDefault();

            List<dynamic> customerList = customers.ToList();
            dynamic[] customerArray = customers.ToArray();
        }

        public static void FakeLinqOperatorsWithTypesExample()
        {
            dynamic db = Database.Open();
            dynamic customers = db.Customers.All();

            Customer firstCustomer = customers.First();
            Customer firstCustomerOrNull = customers.FirstOrDefault();

            List<Customer> customerList = customers.ToList<Customer>();
            Customer[] customerArray = customers.ToArray<Customer>();
        }

        public static void FakeLinqOperatorsCastExample()
        {
            dynamic db = Database.Open();
            foreach (Customer customer in db.Customers.All().Cast<Customer>())
            {
                Console.WriteLine(customer.Name);
            }
        }
    }
}