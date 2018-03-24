using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();
            for (int i = 0; i < count; i++)
            {
                box.Add(int.Parse(Console.ReadLine()));


            }
            int[] pars = Console.ReadLine().Split().Select(int.Parse).ToArray();
            box.Swap(pars[0], pars[1]);
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(box.ToString(box.At(i)));

            }
        }
    }
}