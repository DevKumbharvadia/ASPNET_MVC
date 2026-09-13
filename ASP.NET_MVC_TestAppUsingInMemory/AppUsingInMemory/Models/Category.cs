namespace AppUsingInMemory.Models;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    // Navigation property for books
    public ICollection<Book> Books { get; set; }
}
