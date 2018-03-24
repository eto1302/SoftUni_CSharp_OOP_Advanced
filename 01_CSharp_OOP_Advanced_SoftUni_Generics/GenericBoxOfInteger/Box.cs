using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericBoxOfInteger
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

        public string ToString(T value)
        {
            return $"{typeof(T).FullName}: {value}";
        }

    }


}
