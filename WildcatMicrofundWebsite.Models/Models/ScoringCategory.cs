using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WMF.Models
{
    public class ScoringCategory
    {
        [Key]
        public int ScoringCategoryId { get; set; }

        public string ScoreCategory { get; set; }

        public bool EnableDisable { get; set; }

        public int ScoringQuestionsId { get; set; }
        [ForeignKey("ScoringQuestionsId")]
        public virtual ScoringQuestions ScoringQuestions { get; set; }
    }
}
