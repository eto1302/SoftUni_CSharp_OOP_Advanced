using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<T, T1>
    {
        Item<T> item1 = new Item<T>(default(T));
        Item<T1> item2 = new Item<T1>(default(T1));

        public Tuple(Item<T> item1, Item<T1> item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public override string ToString()
        {
            return item1.value.ToString() + " -> " + item2.value.ToString();
        }
    }
}
