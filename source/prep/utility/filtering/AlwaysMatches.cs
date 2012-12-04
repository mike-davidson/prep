namespace prep.utility.filtering
{
  public class AlwaysMatches<T> : IMatchAn<T>
  {
    public bool matches(T item)
    {
      return true;
    }
  }
}