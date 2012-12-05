using System;
using System.Collections.Generic;

namespace prep.utility.sorting
{
  public class Sort<TItemToSort>
  {
    public static IComparer<TItemToSort> using_strategy<TPropertyType>(
      PropertyAccessor<TItemToSort, TPropertyType> accessor, IComparer<TPropertyType> sort_strategy)
    {
      return new PropertyComparer<TItemToSort, TPropertyType>(accessor,
                                                              sort_strategy);
    }

    public static IComparer<TItemToSort> by<TPropertyType>
      (PropertyAccessor<TItemToSort, TPropertyType> accessor,IApplyASortDirection direction)
      where TPropertyType : IComparable<TPropertyType>
    {
      return direction.apply_to(using_strategy(accessor, new ComparableComparer<TPropertyType>()));
    }
    public static IComparer<TItemToSort> by<TPropertyType>
      (PropertyAccessor<TItemToSort, TPropertyType> accessor)
      where TPropertyType : IComparable<TPropertyType>
    {
      return by(accessor, SortDirection.ascending);
    }

    public static IComparer<TItemToSort> by<TPropertyType>
      (PropertyAccessor<TItemToSort, TPropertyType> accessor, params TPropertyType[] fixed_order)
    {
      return using_strategy(accessor, new FixedComparer<TPropertyType>(fixed_order));
    }
  }
}