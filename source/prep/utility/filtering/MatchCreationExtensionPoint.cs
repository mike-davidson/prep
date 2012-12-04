namespace prep.utility.filtering
{
  public class MatchCreationExtensionPoint<TItemToMatch, TPropertyType>
  {
    public PropertyAccessor<TItemToMatch, TPropertyType> accessor;

    public MatchCreationExtensionPoint(PropertyAccessor<TItemToMatch, TPropertyType> accessor)
    {
      this.accessor = accessor;
    }
  }
}