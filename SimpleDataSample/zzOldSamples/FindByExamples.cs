using System;
using Simple.Data;

namespace SimpleDataSample.Samples
{
    internal class FindByExamples
    {
        public static void AllExample()
        {
            dynamic db = Database.Open(); // Opens the default database, as specified in config
            foreach (dynamic customer in db.Customers.All())
            {
                Console.WriteLine(customer.Name);
            }
        }

        public static void BasicFindBy()
        {
            dynamic db = Database.Open(); // Opens the default database, as specified in config
            dynamic customer = db.Customers.FindByCustomerId(1);
            Console.WriteLine(customer.Name);
        }

        public static void TwoColumnFindBy()
        {
            dynamic db = Database.Open();
            dynamic user = db.Users.FindByNameAndPassword("Bob", "Secret");
            Console.WriteLine(user.Id);
        }

        public static void FindAllByReturnsMultipleRows()
        {
            dynamic db = Database.Open();
            foreach (dynamic user in db.Users.FindAllByAge(42))
            {
                Console.WriteLine(user.Name + " is 42");
            }
        }

        public static void FindWithOperators()
        {
            dynamic db = Database.Open();
            foreach (dynamic user in db.Users.FindAll(db.Users.Age >= 40))
            {
                Console.WriteLine(user.Name + " is over 40");
            }
            /*
             * Supported operators: ==, !=, <, <=, >, >=
             */
        }

        public static void FindWithMultipleOperators()
        {
            dynamic db = Database.Open();
            foreach (dynamic user in db.Users.FindAll(db.Users.Age >= 40 && db.Users.Age < 50))
            {
                Console.WriteLine(user.Name + " is 40-something");
            }
            /*
             * Supported operators: && and ||, and grouping using ()
             */
        }

        public static void FindWithLikeOperator()
        {
            dynamic db = Database.Open();
            foreach (dynamic user in db.Users.FindAll(db.Users.Name.Like("B%")))
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
            dynamic db = Database.Open();
            dynamic customersWhoHaveBoughtWidgets =
                db.Customers.Find(db.Customers.Orders.OrderItems.Item.Name == "Widget");
        }
    }
}