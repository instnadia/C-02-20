using System.ComponentModel.DataAnnotations;

namespace Day_1.Models
{
    public class User
    {
        [Display(Name="First name")]
        [Required(ErrorMessage="This field is required")]
        [MinLength(2)]
        public string fname {get;set;}
        [MinLength(2)]
        [Display(Name="Last name")]

        [Required]
        public string lname {get;set;}
        [Required]
        [EmailAddress]
        public string email {get;set;}
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password {get;set;}
        [Required]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage="Passwords do not match")]
        public string confirm_password {get;set;}
    }

    public class Login{
        [Required]
        [EmailAddress]
        public string lemail {get;set;}
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string lpassword {get;set;}
    }
}