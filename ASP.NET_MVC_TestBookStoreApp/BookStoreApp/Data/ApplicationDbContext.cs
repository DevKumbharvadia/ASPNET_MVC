using Azure;
using BookStoreApp.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookStoreApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define DbSet properties for each entity
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BookTag> BookTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One-to-Many relationship: Author and Book
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade); // Ensure cascading deletes

            // One-to-Many relationship: Publisher and Book
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.Cascade); // Ensure cascading deletes

            // One-to-Many relationship: Category and Book
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); // Ensure cascading deletes

            // Many-to-Many relationship: Book and Tag
            modelBuilder.Entity<BookTag>()
                .HasKey(bt => new { bt.BookId, bt.TagId }); // Composite Key

            modelBuilder.Entity<BookTag>()
                .HasOne(bt => bt.Book)
                .WithMany(b => b.BookTags)
                .HasForeignKey(bt => bt.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookTag>()
                .HasOne(bt => bt.Tag)
                .WithMany(t => t.BookTags)
                .HasForeignKey(bt => bt.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed categories first
            var category1Id = Guid.NewGuid();
            var category2Id = Guid.NewGuid();

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = category1Id, Name = "Fiction" },
                new Category { Id = category2Id, Name = "Non-Fiction" }
            );

            // Seed authors
            var author1Id = Guid.NewGuid();
            var author2Id = Guid.NewGuid();

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = author1Id, Name = "Frank Herbert" },
                new Author { Id = author2Id, Name = "Robert Caro" }
            );

            // Seed publishers
            var publisher1Id = Guid.NewGuid();
            var publisher2Id = Guid.NewGuid();

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = publisher1Id, Name = "Penguin Random House" },
                new Publisher { Id = publisher2Id, Name = "HarperCollins" }
            );

            // Seed tags
            var tag1Id = Guid.NewGuid();
            var tag2Id = Guid.NewGuid();

            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = tag1Id, Name = "Science Fiction" },
                new Tag { Id = tag2Id, Name = "Biography" }
            );

            // Seed books with valid CategoryId, AuthorId, and PublisherId
            var book1Id = Guid.NewGuid();
            var book2Id = Guid.NewGuid();

            modelBuilder.Entity<Book>().HasData(
        new Book { Id = book1Id, Title = "Dune", AuthorId = author1Id, PublisherId = publisher1Id, CategoryId = category1Id, ImageUrl = "default-image-dune.jpg" },
        new Book { Id = book2Id, Title = "The Power Broker", AuthorId = author2Id, PublisherId = publisher2Id, CategoryId = category2Id, ImageUrl = "default-image-power-broker.jpg" }
    );

            // Seed BookTags (Many-to-Many relationships)
            modelBuilder.Entity<BookTag>().HasData(
                new BookTag { BookId = book1Id, TagId = tag1Id }, // Dune - Science Fiction
                new BookTag { BookId = book2Id, TagId = tag2Id }  // The Power Broker - Biography
            );
        }
    }
}
