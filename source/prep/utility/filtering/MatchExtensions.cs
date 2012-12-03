namespace prep.utility.filtering
{
  public static class MatchExtensions
  {
    public static IMatchAn<TItem> not<TItem>(this IMatchAn<TItem> to_negate)
    {
      return new NegatingMatch<TItem>(to_negate);
    }

    public static IMatchAn<TItem> or<TItem>(this IMatchAn<TItem> left,
                                            IMatchAn<TItem> right)
    {
      return new OrMatch<TItem>(left, right);
    }
  }
}