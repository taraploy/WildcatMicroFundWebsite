using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMF.Models
{
    public class MentorAssignment
    {

        [Key]
        public int Id { get; set; }

        public DateTime DateAssigned { get; set; }

        public DateTime ApprovedToPitchDate { get; set; }
        
        public bool MentorEnabled { get; set; }

        public int ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public virtual  Application Application { get; set; }       
    }
}
