namespace Day_1
{
    public class cat
    {
        public string HowWasYourDay(string name="Nadia", string status="okay", bool goodDay=true, int hours=8){
            if (goodDay){
                status = "good";
            }else{
                status="bad";
            }
            return $"{name}'s day was {status} and it was a {hours} day long";
        }  
    }
}