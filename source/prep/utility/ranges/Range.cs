using System;

namespace prep.utility.ranges
{
  public interface Range<T> where T : IComparable<T>
  {
    bool contains(T value);
  }

  public class RangeWithNoUpperBound<T> : Range<T> where T : IComparable<T>
  {
    T start;

    public RangeWithNoUpperBound(T start)
    {
      this.start = start;
    }

    public bool contains(T value)
    {
      return value.CompareTo(start) > 0;
    }
  }
}