using System;
namespace Day_3
{
    public interface IPen
    {
        string Color {get;set;} //property
        bool Open(); //function
        bool Close(); //function
        void Write(string text); //function
    }
}