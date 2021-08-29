using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMF.Models
{
    public class AwardHistory
    {
        [Key]
        public int Id { get; set; }

        public DateTime AwardDate { get; set; }

        public float AwardAmount { get; set; }

        public string AwardAgreement { get; set; }

        public int ReqNumber { get; set; }

        public DateTime MailDate { get; set; }

        public string Provider { get; set; }

        public string AwardType { get; set; }

        public string Comments { get; set; }

        public int ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public virtual  Application Application { get; set; }        
    }
}