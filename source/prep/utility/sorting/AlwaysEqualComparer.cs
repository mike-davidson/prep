using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prep.utility.sorting
{
    public class AlwaysEqualComparer<TItem, TPropertyType>: IContainComparers<TItem> where TPropertyType : IComparable<TPropertyType>
    {
        private IContainComparers<TItem> secondary;

        public IContainComparers<TItem> SecondaryComparer
        {
            set { secondary = value; }
        }

        public int Compare(TItem x, TItem y)
        {
            return 0;
        }
    }
}
