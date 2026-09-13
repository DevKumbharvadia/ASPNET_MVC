namespace AppUsingInMemory.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Guid CategoryId { get; set; }

        // Navigation property for the relationship
        public Category Category { get; set; }
    }
}
