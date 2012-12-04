namespace prep.utility.filtering
{
  public class MatchCreationExtensionPoint<TItemToMatch, TPropertyType>
  {
    public PropertyAccessor<TItemToMatch, TPropertyType> accessor;
    private bool negate = false;

    public MatchCreationExtensionPoint(PropertyAccessor<TItemToMatch, TPropertyType> accessor)
    {
      this.accessor = accessor;
    }

    private MatchCreationExtensionPoint(PropertyAccessor<TItemToMatch, TPropertyType> accessor, bool negate)
    {
        this.accessor = accessor;
        this.negate = negate;
    } 

      public bool Negate
      {
          get { return negate; }
      }

    public MatchCreationExtensionPoint<TItemToMatch,TPropertyType> not
    {
        get { return new MatchCreationExtensionPoint<TItemToMatch, TPropertyType>(accessor, true); }
    }
  }
}