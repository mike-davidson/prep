using System.Collections.Generic;

namespace prep.utility.sorting
{
  public interface IApplyASortDirection
  {
    IComparer<TItemToSort> apply_to<TItemToSort>(IComparer<TItemToSort> original);
  }

  public class SortDirection
  {
    public static readonly IApplyASortDirection ascending = new AscendingSortDirection();
    public static readonly IApplyASortDirection descending = new DescendingSortDirection();
  }

  public class DescendingSortDirection : IApplyASortDirection
  {
    public IComparer<TItemToSort> apply_to<TItemToSort>(IComparer<TItemToSort> original)
    {
      return new ReverseComparer<TItemToSort>(original);
    }
  }

  public class AscendingSortDirection : IApplyASortDirection
  {
    public IComparer<TItemToSort> apply_to<TItemToSort>(IComparer<TItemToSort> original)
    {
      return original;
    }
  }
}