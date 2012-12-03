using System;

namespace prep.utility.filtering
{
  public class ComparableMatchFactory<TItemToMatch, TPropertyType>: ICreateMatchers<TItemToMatch,TPropertyType> where TPropertyType : IComparable<TPropertyType>
  {
    PropertyAccessor<TItemToMatch, TPropertyType> accessor;
    ICreateMatchers<TItemToMatch, TPropertyType> original;

    public ComparableMatchFactory(PropertyAccessor<TItemToMatch, TPropertyType> accessor, ICreateMatchers<TItemToMatch, TPropertyType> original)
    {
      this.accessor = accessor;
      this.original = original;
    }

    public IMatchAn<TItemToMatch> greater_than(TPropertyType value)
    {
      return match(x => accessor(x).CompareTo(value) > 0);
    }

    public IMatchAn<TItemToMatch> between(TPropertyType start, TPropertyType end)
    {
      return match(x => accessor(x).CompareTo(start) >= 0 && accessor(x).CompareTo(end) <= 0);
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

      public IMatchAn<TItemToMatch> match(Condition<TItemToMatch> condition)
      {
          return original.match(condition);
      }
  }
}