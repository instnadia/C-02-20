namespace Day_3
{
    public class Squere : Shape
    {
        int side;

        public Squere(int side1){ //constructor
            side = side1;
        }

        public int height {get;set;}

        public override int GetArea(){
            return side*side;
        }
    }
}