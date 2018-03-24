using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Item<T>
    {
        public T value { get; set; }

        public Item(T value)
        {
            this.value = value;
        }

    }
}
