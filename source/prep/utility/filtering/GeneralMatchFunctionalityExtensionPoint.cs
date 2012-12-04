namespace prep.utility.filtering
{
  public class GeneralMatchFunctionalityExtensionPoint<TItemToMatch, TPropertyType, TDslResult>
    : IExposeMatchingFunctionality<TItemToMatch, TPropertyType, TDslResult>
  {
    ICreateTheDslResult<TDslResult, TPropertyType> real_factory;
    bool negate;

    public GeneralMatchFunctionalityExtensionPoint(ICreateTheDslResult<TDslResult, TPropertyType> real_factory)
    {
      this.real_factory = real_factory;
    }

    public IExposeMatchingFunctionality<TItemToMatch, TPropertyType, TDslResult> not
    {
      get
      {
        negate = true;
        return this;
      }
    }

    public TDslResult create_dsl_result_using(IMatchAn<TPropertyType> condition)
    {
      return negate ? real_factory(condition.not()) : real_factory(condition);
    }
  }
}