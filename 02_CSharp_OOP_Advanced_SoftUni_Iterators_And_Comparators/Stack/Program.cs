using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Stack<string> stack = new Stack<string>(new List<string>());
            
            while ((input = Console.ReadLine()) != "END")
            {
                input = input.Replace(",", string.Empty);
                string[] tokens = input.Split(new []{" "},StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[0])
                {
                    case ("Push"):
                    {
                        stack.Push(tokens.Skip(1).ToList());
                        break;
                    }
                    case ("Pop"):
                    {
                        stack.Pop();
                        break;
                    }
                }
            }
            for (int i = 0; i < 2; i++)
            {
                IEnumerator<string> enumerator = stack.GetEnumerator();
                

                while (enumerator.MoveNext())
                {
                    Console.WriteLine(enumerator.Current);
                }

            }
        }
    }
}