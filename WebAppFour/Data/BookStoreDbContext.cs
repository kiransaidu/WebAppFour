using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppFour.Models;

namespace WebAppFour.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext (DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppFour.Models.Author> Author { get; set; } = default!;

        public DbSet<WebAppFour.Models.Publisher>? Publisher { get; set; }

        public DbSet<WebAppFour.Models.BookCategory>? BookCategory { get; set; }

        public DbSet<WebAppFour.Models.Book>? Book { get; set; }

        public DbSet<WebAppFour.Models.BookAuthor>? BookAuthor { get; set; }
    }
}
