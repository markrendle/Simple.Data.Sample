using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Simple.Data;

namespace SimpleDataSample.Samples
{
    class DeleteExamples
    {
        public static void DeleteBy()
        {
            var db = Database.Open();
            int deletedCount = db.Customers.DeleteById(3);
            Console.WriteLine(deletedCount);
        }
    }
}
