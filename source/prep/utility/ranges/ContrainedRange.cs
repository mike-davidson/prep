using System;
using prep.utility.filtering;

namespace prep.utility.ranges
{
  public class ContrainedRange<T> : IRange<T> where T : IComparable<T>
  {
    IMatchAn<T> range_spec;

    public ContrainedRange(IMatchAn<T> range_spec)
    {
      this.range_spec = range_spec;
    }

    public bool contains(T value)
    {
      return range_spec.matches(value);
    }
  }
}