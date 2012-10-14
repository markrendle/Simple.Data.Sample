using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDataSample.POCO
{
  public class Album
  {
    public int AlbumId { get; set; }
    public int GenreId { get; set; }
    public int ArtistId { get; set; }
    public string Title { get; set; }
    public float Price { get; set; }
    public string AlbumArtUrl { get; set; }
    public Genre Genre { get; set; }
    public Artist Artist { get; set; }


    public override string ToString()
    {
      StringBuilder sb = new StringBuilder(string.Format("Album. AlbumId: {0}; GenreId: {1}, ArtistId: {2}, Title: {3}, Price: {4:C}", AlbumId, GenreId, ArtistId, Title, Price));

      if (Genre != null)
      {
        sb.AppendLine();
        sb.Append(Genre.ToString());
      }

      if (Artist != null)
      {
        sb.AppendLine();
        sb.Append(Artist.ToString());
      }

      return sb.ToString();
    }
  }

  public class Genre
  {
    public int GenreId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public override string ToString()
    {
      return String.Format("Genre. Id : {0}, Name : {1}, Description : {2}", GenreId, Name, Description);
    }
  }

  public class Artist
  {
    public int ArtistId { get; set; }
    public string Name { get; set; }
    public List<Album> Albums { get; set; }

    public override string ToString()
    {
      return String.Format("Artist. Id : {0}, Name : {1}", ArtistId, Name);
    }
  }

  public class CartRecord
  {
    public int RecordId { get; set; }
    public int CartId { get; set; }
    public int AlbumId { get; set; }
    public int Count { get; set; }
    public DateTime DateCreated { get; set; }
    public Album Album { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder(
        String.Format("CartRecord. RecordId = {0}, CartId = {1}, AlbumId = {2}, Count = {3}, DateCreated = {4}",
        RecordId, CartId, AlbumId, Count, DateCreated.ToShortDateString()));

      if (Album != null)
      {
        sb.AppendLine();
        sb.Append(Album.ToString());
      }

      return sb.ToString();
    }

  }

  public class OrderDetails
  {
    public int OrderDetailId { get; set; }
    public int OrderId { get; set; }
    public int AlbumId { get; set; }
    public int Quantity { get; set; }
    public float UnitPrice { get; set; }

    public Album Album { get; set; }
    public Order Order { get; set; }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder(
  String.Format("OrderDetail. OrderDetailId = {0}, OrderId = {1}, AlbumId = {2}, Quantity = {3}, UnitPrice = {4:C}",
  OrderDetailId, OrderId, AlbumId, Quantity, UnitPrice));

      if (Album != null)
      {
        sb.AppendLine();
        sb.Append(Album.ToString());
      }

      if (Order != null)
      {
        sb.AppendLine();
        sb.Append(Order.ToString());
      }

      return sb.ToString();
    }

  }

  public class Order
  {
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public float Total { get; set; }

    public override string ToString()
    {
      return String.Format(
        "Order. OrderId = {0}, OrderDate = {1}, Name = {2} {3}, Total = {4:C}",
        OrderId, OrderDate.ToShortDateString(), FirstName, LastName, Total);
    }
  }
}
