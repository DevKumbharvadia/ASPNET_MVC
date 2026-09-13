using Microsoft.EntityFrameworkCore;
using AppUsingInMemory.Models;
using System;

namespace AppUsingInMemory.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Generate GUIDs for categories
            Guid scifiGuid = Guid.NewGuid();
            Guid bioGuid = Guid.NewGuid();

            // Seed categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = scifiGuid, Name = "Science Fiction" },
                new Category { Id = bioGuid, Name = "Biography" }
            );

            // Seed books
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = Guid.NewGuid(), Title = "Dune", Author = "Frank Herbert", CategoryId = scifiGuid },
                new Book { Id = Guid.NewGuid(), Title = "The Power Broker", Author = "Robert Caro", CategoryId = bioGuid }
            );
        }
    }
}
