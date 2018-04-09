using System;
using System.Collections.Generic;
using System.Linq;

namespace TrafficLights
{
    class Program
    {
        static void Main(string[] args)
        {
           
            List<Lights> lights = Console.ReadLine().Split().Select(l => (Lights) Enum.Parse(typeof(Lights), l)).ToList();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                int index = i + 1;
                Console.WriteLine(string.Join(" ", lights.Select(c => (Lights) (((int) c + index)%3)).Select(l => l.ToString())));
            }
        }
    }
}