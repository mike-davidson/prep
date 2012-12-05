using System.Collections.Generic;

namespace prep.utility.sorting
{
  public class ChainedComparer<TItemToSort> : IComparer<TItemToSort>
  {
    IComparer<TItemToSort> first;
    IComparer<TItemToSort> second;

    public ChainedComparer(IComparer<TItemToSort> first, IComparer<TItemToSort> second)
    {
      this.first = first;
      this.second = second;
    }

    public int Compare(TItemToSort x, TItemToSort y)
    {
      var result = first.Compare(x, y);
      return result == 0 ? second.Compare(x, y) : result;
    }
  }
}