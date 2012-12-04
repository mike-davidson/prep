namespace prep.utility.filtering
{
  public class AndMatch<T> : IMatchAn<T>
  {
    IMatchAn<T> first;
    IMatchAn<T> second;

    public AndMatch(IMatchAn<T> first, IMatchAn<T> second)
    {
      this.first = first;
      this.second = second;
    }

    public bool matches(T item)
    {
      return first.matches(item) && second.matches(item);
    }
  }
}