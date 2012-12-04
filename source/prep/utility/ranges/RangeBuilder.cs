using System;
using prep.utility.filtering;

namespace prep.utility.ranges
{
  public interface ISpecifyRangeOptions<T> : IRange<T> where T : IComparable<T>
  {
    IRange<T> Inclusive();
  }

  public interface IDontAllowUpperBoundSpecification<T> : ISpecifyRangeOptions<T> where T : IComparable<T>
  {
  }

  public class RangeBuilder<T> : IDontAllowUpperBoundSpecification<T> where T : IComparable<T>
  {
    IMatchAn<T> lower = new AlwaysMatches<T>();
    IMatchAn<T> lowerEqualTo = new AlwaysMatches<T>();
    IMatchAn<T> upper = new AlwaysMatches<T>();
    IMatchAn<T> upperEqualTo = new AlwaysMatches<T>();

    bool inclusive;

    public RangeBuilder<T> Lower(T item)
    {
      lower = new ConditionalMatch<T>(x => x.CompareTo(item) > 0);
      lowerEqualTo = new ConditionalMatch<T>(x => x.Equals(item));
      return this;
    }

    public IRange<T> Inclusive()
    {
      inclusive = true;
      return this;
    }

    public ISpecifyRangeOptions<T> upto(T item)
    {
      upper = new ConditionalMatch<T>(x => x.CompareTo(item) < 0);
      upperEqualTo = new ConditionalMatch<T>(x => x.Equals(item));
      return this;
    }

    IRange<T> create_match()
    {
      if (inclusive)
      {
        lower = lower.or(lowerEqualTo);
        upper = upper.or(upperEqualTo);
      }

      return new ContrainedRange<T>(lower.and(upper));
    }

    public bool contains(T value)
    {
      return create_match().contains(value);
    }
  }
}