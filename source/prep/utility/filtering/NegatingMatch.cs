namespace prep.utility.filtering
{
  public class NegatingMatch<TItemToMatch> : IMatchAn<TItemToMatch>
  {
    IMatchAn<TItemToMatch> original;

    public NegatingMatch(IMatchAn<TItemToMatch> original)
    {
      this.original = original;
    }

    public bool matches(TItemToMatch item)
    {
      return ! original.matches(item);
    }
  }
}