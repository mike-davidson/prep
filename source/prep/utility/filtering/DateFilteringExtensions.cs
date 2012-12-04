using System;

namespace prep.utility.filtering
{
  public static class DateFilteringExtensions
  {
    public static IMatchAn<TItemToMatch> greater_than<TItemToMatch>(this IProvideAccessToCreatingMatchers<TItemToMatch,DateTime> extension_point,int value) 
    {
      return extension_point.create_match_using(Where<DateTime>.has_a(x => x.Year).greater_than(value));
    }
  }
}
