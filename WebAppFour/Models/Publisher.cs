using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFour.Models
{
    [Table("Publisher")]
    public class Publisher
    {
        [Key]

        [Required]
        [StringLength(100)]
        public string BName { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
    }
}
