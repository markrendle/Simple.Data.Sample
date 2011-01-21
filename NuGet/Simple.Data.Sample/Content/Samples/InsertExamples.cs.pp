using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Simple.Data;

namespace $rootnamespace$.Samples
{
    class InsertExamples
    {
        public static void InsertUsingNamedParameters()
        {
            var db = Database.Open();
            var customer = db.Customers.Insert(Name: "Buy & Large", Address: "Outer Space");

            // Because the Customer table has an Identity column, Simple.Data has returned the new row,
            // including any default values set by the database.
            Console.WriteLine(customer.CustomerId);
        }

        public static void InsertUsingExpandoObject()
        {
            dynamic customer = new ExpandoObject();
            customer.Name = "Tyrell Corporation";
            customer.Address = "New Los Angeles";
            var db = Database.Open();
            customer = db.Customers.Insert(customer);
        }

        public static void InsertUsingStaticTypedObject()
        {
            var customer = new Customer {Name = "SithCo", Address = "Tatooine"};
            var db = Database.Open();
            customer = db.Customers.Insert(customer);

            // Magic implicit casting converts the dynamic object returned to the static type.
        }
    }
}
