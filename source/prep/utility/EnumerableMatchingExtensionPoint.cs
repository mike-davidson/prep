using System.Collections.Generic;
using prep.utility.filtering;

namespace prep.utility
{
  public class EnumerableMatchingExtensionPoint<TItemToMatch, TPropertyType> :
    IExposeMatchingFunctionality<TItemToMatch, TPropertyType, IEnumerable<TItemToMatch>>
  {
    IEnumerable<TItemToMatch> items;

    IExposeMatchingFunctionality<TItemToMatch, TPropertyType, IMatchAn<TItemToMatch>>
      specification_creation_extension_point;

    public EnumerableMatchingExtensionPoint(IEnumerable<TItemToMatch> items,
                                            IExposeMatchingFunctionality
                                              <TItemToMatch, TPropertyType, IMatchAn<TItemToMatch>>
                                              specification_creation_extension_point)
    {
      this.items = items;
      this.specification_creation_extension_point = specification_creation_extension_point;
    }

    public IEnumerable<TItemToMatch> create_dsl_result_using(IMatchAn<TPropertyType> condition)
    {
      return items.all_items_matching(specification_creation_extension_point.create_dsl_result_using(condition));
    }

    public IExposeMatchingFunctionality<TItemToMatch, TPropertyType, IEnumerable<TItemToMatch>> not
    {
      get { return new NegatingEnumerableMatchingExtensionPoint(this); }
    }

    class NegatingEnumerableMatchingExtensionPoint :
      IExposeMatchingFunctionality<TItemToMatch, TPropertyType, IEnumerable<TItemToMatch>>
    {
      IExposeMatchingFunctionality<TItemToMatch, TPropertyType, IEnumerable<TItemToMatch>> original;

      public NegatingEnumerableMatchingExtensionPoint(
        IExposeMatchingFunctionality<TItemToMatch, TPropertyType, IEnumerable<TItemToMatch>> original)
      {
        this.original = original;
      }

      public IEnumerable<TItemToMatch> create_dsl_result_using(IMatchAn<TPropertyType> condition)
      {
        return original.create_dsl_result_using(condition.not());
      }
    }
  }
}