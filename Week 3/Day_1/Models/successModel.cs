using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_1.Models
{
    [NotMapped]
    public class successModel
    {
        public List<Post> allP {get;set;}
        public User userLogged {get;set;}
        public Post post {get;set;}
    }
}