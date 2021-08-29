using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMF.Models
{
    public class ScoringQuestions
    {
        [Key]
        public int ScoringQuestionId { get; set; }

        public string ScoreQuestions { get; set; }

        public int MaxScore { get; set; }

        public int ScoringOrder { get; set; }      
    }
}