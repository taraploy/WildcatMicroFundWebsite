using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMF.Models
{
    public class Questions
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public int QuestionOrder { get; set; }

        [Required]
        public string QuestionType { get; set; }

        public bool EnableDisable { get; set; }

        [Display(Name = "Question Category")]
        public int QuestionCategoriesId { get; set; }        
        [ForeignKey("QuestionCategoriesId")]
        public virtual QuestionCategories QuestionCategories { get; set; }
    }
}