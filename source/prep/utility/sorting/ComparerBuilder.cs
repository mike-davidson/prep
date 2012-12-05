using System;
using System.Collections.Generic;

namespace prep.utility.sorting
{
  public interface IBuildComparers<TItemToSort> : IComparer<TItemToSort>
  {
    IContinueComparisonBuilding<TItemToSort> by<TPropertyType>(
      PropertyAccessor<TItemToSort, TPropertyType> accessor)
      where TPropertyType : IComparable<TPropertyType>;

    IContinueComparisonBuilding<TItemToSort> by<TPropertyType>(PropertyAccessor<TItemToSort, TPropertyType> accessor,
                                                                   params TPropertyType[] fixed_order);

    IContinueComparisonBuilding<TItemToSort> by_descending<TPropertyType>(PropertyAccessor<TItemToSort, TPropertyType> accessor)
      where TPropertyType : IComparable<TPropertyType>;
  }

  public interface IContinueComparisonBuilding<TItemToSort> : IComparer<TItemToSort>
  {
    IContinueComparisonBuilding<TItemToSort> then_by<TPropertyType>(
      PropertyAccessor<TItemToSort, TPropertyType> accessor)
      where TPropertyType : IComparable<TPropertyType>;

    IContinueComparisonBuilding<TItemToSort> then_by<TPropertyType>(PropertyAccessor<TItemToSort, TPropertyType> accessor,
                                                                        params TPropertyType[] fixed_order);

    IContinueComparisonBuilding<TItemToSort> then_by_descending<TPropertyType>(
      PropertyAccessor<TItemToSort, TPropertyType> accessor)
      where TPropertyType : IComparable<TPropertyType>;
  }

  public class ComparerBuilder<TItemToSort> : IBuildComparers<TItemToSort>,IContinueComparisonBuilding<TItemToSort>
  {
    IComparer<TItemToSort> comparer;

    public ComparerBuilder(IComparer<TItemToSort> comparer)
    {
      this.comparer = comparer;
    }

    public int Compare(TItemToSort x, TItemToSort y)
    {
      return comparer.Compare(x, y);
    }

    public IContinueComparisonBuilding<TItemToSort> by<TPropertyType>(
      PropertyAccessor<TItemToSort, TPropertyType> accessor)
      where TPropertyType : IComparable<TPropertyType>
    {
      return then_by(accessor);
    }

    public IContinueComparisonBuilding<TItemToSort> by<TPropertyType>(PropertyAccessor<TItemToSort, TPropertyType> accessor,
                                                          params TPropertyType[] fixed_order)
    {
      return then_by(accessor, fixed_order);
    }

    public IContinueComparisonBuilding<TItemToSort> by_descending<TPropertyType>(PropertyAccessor<TItemToSort, TPropertyType> accessor)
      where TPropertyType : IComparable<TPropertyType>
    {
      return then_by_descending(accessor);
    }

    public IContinueComparisonBuilding<TItemToSort> then_by<TPropertyType>(
      PropertyAccessor<TItemToSort, TPropertyType> accessor)
      where TPropertyType : IComparable<TPropertyType>
    {
      return new ComparerBuilder<TItemToSort>(comparer.chain_with(Sort<TItemToSort>.by(accessor)));
    }

    public IContinueComparisonBuilding<TItemToSort> then_by<TPropertyType>(PropertyAccessor<TItemToSort, TPropertyType> accessor,
                                                               params TPropertyType[] fixed_order)
    {
      return new ComparerBuilder<TItemToSort>(comparer.chain_with(Sort<TItemToSort>.by(accessor, fixed_order)));
    }

    public IContinueComparisonBuilding<TItemToSort> then_by_descending<TPropertyType>(
      PropertyAccessor<TItemToSort, TPropertyType> accessor)
      where TPropertyType : IComparable<TPropertyType>
    {
      return new ComparerBuilder<TItemToSort>(comparer.chain_with(Sort<TItemToSort>.by(accessor,SortDirection.descending)));
    }
  }
}