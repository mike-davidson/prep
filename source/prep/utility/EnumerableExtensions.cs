using System.Collections.Generic;
using prep.utility.filtering;

namespace prep.utility
{
  public static class EnumerableExtensions
  {
    public static IEnumerable<TItem> one_at_a_time<TItem>(this IEnumerable<TItem> items)
    {
      foreach (var item in items) yield return item;
    }

    static IEnumerable<TItem> all_items_matching<TItem>(this IEnumerable<TItem> items,
                                                                Condition<TItem> condition)
    {
      foreach (var item in items) if (condition(item)) yield return item;
    }
    public static IEnumerable<TItem> all_items_matching<TItem>(this IEnumerable<TItem> items,
                                                                IMatchAn<TItem> specification)
    {
      return items.all_items_matching(specification.matches);
    }
  }
}