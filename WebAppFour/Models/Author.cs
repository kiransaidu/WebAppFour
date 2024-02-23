using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFour.Models
{
    [Table("Author")]
    public class Author
    {
        [Key]
        public int WriterId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
