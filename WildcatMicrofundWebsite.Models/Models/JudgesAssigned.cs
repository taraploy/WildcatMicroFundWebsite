using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMF.Models
{
    public class JudgesAssigned
    {
        [Key]
        public int JudgesAssignedId { get; set; }

        public string SystemUserId { get; set; }
        [ForeignKey("SystemUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int PitchEventsId { get; set; }
        [ForeignKey("PitchEventsId")]
        public virtual PitchEvents PitchEvents { get; set; }
    }
}