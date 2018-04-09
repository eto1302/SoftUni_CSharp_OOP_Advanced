using System;
using System.Linq;

namespace Collection
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] tokens = input.Split();
            ListyIterator<string> listyIterator = new ListyIterator<string>(tokens.Skip(1).ToList());
            while ((input = Console.ReadLine()) != "END")
            {
                tokens = input.Split();
                switch (tokens[0])
                {
                    case ("Move"):
                    {
                        Console.WriteLine(listyIterator.Move());
                        break;
                    }
                    case ("HasNext"):
                    {
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    }
                    case ("Print"):
                    {
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);

                        }
                        break;
                    }
                    case ("PrintAll"):
                    {
                        try
                        {
                            listyIterator.PrintAll();
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);

                        }
                        break;
                    }
                }
            }
        }
    }
}