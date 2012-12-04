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

  public class RangeWithUpperAndLowerBound<T> : Range<T> where T : IComparable<T>
  {
      T start;
      T end;

      public RangeWithUpperAndLowerBound(T start, T end)
      {
          this.start = start;
          this.end = end;
      }

      public bool contains(T value)
      {
          return value.CompareTo(start) >= 0 && value.CompareTo(end) <= 0;
      }
  }

  public class RangeWithNoLowerBound<T> : Range<T> where T : IComparable<T>
  {
      T end;

      public RangeWithNoLowerBound(T end)
      {
          this.end = end;
      }

      public bool contains(T value)
      {
          return value.CompareTo(end) < 0;
      }
  }
}