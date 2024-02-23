using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFour.Models
{
    [Table("Book")]
    public class Book
    {

        [Key]

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public double Price { get; set; }
        [Required]
        [StringLength(100)]
        public string Publisher { get; set; }
    }
}
