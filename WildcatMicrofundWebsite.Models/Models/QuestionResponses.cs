using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMF.Models
{
    public class QuestionResponses
    {
        [Key]
        public int Id { get; set; }

        public DateTime QuestionResponseDate { get; set; }

        public string QuestionResponse { get; set; }

        public int ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public virtual Application Application { get; set; }       
        
        public int QuestionId { get; set; }        
        [ForeignKey("QuestionId")]
        public virtual Questions Questions { get; set; }
    }
}
