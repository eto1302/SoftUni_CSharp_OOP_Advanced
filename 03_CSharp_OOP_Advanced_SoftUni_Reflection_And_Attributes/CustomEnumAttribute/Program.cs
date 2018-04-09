using System;

namespace CustomEnumAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (input == "Rank")
            {
                TypeAttribute attributes = typeof(Rank).GetCustomAttributes();
                
                Console.WriteLine(attributes);
            }
            else
            {
                TypeAttribute attributes = typeof(Suit);

                Console.WriteLine(attributes);
            }
        }
    }
}