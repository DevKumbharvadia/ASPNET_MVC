namespace BookStoreApp.Models.ViewModel.EditRequest
{
    public class EditAuthorRequest
    {
        public Guid Id { get; set; }  // Primary Key (PK)
        public string Name { get; set; }  // Name of the author
    }
}
