namespace BookStoreApp.Models.ViewModel.EditRequest
{
    public class EditBookRequest
    {
        public Guid Id { get; set; }  // Primary Key (PK)
        public string Title { get; set; }  // Title of the book

        // Foreign Key to Author
        public Guid AuthorId { get; set; }  // Foreign key to Author table

        // Foreign Key to Publisher
        public Guid PublisherId { get; set; }  // Foreign key to Publisher table

        // Foreign Key to Category
        public Guid CategoryId { get; set; }  // Foreign key to Category table
        public string ImageUrl { get; set; }  // URL or path to the book cover image


    }
}
