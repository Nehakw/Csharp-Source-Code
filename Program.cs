


Write a console application that prompts for your name and age in sequence and prints out a greeting including your name and age.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Your Age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Hello! I am {0}, and I am {1} years old.", name, age);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
