using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMF.Models
{
    public class PitchEvents
    {
        [Key]
        public int Id { get; set; }

        public DateTime PitchDateTime { get; set; }

        public float CashFunds { get; set; }

        public float ServiceFunds { get; set; }

        public string PitchEventDescription { get; set; }

        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }
    }
}