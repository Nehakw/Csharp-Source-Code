



Modify the Classes project in the \Visual C# Step by Step\Chapter 7\Classes folder by adding a new class called Line to the project. A Line class consists of two Point objects. Add a method GetLength to calculate the length of each Line object. Test a Line object by creating a line consisting of origin and bottomRight points in the DoWork method. Call the GetLength method to display the line’s length.
Note: The existing Point class must be left intact. Or, if you make any changes to the Point class, private fields must not be changed to public.


#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Classes
{
    class Line
    {
        private int a, b;
        private static int objCount = 0;

        public Line()
        {
            this.a = -1;
            this.b = -1;
            objCount++;
        }

        public Line(int a, int b)
        {
            this.a = a;
            this.b = b;
            objCount++;
        }

        public double GetLength(Line other)
        {
            int aDiff = this.a - other.a;
            int bDiff = this.b - other.b;
            double length = Math.Sqrt((aDiff * aDiff) + (bDiff * bDiff));
            return length;
        }

        public static int ObjCount() => objCount;
    }
}
