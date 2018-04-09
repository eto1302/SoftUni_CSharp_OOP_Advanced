using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> data;

        public Stack(List<T> data)
        {
            this.data = data;
        }

        public void Pop()
        {
            try
            {
                this.data.RemoveAt(this.data.Count - 1);
            }
            catch (Exception e)
            {
                Console.WriteLine("No elements");
            }
        }

        public void Push(List<T> dataList)
        {
            for (int i = 0; i < dataList.Count; i++)
            {
                this.data.Add(dataList[i]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.data.Count - 1; i >= 0; i--)
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
