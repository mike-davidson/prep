namespace prep.utility
{
  public interface IMatchAn<TItem>
  {
    bool matches(TItem item);
  }
}