using System.Collections.Generic;
using prep.utility.filtering;

namespace prep.utility
{
  public static class EnumerableFilteringExtensions
  {
    public static EnumerableMatchingExtensionPoint<TItemToMatch, TPropertyType> where<TItemToMatch, TPropertyType>(
      this IEnumerable<TItemToMatch> items, PropertyAccessor<TItemToMatch, TPropertyType> accessor)
    {
      return
        new EnumerableMatchingExtensionPoint<TItemToMatch, TPropertyType>(items,
                                                                          Where<TItemToMatch>.has_a(accessor));
    }
  }
}