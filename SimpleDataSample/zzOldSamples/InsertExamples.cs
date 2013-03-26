using System;
using System.Dynamic;
using Simple.Data;

namespace SimpleDataSample.Samples
{
    internal class InsertExamples
    {
        public static void InsertUsingNamedParameters()
        {
            dynamic db = Database.Open();
            dynamic customer = db.Customers.Insert(Name: "Buy & Large", Address: "Outer Space");

            // Because the Customer table has an Identity column, Simple.Data has returned the new row,
            // including any default values set by the database.
            Console.WriteLine(customer.CustomerId);
        }

        public static void InsertUsingExpandoObject()
        {
            dynamic customer = new ExpandoObject();
            customer.Name = "Tyrell Corporation";
            customer.Address = "New Los Angeles";
            dynamic db = Database.Open();
            customer = db.Customers.Insert(customer);
        }

        public static void InsertUsingStaticTypedObject()
        {
            var customer = new Customer {Name = "SithCo", Address = "Tatooine"};
            dynamic db = Database.Open();
            customer = db.Customers.Insert(customer);

            // Magic implicit casting converts the dynamic object returned to the static type.
        }
    }
}