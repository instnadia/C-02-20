namespace Day_2
{
    public class Movie
    {
        public string title; //FIELD
        int releaseDate;
        string genre;
        double score;

        public Movie(string title, int release, string genre, double score){ // CONSTRUCTOR
            this.genre = genre;
            this.title = title;
            this.releaseDate = release;
            this.score = score;
        }
        
        public override string ToString(){ // FUNCTION
            return $"title: {this.title}, release date: {this.releaseDate}, genre: {this.genre}";
        }

        public double Score { // PROPERY
            get{ return score;}
            set {
                if (value<1.5){
                    score=1.5;
                }else{
                    score=value;
                }
            }
        }
    }
}