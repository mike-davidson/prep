using System;

namespace prep.utility.filtering
{
  public class IsBetween<T> : IMatchAn<T> where T : IComparable<T>
  {
    T start;
    T end;

    public IsBetween(T start, T end)
    {
      this.start = start;
      this.end = end;
    }

    public bool matches(T item)
    {
      return item.CompareTo(start) >= 0 && item.CompareTo(end) <= 0;
    }
  }

  public class IsGreaterThan<T> : IMatchAn<T> where T : IComparable<T>
  {
    T start;

    public IsGreaterThan(T start)
    {
      this.start = start;
    }

    public bool matches(T item)
    {
      return item.CompareTo(start) > 0;
    }
  }
}