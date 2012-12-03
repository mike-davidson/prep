using System;

namespace prep.utility.filtering
{
  public class ComparableMatchFactory<TItemToMatch, TPropertyType> where TPropertyType : IComparable<TPropertyType>
  {
    PropertyAccessor<TItemToMatch, TPropertyType> accessor;

    public ComparableMatchFactory(PropertyAccessor<TItemToMatch, TPropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<TItemToMatch> greater_than(TPropertyType value)
    {
      return new ConditionalMatch<TItemToMatch>(x => accessor(x).CompareTo(value) > 0);
    }

    public IMatchAn<TItemToMatch> between(TPropertyType start, TPropertyType end)
    {
      throw new NotImplementedException();
    }
  }
}