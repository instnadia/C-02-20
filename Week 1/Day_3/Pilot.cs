using System;

namespace Day_3
{
    public class Pilot : IPen
    {
        public string Color {get;set;} // property from Ipen
        private bool isOpen = false; // unique to Pilot

        public bool isOpenProp{
            get{
                return isOpen;
            }
        }

        public bool Open(){ // method from IPen
            isOpen = true;
            Console.WriteLine("Pen is now open");
            return isOpen;
        }
        public bool Close(){
            isOpen = false;
            Console.WriteLine("Pen is now closed");
            return isOpen;
        }

        public void Write(string somethingtowrite){
            if(isOpen){
                Console.WriteLine(somethingtowrite);
            }
        }
    }
}