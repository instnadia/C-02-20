using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_1.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}
        [Required]
        [MinLength(2)]
        public string fname {get;set;}
        [MinLength(2)]
        [Required]
        public string lname {get;set;}
        [EmailAddress]
        [Required]
        [MinLength(2)]
        public string email {get;set;}
        [DataType(DataType.Password)]
        public string password {get;set;}
        [DataType(DataType.Password)]
        [Compare("password")]
        [NotMapped]
        public string cpassword {get;set;}
        public DateTime createdAt {get;set;} = DateTime.Now;
        public DateTime updatedAt {get;set;} = DateTime.Now;
        List<Post> postsCreated {get;set;}
        List<Vote> Votes {get;set;}
    }
}