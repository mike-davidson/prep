using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using prep.utility.filtering;

namespace prep.utility.ranges
{
    public class RangeImpl<T> : IRange<T> where T : IComparable<T>
    {
        private IMatchAn<T> lower;
        private IMatchAn<T> upper;

        public RangeImpl(IMatchAn<T> lower, IMatchAn<T> upper)
        {
            this.lower = lower;
            this.upper = upper;
        }

        public bool contains(T value)
        {
            return lower.matches(value) && upper.matches(value);
        }
    }
}
