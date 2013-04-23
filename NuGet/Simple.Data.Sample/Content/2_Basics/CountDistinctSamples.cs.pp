using System.Collections.Generic;

namespace $rootnamespace$
{
    internal class CountDistinctSamples
    {
        internal void RunAll()
        {
            //select distinct orderid from OrderDetails
            ExampleRunner.RunQuery(
                "Get distinct order ids from OrderDetails using OrderId.Distinct()",
                db => db.OrderDetails.All()
                        .Select(
                            db.OrderDetails.OrderId.Distinct()),
                new List<string> {"OrderId"});

            //select distinct orderid, albumid from OrderDetails
            ExampleRunner.RunQuery(
                "Get distinct order ids and albumid from OrderDetails using OrderId.Distinct",
                db => db.OrderDetails.All()
                        .Select(
                            db.OrderDetails.OrderId.Distinct(),
                            db.OrderDetails.AlbumId),
                new List<string> {"OrderId", "AlbumId"});

            //select count(orderid) from OrderDetails
            ExampleRunner.RunQuery(
                "select count(orderid) from OrderDetails using OrderId.Count()",
                db => db.OrderDetails.All()
                        .Select(
                            db.OrderDetails.OrderId.Count()),
                new List<string> {""});

            //select count(orderid) from OrderDetails
            ExampleRunner.RunQuery(
                "select count(*) from OrderDetails using db.OrderDetails.Count()",
                db => db.OrderDetails.Count(),
                new List<string> {""});

            //select count(distinct orderid) from orderdetails using .distinct().count()
            ExampleRunner.RunQuery(
                "select count(distinct orderid) from orderdetails",
                db => db.orderdetails.all()
                        .select(
                            db.orderdetails.orderid.distinct().count()),
                new List<string> {""});

            //select distinct count(orderid) from OrderDetails
            ExampleRunner.RunQuery(
                "select count(distinct orderid) from OrderDetails",
                db => db.OrderDetails.All()
                        .Select(
                            db.OrderDetails.OrderId.Count().Distinct()),
                new List<string> {""});

            //select count(distinct orderid) from OrderDetails
            ExampleRunner.RunQuery(
                "select count(distinct orderid) from OrderDetails",
                db => db.OrderDetails.All()
                        .Select(
                            db.OrderDetails.OrderId.CountDistinct()),
                new List<string> {""});
        }
    }
}