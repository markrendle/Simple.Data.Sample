using System.Text;
namespace SimpleDataSample
{
  class WhereMethodSamples
  {
    internal void RunAll()
    {
      ExampleRunner.QueryAlbums(
            "Where() called without query command. db.Albums.Where(db.Albums.GenreId == 1)",
            db => db.Albums.Where(db.Albums.GenreId == 1));

      ExampleRunner.QueryAlbums(
            "Where called without no parameters. db.Albums.All().Where()",
            db => db.Albums.All().Where());

      ExampleRunner.QueryAlbums(
          "Where called with invalid SimpleExpression as parameter. FIeld name wrong",
          db => db.Albums.All().Where(db.Albums.NonExistentColumn == 1));

      ExampleRunner.QueryAlbums(
        "Where called with two valid SimpleExpressions as parameters.",
        db => db.Albums.All().Where(db.Albums.GenreId == 1, db.Albums.ArtistId == 120));

      ExampleRunner.QueryAlbums(
        "db.Albums.All().Where(db.Albums.GenreId == 1). Where clause added",
        db => db.Albums.All().Where(db.Albums.GenreId == 1));

      ExampleRunner.QueryAlbums(
        "db.Albums.All().Where(db.Albums.GenreId == 1).Where(db.Albums.ArtistId == 120). Where clauses added and concatenated with AND",
        db => db.Albums.All().Where(db.Albums.GenreId == 1).Where(db.Albums.ArtistId == 120));

      ExampleRunner.QueryAlbums(
        "db.Albums.FindAllByGenreId(1).Where(db.Albums.ArtistId == 120). Where clause concatenated with AND",
        db => db.Albums.FindAllByGenreId(1).Where(db.Albums.ArtistId == 120));

      ExampleRunner.QueryAlbums(
        "Concatenate two SimpleExpressions using OR",
        db => OrTwoExpressions(db));

      ExampleRunner.QueryAlbums(
      "Concatenate two ORed SimpleExpressions with a third. Use Where to concatenate",
      db => db.Albums.FindAll(db.Albums.GenreId == 1 || db.Albums.GenreId == 2).Where(db.Albums.ArtistId == 120));

      ExampleRunner.QueryAlbums(
        "Concatenate two ORed SimpleExpressions with a third. Build SimpleExpression first",
        db => OrAndThreeExpressions(db));

      ExampleRunner.QueryAlbums(
        "db.Albums.All().Where(db.Albums.Title == \"Dark Side of the Moon\"); String Comparison",
        db => db.Albums.All().Where(db.Albums.Title == "Dark Side Of The Moon"));

      ExampleRunner.QueryAlbums(
        "Compare string field to production of StringBuilder. db.Albums.Title == sb.ToString()",
        db => CompareStringBuilderProduction(db));
    }

    private dynamic CompareStringBuilderProduction(dynamic db)
    {
      StringBuilder sb = new StringBuilder("Dark Side ");
      sb.Append("Of The Moon");
      return db.Albums.All().Where(db.Albums.Title == sb.ToString());
    }

    private dynamic OrTwoExpressions(dynamic db)
    {
      var expr1 = db.Albums.GenreId == 1;
      var expr2 = db.Albums.ArtistId == 120;
      return db.Albums.All().Where(expr1 || expr2);
    }

    private dynamic OrAndThreeExpressions(dynamic db)
    {
      var expr1 = db.Albums.GenreId == 1;
      var expr2 = db.Albums.GenreId == 1;
      var expr3 = db.Albums.ArtistId == 120;
      return db.Albums.All().Where((expr1 || expr2) && expr3);
    }
  }
}
