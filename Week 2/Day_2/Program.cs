using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie> {
            new Movie("Blood Diamond", "Leonardo DiCaprio", 8, 2006),
            new Movie("The Departed", "Leonardo DiCaprio", 8.5, 2006),
            new Movie("Gladiator", "Russell Crowe", 8.5, 2000),
            new Movie("A Beautiful Mind", "Russell Crowe", 8.2, 2001),
            new Movie("Good Will Hunting", "Matt Damon", 8.3, 1997),
            new Movie("The Martian", "Matt Damon", 8, 2015),
            };

            List<Actor> actors = new List<Actor> {
            new Actor { FullName = "Matt Damon", Age = 48 },
            new Actor { FullName = "Leonardo DiCaprio", Age = 44 },
            };

            // foreach(Movie item in movies)

            List<Movie> all_matt_damon = movies.Where(item => item.LeadActor=="Matt Damon").ToList();

            Movie Gladiator = movies.FirstOrDefault(p=>p.Title=="Gladiator");

            Movie abc = movies.FirstOrDefault(p => p.Title=="abc");
                                                                    //1997
            Movie oldest = movies.FirstOrDefault(p => p.Year == movies.Min(t=>t.Year));

            List<Movie> byTitle = movies.OrderBy(t=>t.Title).ToList();

            List<Movie> byTitleDec = movies.OrderByDescending(t=>t.Title).ToList();

            List<Movie> allDC = movies.Where(t=>t.LeadActor=="Leonardo DiCaprio").ToList();

            List<Movie> noDC = movies.Except(allDC).ToList();

            List<Movie> noDC2 = movies.Where(r=>!r.LeadActor.Contains("Leonardo DiCaprio")).ToList();

            List<Movie> startWithT = movies.Where(t=>t.Title.StartsWith("T")).ToList();
        }
    }
}
