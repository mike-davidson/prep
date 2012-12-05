using System.Collections.Generic;

namespace prep.utility.sorting
{
  public class ReverseComparer<TItem> : IComparer<TItem>
  {
    IComparer<TItem> inner;

    public ReverseComparer(IComparer<TItem> inner)
    {
      this.inner = inner;
    }

    public int Compare(TItem x, TItem y)
    {
      return -inner.Compare(x, y);
    }
  }
}