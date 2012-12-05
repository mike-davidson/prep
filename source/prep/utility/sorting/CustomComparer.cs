using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prep.utility.sorting
{
    public class CustomComparer<TItem, TPropertyType> : IContainComparers<TItem> where TPropertyType : IComparable<TPropertyType>
    {
        private IContainComparers<TItem> secondaryComparer = new AlwaysEqualComparer<TItem,TPropertyType>();
        private PropertyAccessor<TItem, TPropertyType> accessor;

        public CustomComparer(PropertyAccessor<TItem, TPropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public IContainComparers<TItem> SecondaryComparer
        {
            set { secondaryComparer = value; }
        }

        public int Compare(TItem x, TItem y)
        {

            TPropertyType t1 = accessor(x);
            TPropertyType t2 = accessor(y);

            int results = t1.CompareTo(t2);
            if (results == 0)
            {
                results = secondaryComparer.Compare(x, y);
            }

            return results;
        }
    }
}
