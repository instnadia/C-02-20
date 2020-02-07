using System.ComponentModel.DataAnnotations;

namespace Day_5.Models
{
    public class Quote
    {
        [Required(ErrorMessage="ooga booga")]
        [MinLength(2)]
        public string quote {get;set;}
        [MinLength(2)]
        [Required]
        public string author {get;set;}
    }
}