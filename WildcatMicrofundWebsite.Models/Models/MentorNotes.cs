using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMF.Models
{
    public class MentorNotes
    {

        [Key]
        public int Id { get; set; }

        public DateTime NotesDate { get; set; }

        public string Notes { get; set; }

        public int MentorAssignmentId { get; set; }
        [ForeignKey("MentorAssignmentId")]
        public virtual MentorAssignment MentorAssignment { get; set; }

    }
}
