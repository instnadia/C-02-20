using System;
using System.Collections.Generic;

namespace Day_1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string name = "Nadia";
            char a = 'f';
            int r = 100;
            double t = 1.5;
            float p = 1.5f;
            bool empty = true;

            Console.WriteLine($"{name} {a} {t} {empty}");

            if(name == "Nadia"){
                Console.WriteLine("Cool");
            
            }else{
                Console.WriteLine("also cool");
            }

            string[] foods = new string[5]{
                "banana", "pizza","nachos","tacos","burger"
            };


            Console.WriteLine(string.Join(", ", foods));

            Dictionary<string, dynamic> person = new Dictionary<string, dynamic>(){
                {"firstName", "Kate"},
                {"lastName", "middleton"},
                {"age", 37}
            };
            person.Add("asdfasdf",true);
            person.Remove("age");
            

            cat vasya = new cat();
            Console.WriteLine(vasya.HowWasYourDay());
            
        }

    }
}
