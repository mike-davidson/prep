using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prep.utility.sorting
{
    public static class SortingExtensions
    {
        public static IContainComparers<TItemToSort> then_by<TItemToSort, TPropertyType>(
        this IContainComparers<TItemToSort> comparer, PropertyAccessor<TItemToSort, TPropertyType> accessor) where TPropertyType : IComparable<TPropertyType>
        {
            return comparer.SecondaryComparer = new CustomComparer<TItemToSort, TPropertyType>(accessor);
        }
    }
}
