using System;

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
      return new ConditionalMatch<TItemToMatch>(x => accessor(x).Equals(value_to_equal));
    }

    public IMatchAn<TItemToMatch> equal_to_any(params TPropertyType[] values)
    {
        foreach (TPropertyType ttype in values)
        {            
            return equal_to(ttype);
        }
        return null;
    }
  }
}