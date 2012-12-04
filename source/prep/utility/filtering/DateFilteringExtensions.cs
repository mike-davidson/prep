using System;

namespace prep.utility.filtering
{
  public static class DateFilteringExtensions
  {
    public static TDslReturnType greater_than<TItemToMatch,TDslReturnType>(this IExposeMatchingFunctionality<TItemToMatch,DateTime,TDslReturnType> extension_point,int value) 
    {
      return extension_point.create_dsl_result_using(Where<DateTime>.has_a(x => x.Year).greater_than(value));
    }
  }
}
