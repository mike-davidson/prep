namespace prep.utility.filtering
{
  public class Where<TItemToMatch>
  {
    public static GeneralMatchFunctionalityExtensionPoint<TItemToMatch, TPropertyType,IMatchAn<TItemToMatch>> has_a
      <TPropertyType>(
      PropertyAccessor<TItemToMatch, TPropertyType> accessor)
    {
      return new GeneralMatchFunctionalityExtensionPoint<TItemToMatch, TPropertyType,IMatchAn<TItemToMatch>>(
        x => new PropertyMatch<TItemToMatch,TPropertyType>(accessor, x));

    }
  }
}