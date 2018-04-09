using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstSet = new SortedSet<Person>(new FirstComparator());
            var secondSet = new SortedSet<Person>(new SecondComparator());
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split();
                firstSet.Add(new Person(tokens[0], int.Parse(tokens[1])));
                secondSet.Add(new Person(tokens[0], int.Parse(tokens[1])));
            }
            
            foreach (var elementPerson in firstSet)
            {
                Console.WriteLine(elementPerson.ToString());
            }
            foreach (var elementPerson in secondSet)
            {
                Console.WriteLine(elementPerson.ToString());
            }
        }
    }
}