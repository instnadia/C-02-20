using System;
using System.Collections.Generic;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Pilot newPen = new Pilot();
            Console.WriteLine(newPen.isOpenProp);
            newPen.Open();
            Console.WriteLine(newPen.isOpenProp);
            //newPen.Write("C# is awesome");
            newPen.Close();
            newPen.Write("C# is awesome");
            Squere newS = new Squere(10);
            Console.WriteLine(newS.GetArea());
            Squere newS1 = new Squere(8);
            Console.WriteLine(newS1.GetArea());

        }
    }
}
