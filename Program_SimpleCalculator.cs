Project 1: A simple calculator (Console Application)

1. Develop a console application of a simple calculator that does simple addition, subtraction, multiplication, and division. With this application you need to be able to:
Enter any number in the console at runtime
Choose any operator from +, -, * or / and enter it
Enter another number
When you press Enter, view the calculated value in the console

2. Modify the above application such that it could handle the following exceptions:
Only allow numbers as operands, not any other characters (letters, etc)
Only allow the choice of valid operators: +, -, *, and /
Does not allow divide by zero
Note1: This program should allow the user to either continue or quit after each operation. That is, the program should not crash or quit on its own after an operation.
Note2: In the second part, floating-point operations are required.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            char contNext = 'y';
            while (contNext == 'y')
            {
                try
                {
                    float num1;
                    float num2;
                    string operand;
                    float result = 0;

                    Console.WriteLine("Please enter the first number:");
                    num1 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter the second number:");
                    num2 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Select an operation to perform (+, -, *, /):");
                    operand = Console.ReadLine();

                    if (operand == "+")
                    {
                        result = num1 + num2;
                        Console.WriteLine("Your answer is " + result);
                    }
                    else if (operand == "-")
                    {
                        result = num1 - num2;
                        Console.WriteLine("Your answer is " + result);
                    }
                    else if (operand == "*")
                    {
                        result = num1 * num2;
                        Console.WriteLine("Your answer is " + result);
                    }
                    else if (operand == "/")
                    {
                        if (num2 == 0)
                        {
                            throw new Exception("Cannot divide by 0");
                        }
                        else
                        {
                            result = num1 / num2;
                            Console.WriteLine("Your answer is " + result);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid operator");
                    }
                }

                catch (FormatException fEx)
                {
                    Console.WriteLine(fEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Do you want to continue? (y/n)");
                contNext = Convert.ToChar(Console.ReadLine());
            }
        }
    }
}
