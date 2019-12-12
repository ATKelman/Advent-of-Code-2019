using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2019
{
    public static class Extensions
    {
        /// https://loekvandenouweland.com/content/Permutations-with-C-sharp-and-LINQ.html
        public static IEnumerable<IEnumerable<T>> Permutate<T>(this IEnumerable<T> values)
        {
            if (values.Count() == 1)
                return new[] { values };
            return values.SelectMany(x => Permutate(values.Where(y => y.Equals(x) == false)), (z, v) => v.Prepend(z));
        }

		public static int BindToRange(this int value, int upper, int lower)
		{
			if (value > upper)
				return upper;
			if (value < lower)
				return lower;
			return value;
		}
    }
}
