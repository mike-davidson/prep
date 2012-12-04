using System;
using prep.utility.ranges;

namespace prep.utility.filtering
{
  public static class FilteringExtensions
  {
    public static IMatchAn<TItemToMatch> equal_to<TItemToMatch,TPropertyType>(this MatchCreationExtensionPoint<TItemToMatch,TPropertyType> extension_point,TPropertyType value_to_equal)
    {
      return equal_to_any(extension_point,value_to_equal);
    }

    public static IMatchAn<TItemToMatch> equal_to_any<TItemToMatch,TPropertyType>(this MatchCreationExtensionPoint<TItemToMatch,TPropertyType> extension_point,params TPropertyType[] values)
    {
      return create_match_using(extension_point,new IsEqualToAny<TPropertyType>(values));
    }

    public static IMatchAn<TItemToMatch> create_match_using<TItemToMatch,TPropertyType>(this MatchCreationExtensionPoint<TItemToMatch,TPropertyType> extension_point,IMatchAn<TPropertyType> condition)
    {
        var match = new PropertyMatch<TItemToMatch, TPropertyType>(extension_point.accessor, condition);
        if (extension_point.Negate)
        {
            match = new PropertyMatch<TItemToMatch, TPropertyType>(extension_point.accessor, new NegatingMatch<TPropertyType>(condition));
        }
        return match;
    }

    public static IMatchAn<TItemToMatch> greater_than<TItemToMatch,TPropertyType>(this MatchCreationExtensionPoint<TItemToMatch,TPropertyType> extension_point,TPropertyType value) where TPropertyType : IComparable<TPropertyType>
    {
        return create_match_using(extension_point,new FallsInRange<TPropertyType>(Range.starting_at(value)));
    }

    public static IMatchAn<TItemToMatch> between<TItemToMatch,TPropertyType>(this MatchCreationExtensionPoint<TItemToMatch,TPropertyType> extension_point,TPropertyType start, TPropertyType end) where TPropertyType : IComparable<TPropertyType>
    {
        return create_match_using(extension_point,new FallsInRange<TPropertyType>(Range.starting_at(start).upto(end).Inclusive()));
    }
  }
}
