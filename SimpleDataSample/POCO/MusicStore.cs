using System;

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

    public override string ToString()
    {
      return string.Format("AlbumId: {0}; GenreId: {1}, ArtistId: {2}, Title: {3}, Price: {4:C}", AlbumId, GenreId, ArtistId, Title, Price);
    }
  }
}
