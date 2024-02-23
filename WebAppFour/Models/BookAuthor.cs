using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFour.Models
{
    [Table("BookAuthor")]
    public class BookAuthor
    {
        [Key]
        public int BookId { get; set; }

        public int AuthorId { get; set; }
    }
}
