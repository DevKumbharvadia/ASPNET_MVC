namespace BookStoreApp.Models.Domain
{
    public class Book
    {
        public Guid Id { get; set; }  // Primary Key (PK)
        public string Title { get; set; }  // Title of the book

        // Foreign Key to Author
        public Guid AuthorId { get; set; }  // Foreign key to Author table
        public Author Author { get; set; }  // Navigation property to Author

        // Foreign Key to Publisher
        public Guid PublisherId { get; set; }  // Foreign key to Publisher table
        public Publisher Publisher { get; set; }  // Navigation property to Publisher

        // Foreign Key to Category
        public Guid CategoryId { get; set; }  // Foreign key to Category table
        public Category Category { get; set; }  // Navigation property to Category

        // Navigation property for many-to-many relationship with Tag
        public ICollection<BookTag> BookTags { get; set; }  // A book can have many tags

        // Image URL or path
        public string ImageUrl { get; set; }  // URL or path to the book cover image
    }
}
