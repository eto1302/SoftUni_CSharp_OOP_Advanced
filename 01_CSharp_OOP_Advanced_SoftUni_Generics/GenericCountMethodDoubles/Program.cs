﻿using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();
            for (int i = 0; i < count; i++)
            {
                box.Add(double.Parse(Console.ReadLine()));


            }
            double elementToCheck = double.Parse(Console.ReadLine());
            Console.WriteLine(box.GreaterCount(elementToCheck));

        }
    }
}