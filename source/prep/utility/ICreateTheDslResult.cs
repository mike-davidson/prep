using prep.utility.filtering;

namespace prep.utility
{
  public delegate TDslResult ICreateTheDslResult<TDslResult,TPropertyType>(IMatchAn<TPropertyType> condition);
}