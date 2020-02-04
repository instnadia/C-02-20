using System;
using System.Collections.Generic;

namespace Day_2
{
    public class Netflix
    {
        List<Movie> library;
        string owner;
        private string email;
        private string password;
        public Netflix(string em, string pas, string owner="Nadia"){
            library = new List<Movie>();
            this.email = em;
            this.password = pas;
            this.owner = owner;
        }

        public string ShowOwner{
            get{
                return owner;
            }
        }
        public void addMovieToList(Movie newMovie){
            this.library.Add(newMovie);
        }

        public void showLibrary(){
            foreach(Movie item in library){
                Console.WriteLine(item);
            }
        }

        public bool isIn(Movie something){
            foreach(Movie item in library){
                if(item==something){
                    return true;
                }
            }
            return false;
        }
    }
}