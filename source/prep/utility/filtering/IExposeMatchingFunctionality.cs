namespace prep.utility.filtering
{
  public interface IExposeMatchingFunctionality<TItemToMatch, TPropertyType,TDSLReturnType>
  {
    TDSLReturnType create_dsl_result_using(IMatchAn<TPropertyType> condition);
  }
}