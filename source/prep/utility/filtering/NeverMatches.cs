namespace prep.utility.filtering
{
  public class NeverMatches<TItemToMatch> : IMatchAn<TItemToMatch>
  {
    public bool matches(TItemToMatch item)
    {
      return false;
    }
  }
}