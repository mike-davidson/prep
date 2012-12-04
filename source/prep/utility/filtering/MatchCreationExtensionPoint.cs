namespace prep.utility.filtering
{
  public class MatchCreationExtensionPoint<TItemToMatch, TPropertyType> :
    IExposeMatchingFunctionality<TItemToMatch, TPropertyType,IMatchAn<TItemToMatch>>
  {
    PropertyAccessor<TItemToMatch, TPropertyType> accessor;

    public MatchCreationExtensionPoint(PropertyAccessor<TItemToMatch, TPropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IExposeMatchingFunctionality<TItemToMatch, TPropertyType,IMatchAn<TItemToMatch>> not
    {
      get { return new NegatingMatchCreationExtensionPoint(this); }
    }

    public IMatchAn<TItemToMatch> create_dsl_result_using(IMatchAn<TPropertyType> condition)
    {
      return new PropertyMatch<TItemToMatch, TPropertyType>(accessor, condition);
    }

    class NegatingMatchCreationExtensionPoint : IExposeMatchingFunctionality<TItemToMatch, TPropertyType,IMatchAn<TItemToMatch>>
    {
      IExposeMatchingFunctionality<TItemToMatch, TPropertyType,IMatchAn<TItemToMatch>> original;

      public NegatingMatchCreationExtensionPoint(IExposeMatchingFunctionality<TItemToMatch, TPropertyType,IMatchAn<TItemToMatch>> original)
      {
        this.original = original;
      }

      public IMatchAn<TItemToMatch> create_dsl_result_using(IMatchAn<TPropertyType> condition)
      {
        return original.create_dsl_result_using(condition).not();
      }
    }
  }
}
