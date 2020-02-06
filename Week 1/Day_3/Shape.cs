using System;

namespace Day_3
{
    public abstract class Shape
    {
        public abstract int GetArea();

        public abstract void Call2();

        public abstract int height {get;set;}

        public void call(){
            Console.WriteLine("sfsdf");
        }
    }
}