using System.Collections.Generic;
using prep.collections;

namespace prep.utility.filtering
{
  public class MatchFactory<TItemToMatch, TPropertyType>
  {
    PropertyAccessor<TItemToMatch, TPropertyType> accessor;

    public MatchFactory(PropertyAccessor<TItemToMatch, TPropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<TItemToMatch> equal_to(TPropertyType value_to_equal)
    {
      return equal_to_any(value_to_equal);
    }

    public IMatchAn<TItemToMatch> equal_to_any(params TPropertyType[] values)
    {
      return new ConditionalMatch<TItemToMatch>(x => new List<TPropertyType>(values).Contains(accessor(x)));
    }

    public IMatchAn<TItemToMatch> not_equal_to(TPropertyType value)
    {
      throw new System.NotImplementedException();
    }
  }
}