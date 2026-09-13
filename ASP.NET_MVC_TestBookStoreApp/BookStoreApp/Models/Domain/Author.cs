namespace BookStoreApp.Models.Domain
{
    public class Author
    {
        public Guid Id { get; set; }  // Primary Key (PK)
        public string Name { get; set; }  // Name of the author

        // Navigation property for related books (One-to-Many)
        public ICollection<Book> Books { get; set; }  // One author can write many books

    }
}
