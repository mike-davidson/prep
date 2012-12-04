namespace prep.utility.filtering
{
  public class MatchFactory<TItemToMatch, TPropertyType> : ICreateMatchers<TItemToMatch, TPropertyType>
  {
    PropertyAccessor<TItemToMatch, TPropertyType> accessor;

    public MatchFactory(PropertyAccessor<TItemToMatch, TPropertyType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<TItemToMatch> equal_to(TPropertyType value_to_equal)
    {
      return equal_to_any(value_to_equal);
    }

    public IMatchAn<TItemToMatch> equal_to_any(params TPropertyType[] values)
    {
      return create_match_using(new IsEqualToAny<TPropertyType>(values));
    }

    public IMatchAn<TItemToMatch> create_match_using(IMatchAn<TPropertyType> condition)
    {
      return new PropertyMatch<TItemToMatch, TPropertyType>(accessor, condition);
    }

    public IMatchAn<TItemToMatch> not_equal_to(TPropertyType value)
    {
      return equal_to(value).not();
    }
  }
}