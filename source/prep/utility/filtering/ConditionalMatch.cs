namespace prep.utility.filtering
{
  public class ConditionalMatch<TItem> : IMatchAn<TItem>
  {
    Condition<TItem> real_condition;

    public ConditionalMatch(Condition<TItem> real_condition)
    {
      this.real_condition = real_condition;
    }

    public bool matches(TItem item)
    {
      return real_condition(item);
    }
  }
}