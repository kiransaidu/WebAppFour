using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFour.Models
{
    [Table("BookCategory")]
    public class BookCategory
    {
        [Key]

        [Required]
        [StringLength(100)]
        public string Drama { get; set; }
        [Required]
        [StringLength(100)]
        public string Friction { get; set; }
        [Required]
        [StringLength(100)]
        public string Comedy { get; set; }
    }
}
