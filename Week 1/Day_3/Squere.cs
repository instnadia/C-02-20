namespace Day_3
{
    public class Squere : Shape
    {
        int side;

        public Squere(int side1){ //constructor
            side = side1;
        }

        public override int GetArea(){
            return side*side;
        }
    }
}