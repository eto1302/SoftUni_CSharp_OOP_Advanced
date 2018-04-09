using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database
{
    public class Database
    {
        private int[] array;
        private int currentIndex;

        private Database()
        {
            this.array = new int[16];
            currentIndex = 0;
        }

        public Database(params int[] members) : this()
        {
            Array.Copy(members, this.array, members.Length);
            this.currentIndex = members.Length;
        }

        public void Add(int member)
        {
            if (currentIndex >= 16) throw new InvalidOperationException("Array is full!");
            array[currentIndex] = member;
            currentIndex++;


        }
        public void Remove()
        {
            if (currentIndex == 0) throw new InvalidOperationException("Array is empty!");
            currentIndex--;
            array[currentIndex] = default(int);
        }

        public int[] Fetch()
        {
            int[] result = new int[currentIndex];
            Array.Copy(array, result, currentIndex);

            return result;
        }
    }
}
