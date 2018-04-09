using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().Replace(",", string.Empty);
            int[] tokens = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Lake lake = new Lake(tokens.ToList());
            string result = string.Empty;
            IEnumerator<int> enumerator = lake.GetEnumerator();


            while (enumerator.MoveNext())
            {
                result += $"{enumerator.Current}, ";
            }
            Console.WriteLine(result.Substring(0, result.Length-2));
        }
    }
}