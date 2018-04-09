using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
namespace CustomClassAttribute
{
    [Custom("Pesho", "3", "Used for C# OOP Advanced Course - Enumerations and Attributes.", new string[2] { "Pesho", "Svetlio" })]
    class Program
    {

        static void Main(string[] args)
        {
            string input = "";
            CustomAttribute attribute = (CustomAttribute)typeof(Program).GetCustomAttributes(false).First();
            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "Author") Console.WriteLine($"Author: {attribute.author}");
                if (input == "Revision") Console.WriteLine($"Revision: {attribute.revision}");
                if (input == "Description") Console.WriteLine($"Class Description: {attribute.description}");
                if (input == "Reviewers") Console.WriteLine($"Reviewers: {string.Join(", ", attribute.reviewers)}");
            }
        }
    }
}