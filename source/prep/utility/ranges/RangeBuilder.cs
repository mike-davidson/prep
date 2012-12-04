using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using prep.utility.filtering;

namespace prep.utility.ranges
{
    public class RangeBuilder<T> where T : IComparable<T>
    {
        private IMatchAn<T> lower = new ConditionalMatch<T>(x=>true);
        private IMatchAn<T> lowerEqualTo = new ConditionalMatch<T>(x => true);
        private IMatchAn<T> upper = new ConditionalMatch<T>(x => true);
        private IMatchAn<T> upperEqualTo = new ConditionalMatch<T>(x => true);
        private bool inclusive = false;

        public RangeBuilder<T> Lower(T item)
        {
            lower = new ConditionalMatch<T>(x => x.CompareTo(item) > 0);
            lowerEqualTo = new ConditionalMatch<T>(x => x.Equals(item));
            return this;
        }

        public RangeBuilder<T> Upper(T item)
        {
            upper = new ConditionalMatch<T>(x=>x.CompareTo(item)<0);
            upperEqualTo = new ConditionalMatch<T>(x => x.Equals(item));
            return this;
        }

        public RangeBuilder<T> Inclusive()
        {
            inclusive = true;
            return this;
        }

        public FallsInRange<T> Create()
        {
            if (inclusive)
            {
                lower = new OrMatch<T>(lower, lowerEqualTo);
                upper = new OrMatch<T>(upper, upperEqualTo);
            }

            return new FallsInRange<T>(new RangeImpl<T>(lower,upper));
        }
    }
}
