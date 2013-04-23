namespace SimpleDataSample
{
    internal class WithMethodSamples
    {
        internal void RunAll()
        {
            WithRunner.RunDemo(
                "Run With without a base command",
                db => db.Albums.WithArtists());

            WithRunner.RunDemo(
                "Run With returning a SimpleRecord - fluid style",
                db => db.Albums.WithArtists().Get(1));

            WithRunner.RunDemo(
                "Run With returning a SimpleRecord - named style",
                db => db.Albums.With(db.Albums.Artists).Get(1));

            WithRunner.RunDemo(
                "Run With returning a SimpleQuery - fluid style",
                db => db.Albums.All().WithArtists().FirstOrDefault());

            WithRunner.RunDemo(
                "Run With returning a SimpleQuery - named style",
                db => db.Albums.All().With(db.Albums.Artists).FirstOrDefault());

            WithRunner.RunDemo(
                "Run With but no arguments",
                db => db.Albums.All().With());

            WithRunner.RunDemo(
                "Run With with args in fluid and named style",
                db => db.Albums.All().WithArtists(db.Albums.Genre).FirstOrDefault());

            WithRunner.RunDemo(
                "Run With against a table with no FK relationship to primary",
                db => db.Albums.All().WithOrders().FirstOrDefault());

            WithRunner.RunDemo(
                "Run With against three child tables",
                db => db.Albums.All().WithArtists().WithGenre().FirstOrDefault());

            WithRunner.RunDemo(
                "Run With going two tables deep",
                db => db.OrderDetails.All().With(db.OrderDetails.Albums).With(db.OrderDetails.Albums.Artists),
                "OrderDetailList");
        }
    }
}