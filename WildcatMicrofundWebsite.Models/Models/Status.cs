using System.ComponentModel.DataAnnotations;

namespace WMF.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        public string StatusDescription { get; set; }
    }
}

