using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMF.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }

        public DateTime ApplicationDate { get; set; }

        public string StatusDescription { get; set; }
        
        [Display(Name = "Business name:")]
        public string BusinessName { get; set; }

        public string Comments { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
    }
}
