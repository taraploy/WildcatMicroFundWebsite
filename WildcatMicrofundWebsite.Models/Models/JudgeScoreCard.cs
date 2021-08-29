using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMF.Models
{
    public class JudgeScoreCard
    {
        [Key]
        public int Id { get; set; }

        public float JudgeScore { get; set; }

        public string JudgeComment { get; set; }

        public int JudgesAssignedId { get; set; }
        [ForeignKey("JudgesAssignedId")]
        public virtual JudgesAssigned JudgesAssigned { get; set; }

        public int ScoringQuestionsId { get; set; }
        [ForeignKey("ScoringQuestionsId")]
        public virtual ScoringQuestions ScoringQuestions { get; set; }

        public int ScoringApplicationId { get; set; }
        [ForeignKey("ScoringApplicationId")]
        public virtual Application Application { get; set; }
    }
}
