using Microsoft.EntityFrameworkCore;
using AppUsingInMemory.Models;

namespace AppUsingInMemory.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }  // Add this line
    }
}
