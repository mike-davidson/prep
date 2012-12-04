namespace prep.utility.filtering
{
  public class NegatingMatchCreationExtensionPoint<TItemToMatch, TPropertyType> : IProvideAccessToCreatingMatchers<TItemToMatch, TPropertyType>
  {
    IProvideAccessToCreatingMatchers<TItemToMatch, TPropertyType> original;

    public NegatingMatchCreationExtensionPoint(IProvideAccessToCreatingMatchers<TItemToMatch, TPropertyType> original)
    {
      this.original = original;
    }

    public IMatchAn<TItemToMatch> create_specification_using(IMatchAn<TPropertyType> condition)
    {
      return original.create_specification_using(condition).not();
    }
  }
}