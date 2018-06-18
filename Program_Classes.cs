Modify the Classes project in the \Visual C# Step by Step\Chapter 7\Classes folder by adding a new class called Line to the project. A Line class consists of two Point objects. Add a method GetLength to calculate the length of each Line object. Test a Line object by creating a line consisting of origin and bottomRight points in the DoWork method. Call the GetLength method to display the line’s length.
Note: The existing Point class must be left intact. Or, if you make any changes to the Point class, private fields must not be changed to public.


#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Classes
{
    class Program
    {
        static void doWork()
        {
            Line origin = new Line();
            Line bottomRight = new Line(300, 100);
            double length = origin.GetLength(bottomRight);
            Console.WriteLine($"Length is: {length}");
            Console.WriteLine($"Number of Line objects: {Line.ObjCount()}");
        }

        static void Main(string[] args)
        {
            try
            {
                doWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
