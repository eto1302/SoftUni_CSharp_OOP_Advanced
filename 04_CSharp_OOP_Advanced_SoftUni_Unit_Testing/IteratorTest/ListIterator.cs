using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorTest
{
    public class ListIterator<T>
    {
        List<T> data = new List<T>();
        private int index;

        public ListIterator(List<T> data)
        {
            if(data == null) throw new ArgumentNullException("Data cannot be null!");
            this.data = data;
            this.index = 0;
        }

        public bool Move()
        {
            if (index + 1 == data.Count)
            {
                return false;
            }
            index++;
            return true;
        }

        public bool HasNext()
        {
            if (index + 1 == data.Count)
            {
                return false;
            }

            return true;
        }

        public void Print()
        {
            if (this.data.Count == 0) throw new ArgumentException("Invalid Operation!");
            Console.WriteLine(this.data[index]);
        }

    }
}
