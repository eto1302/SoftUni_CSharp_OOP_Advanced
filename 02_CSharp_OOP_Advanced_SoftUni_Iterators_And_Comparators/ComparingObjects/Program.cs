using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split();
                people.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));
            }
            int n = int.Parse(Console.ReadLine());
            n--;
            int matches = 0;
            int mismatches = 0;
            foreach (var person in people)
            {
                if (people[n].CompareTo(person) == 0) matches++;
                else mismatches++;

            }
            if (matches != 1) Console.WriteLine($"{matches} {mismatches} {matches + mismatches}");
            else Console.WriteLine("No matches");
        }
    }
}