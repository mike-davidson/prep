using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prep.utility.ranges
{
    public class Range<T> where T : IComparable<T>
    {
        public static RangeBuilder<T> Build()
        {
            return new RangeBuilder<T>();
        }
    }
}
