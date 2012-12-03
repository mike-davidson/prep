namespace prep.utility.filtering
{
  public interface ICreateMatchers<TItemToMatch, TPropertyType>
  {
    IMatchAn<TItemToMatch> equal_to(TPropertyType value_to_equal);
    IMatchAn<TItemToMatch> equal_to_any(params TPropertyType[] values);
    IMatchAn<TItemToMatch> not_equal_to(TPropertyType value);
      IMatchAn<TItemToMatch> match(Condition<TItemToMatch> condition);
  }
}