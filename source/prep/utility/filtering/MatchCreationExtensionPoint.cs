namespace prep.utility.filtering
{
  public class MatchCreationExtensionPoint<TItemToMatch, TPropertyType> :
    IProvideAccessToCreatingMatchers<TItemToMatch, TPropertyType>
  {
    PropertyAccessor<TItemToMatch, TPropertyType> accessor;

    public MatchCreationExtensionPoint(PropertyAccessor<TItemToMatch, TPropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IProvideAccessToCreatingMatchers<TItemToMatch, TPropertyType> not
    {
      get
      {
        return new NegatingMatchCreationExtensionPoint<TItemToMatch, TPropertyType>(this);
      }
    }

    public IMatchAn<TItemToMatch> create_specification_using(IMatchAn<TPropertyType> condition)
    {
      return new PropertyMatch<TItemToMatch, TPropertyType>(accessor, condition);
    }
  }
}