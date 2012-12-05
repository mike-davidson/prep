using System.Collections.Generic;

namespace prep.utility.sorting
{
  public class PropertyComparer<TItemToSort,TPropertyType> : IComparer<TItemToSort>
  {
    PropertyAccessor<TItemToSort, TPropertyType> accessor;
    IComparer<TPropertyType> real_comparer;

    public PropertyComparer(PropertyAccessor<TItemToSort, TPropertyType> accessor, IComparer<TPropertyType> real_comparer)
    {
      this.accessor = accessor;
      this.real_comparer = real_comparer;
    }

    public int Compare(TItemToSort x, TItemToSort y)
    {
      return real_comparer.Compare(accessor(x), accessor(y));
    }
  }
}