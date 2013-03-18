using System;
using Simple.Data;

namespace SimpleDataSample.Samples
{
    internal class DeleteExamples
    {
        public static void DeleteBy()
        {
            dynamic db = Database.Open();
            int deletedCount = db.Customers.DeleteById(3);
            Console.WriteLine(deletedCount);
        }
    }
}