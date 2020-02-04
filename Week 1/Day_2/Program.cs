using System;

namespace Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie newMovie = new Movie("Brave heart", 1973, "action/drama", 9.8);
            newMovie.Score = 0;
            Console.WriteLine(newMovie.Score);
            Netflix myNetflix = new Netflix("nadia@nadia.com", "asdasdasd", "Chris");
            Console.WriteLine(myNetflix.ShowOwner);
            myNetflix.addMovieToList(newMovie);
            myNetflix.showLibrary();
            Movie adsadads = new Movie("Hot fuzz", 2015, "comedy", 10);
            Console.WriteLine(myNetflix.isIn(adsadads));
        }
    }
}
