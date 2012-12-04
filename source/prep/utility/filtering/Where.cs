using System;

namespace prep.utility.filtering
{
  public class Where<TItemToMatch> 
  {
    public static MatchFactory<TItemToMatch,TPropertyType> has_a<TPropertyType>(PropertyAccessor<TItemToMatch, TPropertyType> accessor) 
    {
      return new MatchFactory<TItemToMatch, TPropertyType>(accessor);
    }

    public static ComparableMatchFactory<TItemToMatch,TPropertyType> has_an<TPropertyType>(PropertyAccessor<TItemToMatch,TPropertyType> accessor) where TPropertyType : IComparable<TPropertyType>
    {
      return new ComparableMatchFactory<TItemToMatch, TPropertyType>(has_a(accessor));
    }
  }
}