using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPattern
{
    public class FirstComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            var comparator = x.name.Length.CompareTo(y.name.Length);
            if (comparator != 0)
            {
                return comparator;
            }
            else return x.name.ToLower().First().CompareTo(y.name.ToLower().First());
        }
    }
}
