using System;
using System.ComponentModel.DataAnnotations;
namespace Day_3.Models
{
    public class Trail
    {
        [Key]
        public int TrailId {get;set;}
        [Required]
        [Display(Name="Trail Name")]
        public string Name {get;set;}
        [Required]
        [Display(Name="Description")]
        public string Desc {get;set;}
        [Range(0,1000)]
        [Display(Name="Length")]
        public int Len {get;set;}
        [Display(Name="Elavation")]
        public int Elv {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}