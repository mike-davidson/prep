namespace prep.utility.filtering
{
  public interface IMatchAn<TItem>
  {
    bool matches(TItem item);
  }
}