using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMF.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }      
       
        [Display(Name = "Mailing Address")]
        public string Address { get; set; }       

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "County")]
        public string County { get; set; }      

        [Display(Name = "Zip Code")]
        public string Zip { get; set; }        

        [Required]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Race/Ethnicity")]
        public string Race { get; set; }

        [Required]
        [Display(Name = "Income Level")]
        public string Income { get; set; }

        [Required]
        [Display(Name = "Highest Education Level")]
        public string Education { get; set; }

        [Required]
        [Display(Name = "Residence Environment")]
        public string Residence { get; set; }

        [Required]
        [Display(Name = "Military Status")]
        public string Military { get; set; }
    }
}
