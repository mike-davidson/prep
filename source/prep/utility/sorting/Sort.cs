using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prep.utility.sorting
{
    public class Sort<TItemToSort>
    {
        public static IContainComparers<TItemToSort> by<TPropertyType>
            (PropertyAccessor<TItemToSort, TPropertyType> accessor) where TPropertyType : IComparable<TPropertyType>
        {
            return new CustomComparer<TItemToSort, TPropertyType>(accessor);
        }

        public static IContainComparers<TItemToSort> by<TPropertyType>
            (PropertyAccessor<TItemToSort, TPropertyType> accessor, params TPropertyType[] values)
        {
           throw new NotImplementedException();
        }

        public static IContainComparers<TItemToSort> by_descending<TPropertyType>
            (PropertyAccessor<TItemToSort, TPropertyType> accessor) where TPropertyType : IComparable<TPropertyType>
        {
            return new DescendingComparer<TItemToSort, TPropertyType>(by(accessor));
        }
    }
}
