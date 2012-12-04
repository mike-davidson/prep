using System;

namespace prep.utility.ranges
{
  public class Range
  {
    public static RangeBuilder<T> starting_at<T>(T value) where T : IComparable<T>
    {
      return new RangeBuilder<T>().Lower(value);
    }
  }
}