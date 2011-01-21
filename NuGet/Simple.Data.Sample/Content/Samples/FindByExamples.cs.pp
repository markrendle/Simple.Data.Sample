using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Data;

namespace $rootnamespace$.Samples
{
    class FindByExamples
    {
        public static void AllExample()
        {
            var db = Database.Open(); // Opens the default database, as specified in config
            foreach (var customer in db.Customers.All())
            {
                Console.WriteLine(customer.Name);
            }
            
        }
        public static void BasicFindBy()
        {
            var db = Database.Open(); // Opens the default database, as specified in config
            var customer = db.Customers.FindByCustomerId(1);
            Console.WriteLine(customer.Name);
        }

        public static void TwoColumnFindBy()
        {
            var db = Database.Open();
            var user = db.Users.FindByNameAndPassword("Bob", "Secret");
            Console.WriteLine(user.Id);
        }

        public static void FindAllByReturnsMultipleRows()
        {
            var db = Database.Open();
            foreach (var user in db.Users.FindAllByAge(42))
            {
                Console.WriteLine(user.Name + " is 42");
            }
        }

        public static void FindWithOperators()
        {
            var db = Database.Open();
            foreach (var user in db.Users.FindAll(db.Users.Age >= 40))
            {
                Console.WriteLine(user.Name + " is over 40");
            }
            /*
             * Supported operators: ==, !=, <, <=, >, >=
             */ 
        }

        public static void FindWithMultipleOperators()
        {
            var db = Database.Open();
            foreach (var user in db.Users.FindAll(db.Users.Age >= 40 && db.Users.Age < 50))
            {
                Console.WriteLine(user.Name + " is 40-something");
            }
            /*
             * Supported operators: && and ||, and grouping using ()
             */
        }

        public static void FindWithLikeOperator()
        {
            var db = Database.Open();
            foreach (var user in db.Users.FindAll(db.Users.Name.Like("B%")))
            {
                Console.WriteLine(user.Name + " starts with B");
            }
            /*
             * NotLike("xyz") is also available
             */
        }

        public static void FindAcrossMultipleTablesWithForeignKeys()
        {
            // As long as a relationship is defined using a foreign key, you can find using criteria against related tables
            var db = Database.Open();
            var customersWhoHaveBoughtWidgets = db.Customers.Find(db.Customers.Orders.OrderItems.Item.Name == "Widget");
        }
    }
}
