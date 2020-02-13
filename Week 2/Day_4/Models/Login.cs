using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_4.Models
{
    [NotMapped]
    public class Login
    {
        [EmailAddress]
        [Required]
        [MinLength(2)]
        public string lemail {get;set;}
        [DataType(DataType.Password)]
        public string lpassword {get;set;}
    }
}