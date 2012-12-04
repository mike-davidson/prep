using System;
using System.Collections;
using System.Collections.Generic;
using prep.utility.filtering;

namespace prep.utility
{
  public static class FilteringEnumerableExtensions
  {
    public static FilteredIterator<TItemToMatch, TPropertyType> where<TItemToMatch, TPropertyType>(
      this IEnumerable<TItemToMatch> items,
      PropertyAccessor<TItemToMatch, TPropertyType> accessor) where TPropertyType : IComparable<TPropertyType>
    {
      return new FilteredIterator<TItemToMatch, TPropertyType>(accessor, items);
    }
  }

  public class FilteredIterator<TItem, TPropertyType> : IEnumerable<TItem>
    where TPropertyType : IComparable<TPropertyType>
  {
    PropertyAccessor<TItem, TPropertyType> accessor;
    IEnumerable<TItem> items;
    IMatchAn<TItem> criteria;

    public FilteredIterator(PropertyAccessor<TItem, TPropertyType> accessor, IEnumerable<TItem> items)
    {
      this.accessor = accessor;
      this.items = items;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<TItem> GetEnumerator()
    {
      return items.all_items_matching(criteria).GetEnumerator();
    }

    public IEnumerable<TItem> greater_than(TPropertyType value)
    {
      criteria = Where<TItem>.has_a(accessor).greater_than(value);
      return this;
    }
  }
}