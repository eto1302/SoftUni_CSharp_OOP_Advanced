using System;
using System.Reflection;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] parameters = Console.ReadLine().Split();
            Tuple<string, string> tuple = new Tuple<string, string>(new Item<string>(parameters[0] + " " + parameters[1]), new Item<string>(parameters[2]));
            Console.WriteLine(tuple.ToString());
            parameters = Console.ReadLine().Split();
            Tuple<string, int> tuple1 = new Tuple<string, int>(new Item<string>(parameters[0]), new Item<int>(int.Parse(parameters[1])));
            Console.WriteLine(tuple1.ToString());
            parameters = Console.ReadLine().Split();
            Tuple<int, double> tuple2 = new Tuple<int, double>(new Item<int>(int.Parse(parameters[0])), new Item<double>(double.Parse(parameters[1])));
            Console.WriteLine(tuple2.ToString());

        }
    }
}