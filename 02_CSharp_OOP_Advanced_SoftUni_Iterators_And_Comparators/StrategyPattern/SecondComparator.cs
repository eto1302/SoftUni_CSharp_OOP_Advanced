using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace StrategyPattern
{
    public class SecondComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.age.CompareTo(y.age);
        }
    }
}
