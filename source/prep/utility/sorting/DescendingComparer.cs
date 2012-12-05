using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prep.utility.sorting
{
    public class DescendingComparer<TItem, TPropertyType> : IContainComparers<TItem> where TPropertyType : IComparable<TPropertyType>
    {
        private IContainComparers<TItem> innerComparer;

        public DescendingComparer(IContainComparers<TItem> innerComparer)
        {
            this.innerComparer = innerComparer;
        }

        public int Compare(TItem x, TItem y)
        {
            int result = innerComparer.Compare(x, y);

            if (result != 0)
            {
                result = result*-1;
            }
            return result;
        }
                
        public IContainComparers<TItem> SecondaryComparer { set { innerComparer.SecondaryComparer = value; } }
    }
}
