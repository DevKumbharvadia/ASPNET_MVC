namespace BookStoreApp.Models.Domain
{
    public class Tag
    {
        public Guid Id { get; set; }  // Unique identifier for the tag
        public string Name { get; set; }  // Name of the tag

        // Navigation property for books
        public ICollection<BookTag> BookTags { get; set; }  // Many tags can be associated with many books
    }
}
