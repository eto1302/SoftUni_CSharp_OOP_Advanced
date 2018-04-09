using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    public class ListyIterator<T> :IEnumerable<T>
    {
        List<T> data = new List<T>();
        private int index;

        public ListyIterator(List<T> data)
        {
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

        public void PrintAll()
        {
            if (this.data.Count == 0) throw new ArgumentException("Invalid Operation!");
            for (int i = 0; i < this.data.Count; i++)
            {
                Console.Write($"{this.data[i]} ");

            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.data.Count; i++)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
