using System;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomDataStructure<string> customList = new CustomDataStructure<string>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] param = input.Split();
                string command = param[0];
                switch (command)
                {
                    case ("Add"):
                    {
                        customList.Add(param[1]);
                        break;
                    }
                    case ("Remove"):
                    {
                        customList.Remove(int.Parse(param[1]));
                        break;
                    }
                    case ("Contains"):
                    {
                        Console.WriteLine(customList.Contains(param[1]));
                        break;
                    }
                    case ("Swap"):
                    {
                        customList.Swap(int.Parse(param[1]), int.Parse(param[2]));
                        break;
                    }
                    case ("Greater"):
                    {
                        Console.WriteLine(customList.CountGreaterThan(param[1]));
                        break;
                    }
                    case ("Max"):
                    {
                        Console.WriteLine(customList.Max());
                        break;
                    }
                    case ("Min"):
                    {
                        Console.WriteLine(customList.Min());
                        break;
                    }
                    case ("Print"):
                    {
                        customList.Print();
                        break;
                    }
                    case ("Sort"):
                    {
                        customList.Sort();
                        break;
                    }
                }
            }
        }
    }
}