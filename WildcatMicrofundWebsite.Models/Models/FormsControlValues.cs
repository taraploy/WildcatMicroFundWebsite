using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMF.Models
{
    public class FormsControlValues
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public bool DefaultValue { get; set; }

        public int ValueOrder { get; set; }

        public int FormControlsLookupId { get; set; }
        [ForeignKey("FormControlsLookupId")]
        public virtual FormsControlLookup FormControlsLookup {get; set;}
    }
}
