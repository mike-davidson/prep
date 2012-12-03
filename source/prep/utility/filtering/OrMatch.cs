namespace prep.utility.filtering
{
  public class OrMatch<TItem> : IMatchAn<TItem>
  {
    IMatchAn<TItem> left_side;
    IMatchAn<TItem> right_side;

    public OrMatch(IMatchAn<TItem> left_side, IMatchAn<TItem> right_side)
    {
      this.left_side = left_side;
      this.right_side = right_side;
    }

    public bool matches(TItem item)
    {
      return left_side.matches(item) || right_side.matches(item);
    }
  }
}