namespace prep.utility.filtering
{
  public interface IProvideAccessToCreatingMatchers<TItemToMatch, TPropertyType>
  {
    IMatchAn<TItemToMatch> create_specification_using(IMatchAn<TPropertyType> condition);
  }
}