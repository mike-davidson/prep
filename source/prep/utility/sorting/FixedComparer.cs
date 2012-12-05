using System.Collections.Generic;

namespace prep.utility.sorting
{
  public class FixedComparer<TPropertyType> : IComparer<TPropertyType>
  {
    IList<TPropertyType> rankings;

    public FixedComparer(params TPropertyType[] values)
    {
      this.rankings = new List<TPropertyType>(values);
    }

    public int Compare(TPropertyType x, TPropertyType y)
    {
      return rankings.IndexOf(x).CompareTo(rankings.IndexOf(y));
    }
  }
}