using System;
using prep.utility.ranges;

namespace prep.utility.filtering
{
  public class ComparableMatchFactory<TItemToMatch, TPropertyType> : ICreateMatchers<TItemToMatch, TPropertyType>
    where TPropertyType : IComparable<TPropertyType>
  {
    ICreateMatchers<TItemToMatch, TPropertyType> original;

    public ComparableMatchFactory(ICreateMatchers<TItemToMatch, TPropertyType> original)
    {
      this.original = original;
    }

    public IMatchAn<TItemToMatch> greater_than(TPropertyType value)
    {
      return create_match_using(new FallsInRange<TPropertyType>(new RangeWithNoUpperBound<TPropertyType>(value)));
    }

    public IMatchAn<TItemToMatch> between(TPropertyType start, TPropertyType end)
    {
      return create_match_using(new FallsInRange<TPropertyType>(new RangeWithUpperAndLowerBound<TPropertyType>(start, end)));
    }

    public IMatchAn<TItemToMatch> equal_to(TPropertyType value_to_equal)
    {
      return original.equal_to(value_to_equal);
    }

    public IMatchAn<TItemToMatch> equal_to_any(params TPropertyType[] values)
    {
      return original.equal_to_any(values);
    }

    public IMatchAn<TItemToMatch> not_equal_to(TPropertyType value)
    {
      return original.not_equal_to(value);
    }

    public IMatchAn<TItemToMatch> create_match_using(IMatchAn<TPropertyType> condition)
    {
      return original.create_match_using(condition);
    }
  }
}