using System.Collections.Generic;

namespace prep.utility.filtering
{
  public class MatchFactory<TItemToMatch, TPropertyType> : ICreateMatchers<TItemToMatch, TPropertyType>
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
        return match(x => new List<TPropertyType>(values).Contains(accessor(x)));
    }

      public IMatchAn<TItemToMatch> match(Condition<TItemToMatch> condition)
      {
          return new ConditionalMatch<TItemToMatch>(condition);
      }

      public IMatchAn<TItemToMatch> not_equal_to(TPropertyType value)
    {
      return equal_to(value).not();
    }

  }
}