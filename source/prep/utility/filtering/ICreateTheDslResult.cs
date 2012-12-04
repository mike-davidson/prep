namespace prep.utility.filtering
{
  public delegate TDslResult ICreateTheDslResult<TDslResult,TPropertyType>(IMatchAn<TPropertyType> condition);
}