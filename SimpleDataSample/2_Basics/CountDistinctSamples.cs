namespace SimpleDataSample
{
  class CountDistinctSamples
  {
    internal void RunAll()
    {
      //select distinct orderid from OrderDetails
      ExampleRunner.RunQuery(
            "Get distinct order ids from OrderDetails using OrderId.Distinct()",
            db => db.OrderDetails.All()
              .Select(
                db.OrderDetails.OrderId.Distinct()),
                "OrderId");

      //select distinct orderid, albumid from OrderDetails
      ExampleRunner.RunQuery(
        "Get distinct order ids and albumid from OrderDetails using OrderId.Distinct",
        db => db.OrderDetails.All()
          .Select(
          db.OrderDetails.OrderId.Distinct(),
          db.OrderDetails.AlbumId),
          "OrderId", "AlbumId");

      //select count(orderid) from OrderDetails
      ExampleRunner.RunQuery(
        "select count(orderid) from OrderDetails using OrderId.Count()",
            db => db.OrderDetails.All()
              .Select(
                db.OrderDetails.OrderId.Count()),
                "");

      //select count(orderid) from OrderDetails
      ExampleRunner.RunQuery(
        "select count(*) from OrderDetails using db.OrderDetails.Count()",
            db => db.OrderDetails.Count(),
                "");

      //select count(distinct orderid) from orderdetails using .distinct().count()
      ExampleRunner.RunQuery(
        "select count(distinct orderid) from orderdetails",
                    db => db.orderdetails.all()
              .select(
                db.orderdetails.orderid.distinct().count()),
                "");

      //select distinct count(orderid) from OrderDetails
      ExampleRunner.RunQuery(
        "select count(distinct orderid) from OrderDetails",
                    db => db.OrderDetails.All()
              .Select(
                db.OrderDetails.OrderId.Count().Distinct()),
                "");

      //select count(distinct orderid) from OrderDetails
      ExampleRunner.RunQuery(
        "select count(distinct orderid) from OrderDetails",
                    db => db.OrderDetails.All()
              .Select(
                db.OrderDetails.OrderId.CountDistinct()),
                "");

    }
  }
}
