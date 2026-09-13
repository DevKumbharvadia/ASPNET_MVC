namespace BookStoreApp.Models.Domain
{
    public class Publisher
    {
        public Guid Id { get; set; }  // Unique identifier for the publisher
        public string Name { get; set; }  // Name of the publisher

        // Navigation property for books
        public ICollection<Book> Books { get; set; }  // One publisher can publish many books

    }
}
