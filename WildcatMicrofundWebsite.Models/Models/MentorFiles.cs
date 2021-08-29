using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WMF.Models
{
    public class MentorFiles
    {
        [Key]
        public int ID;

        public string MentorFile { get; set; }

        public string FileType { get; set; }

        public string FileDescription { get; set; }

        public int MentorAssigned { get; set; }
        [ForeignKey("MentorAssigned")]
        public virtual MentorAssignment MentorAssignment { get; set; }
    }
}