namespace prep.utility.filtering
{
  public class Where<TItemToMatch>
  {
    public static MatchCreationExtensionPoint<TItemToMatch, TPropertyType> has_a
      <TPropertyType>(
      PropertyAccessor<TItemToMatch, TPropertyType> accessor)
    {
      return new MatchCreationExtensionPoint<TItemToMatch, TPropertyType>(accessor);

    }
  }
}