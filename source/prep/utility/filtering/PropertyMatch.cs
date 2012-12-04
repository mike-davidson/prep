namespace prep.utility.filtering
{
  public class PropertyMatch<TItemToMatch,TPropertyType> : IMatchAn<TItemToMatch>
  {
    PropertyAccessor<TItemToMatch, TPropertyType> get_the_value_from;
    IMatchAn<TPropertyType> value_matcher;

    public PropertyMatch(PropertyAccessor<TItemToMatch, TPropertyType> get_the_value_from, IMatchAn<TPropertyType> value_matcher)
    {
      this.get_the_value_from = get_the_value_from;
      this.value_matcher = value_matcher;
    }

    public bool matches(TItemToMatch item)
    {
      return value_matcher.matches(get_the_value_from(item));
    }
  }
}