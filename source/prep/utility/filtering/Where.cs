namespace prep.utility.filtering
{
  public class Where<TItemToMatch>
  {
    public static MatchFactory<TItemToMatch,TPropertyType> has_a<TPropertyType>(PropertyAccessor<TItemToMatch, TPropertyType> accessor)
    {
      return new MatchFactory<TItemToMatch, TPropertyType>(accessor);
    }
  }
}