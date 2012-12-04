using System.Collections.Generic;
using prep.utility.filtering;

namespace prep.utility
{
  public static class EnumerableFilteringExtensions
  {
    public static GeneralMatchFunctionalityExtensionPoint<TItemToMatch, TPropertyType,IEnumerable<TItemToMatch>> where<TItemToMatch, TPropertyType>(
      this IEnumerable<TItemToMatch> items, PropertyAccessor<TItemToMatch, TPropertyType> accessor)
    {
      return
        new GeneralMatchFunctionalityExtensionPoint<TItemToMatch, TPropertyType,IEnumerable<TItemToMatch>>(
          x => items.all_items_matching(Where<TItemToMatch>.has_a(accessor).create_dsl_result_using(x)));
    }
  }
}