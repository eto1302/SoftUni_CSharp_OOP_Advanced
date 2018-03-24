using System;
using Tuple;

namespace Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] parameters = Console.ReadLine().Split();
            Tuple.Tuple<string, string, string> tuple = new Tuple.Tuple<string, string, string>(new Item<string>(parameters[0] + " " + parameters[1]),
                new Item<string>(parameters[2]),
                new Item<string>(parameters[3]));
            Console.WriteLine(tuple.ToString());
            parameters = Console.ReadLine().Split();
            Tuple.Tuple<string, int, bool> tuple1 = new Tuple.Tuple<string, int, bool>(new Item<string>(parameters[0]),
                new Item<int>(int.Parse(parameters[1])),
                new Item<bool>(parameters[2] == "drunk"));
            Console.WriteLine(tuple1.ToString());
            parameters = Console.ReadLine().Split();
            Tuple.Tuple<string, double, string> tuple2 = new Tuple.Tuple<string, double, string>(new Item<string>(parameters[0]),
                new Item<double>(double.Parse(parameters[1])),
                new Item<string>(parameters[2]));
            Console.WriteLine(tuple2.ToString());
        }
    }
}