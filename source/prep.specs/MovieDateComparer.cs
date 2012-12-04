using System.Collections.Generic;
using prep.collections;

namespace prep.specs
{
  public class MovieDateComparer : IComparer<Movie>
  {
    public int Compare(Movie x, Movie y)
    {
      return x.date_published.CompareTo(y.date_published);
    }
  }
}