using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace CustomList
{
    public class CustomDataStructure<T> where T : IComparable<T>
    {
        List<T> data = new List<T>();

        public CustomDataStructure()
        {
            data = new List<T>();
        }

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public void Remove(int index)
        {
            this.data.RemoveAt(index);
        }

        public bool Contains(T element)
        {
            return this.data.Contains(element);
        }

        public void Swap(int index1, int index2)
        {
            T tempVar = this.data[index1];
            this.data[index1] = this.data[index2];
            this.data[index2] = tempVar;
        }

        public int CountGreaterThan(T element)
        {
            return Compare(this.data, element);
        }

        public T Max()
        {
            return this.data.Max();
        }

        public T Min()
        {
            return this.data.Min();
        }

        public void Print()
        {
            Console.WriteLine(string.Join(Environment.NewLine, this.data));
        }

        private static int Compare<T>(List<T> list, T element)
            where T : IComparable<T>
        {
            int counter = 0;
            foreach (var generic in list)
            {
                if (generic.CompareTo(element) > 0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
