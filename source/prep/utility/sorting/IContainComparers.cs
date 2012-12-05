using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prep.utility.sorting
{
    public interface IContainComparers<TItemToSort> : IComparer<TItemToSort>
    {
        IContainComparers<TItemToSort> SecondaryComparer { set; }
    }
}
