using System.ComponentModel.DataAnnotations;

namespace WMF.Models
{
    public class FormsControlLookup
    {
        [Key]
        public int Id { get; set; }

        public string FormControlType { get; set; }

        public string FormControlDescription { get; set; }
    }
}