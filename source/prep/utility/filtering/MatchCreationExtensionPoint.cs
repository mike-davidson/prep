namespace prep.utility.filtering
{
  public class MatchCreationExtensionPoint<TItemToMatch, TPropertyType>
  {
    public PropertyAccessor<TItemToMatch, TPropertyType> accessor;

    public MatchCreationExtensionPoint(PropertyAccessor<TItemToMatch, TPropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public MatchCreationExtensionPoint<TItemToMatch,TPropertyType> not
    {
      get { throw new System.NotImplementedException(); }
    }
  }
}