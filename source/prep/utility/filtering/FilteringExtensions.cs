using System;
using prep.utility.ranges;

namespace prep.utility.filtering
{
  public static class FilteringExtensions
  {
    public static TDslReturnType equal_to<TItemToMatch, TPropertyType,TDslReturnType>(
      this IExposeMatchingFunctionality<TItemToMatch, TPropertyType,TDslReturnType> extension_point, TPropertyType value_to_equal)
    {
      return equal_to_any(extension_point, value_to_equal);
    }

    public static TDslReturnType equal_to_any<TItemToMatch, TPropertyType,TDslReturnType>(
      this IExposeMatchingFunctionality<TItemToMatch, TPropertyType,TDslReturnType> extension_point, params TPropertyType[] values)
    {
      return create_match_using(extension_point, new IsEqualToAny<TPropertyType>(values));
    }

    public static TDslReturnType create_match_using<TItemToMatch, TPropertyType,TDslReturnType>(
      this IExposeMatchingFunctionality<TItemToMatch, TPropertyType,TDslReturnType> extension_point, IMatchAn<TPropertyType> condition)
    {
      return extension_point.create_dsl_result_using(condition);
    }

    public static TDslReturnType greater_than<TItemToMatch, TPropertyType,TDslReturnType>(
      this IExposeMatchingFunctionality<TItemToMatch, TPropertyType,TDslReturnType> extension_point, TPropertyType value)
      where TPropertyType : IComparable<TPropertyType>
    {
      return create_match_using(extension_point, new FallsInRange<TPropertyType>(Range.starting_at(value)));
    }

    public static TDslReturnType between<TItemToMatch, TPropertyType,TDslReturnType>(
      this IExposeMatchingFunctionality<TItemToMatch, TPropertyType,TDslReturnType> extension_point, TPropertyType start,
      TPropertyType end) where TPropertyType : IComparable<TPropertyType>
    {
      return create_match_using(extension_point,
                                new FallsInRange<TPropertyType>(Range.starting_at(start).upto(end).Inclusive()));
    }
  }
}
