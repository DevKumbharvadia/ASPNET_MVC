namespace BookStoreApp.Models.Domain
{
    public class BookTag
    {
        public Guid BookId { get; set; }  // Foreign key to Book
        public Book Book { get; set; }     // Navigation property for Book

        public Guid TagId { get; set; }   // Foreign key to Tag
        public Tag Tag { get; set; }      // Navigation property for Tag
    }
}
