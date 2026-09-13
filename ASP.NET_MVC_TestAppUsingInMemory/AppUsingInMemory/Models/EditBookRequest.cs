namespace AppUsingInMemory.Models
{
    public class EditBookRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Guid CategoryId { get; set; }
    }
}
