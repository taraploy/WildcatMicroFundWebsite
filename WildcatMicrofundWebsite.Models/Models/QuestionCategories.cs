using System.ComponentModel.DataAnnotations;

namespace WMF.Models
{
    public class QuestionCategories
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string QuestionCategory { get; set; }

        public bool EnableDisable { get; set; }
    }
}
