namespace BookStoreApp.Models.Domain
{
    public class Category
    {
        public Guid Id { get; set; }  // Primary Key (PK)
        public string Name { get; set; }  // Category name

        // Navigation property for related books (One-to-Many)
        public ICollection<Book> Books { get; set; }  // One category can have many books
    }
}
