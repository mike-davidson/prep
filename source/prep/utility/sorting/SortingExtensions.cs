using System;
using System.Collections.Generic;

namespace prep.utility.sorting
{
  public delegate int ICompareTwoValuesOf<TValue>(TValue first, TValue second);

  public static class SortingExtensions
  {
    public static IComparer<TItemToSort> chain_with<TItemToSort>(this IComparer<TItemToSort> first,
                                                                 IComparer<TItemToSort> second)
    {
      return new ChainedComparer<TItemToSort>(first, second);
    }

    public static IComparer<TItemToSort> then_by<TItemToSort, TPropertyType>(this IComparer<TItemToSort> first,
                                                                             PropertyAccessor
                                                                               <TItemToSort, TPropertyType> accessor)
      where TPropertyType : IComparable<TPropertyType>
    {
      return first.chain_with(Sort<TItemToSort>.by(accessor));
    }
  }
}