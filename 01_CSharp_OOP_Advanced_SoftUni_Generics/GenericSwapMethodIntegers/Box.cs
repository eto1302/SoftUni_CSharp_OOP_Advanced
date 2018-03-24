using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Generics
{
    public class Box<T>
    {

        private List<T> data { get; }



        public Box()
        {
            this.data = new List<T>();
        }


        public void Add(T item)
        {
            this.data.Add(item);


        }

        public T Last()
        {
            return this.data.Last();
        }

        public T At(int index)
        {
            return this.data[index];
        }

        public void Swap(int a, int b)
        {
            T temp = default(T);
            temp = this.data[a];
            this.data[a] = this.data[b];
            this.data[b] = temp;
        }

        public string ToString(T value)
        {
            return $"{typeof(T).FullName}: {value}";
        }

    }
}
