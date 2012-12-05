using System;
using System.Collections.Generic;

namespace prep.utility.sorting
{
  public class ComparableComparer<TPropertyType> : IComparer<TPropertyType>
    where TPropertyType : IComparable<TPropertyType>
  {
    public int Compare(TPropertyType x, TPropertyType y)
    {
      return x.CompareTo(y);
    }
  }
}