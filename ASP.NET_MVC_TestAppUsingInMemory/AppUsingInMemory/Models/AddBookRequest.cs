namespace AppUsingInMemory.Models
{
    public class AddBookRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Guid CategoryId { get; set; }
    }
}
