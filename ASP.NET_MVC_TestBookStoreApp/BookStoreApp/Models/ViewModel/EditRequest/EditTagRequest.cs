namespace BookStoreApp.Models.ViewModel.EditRequest
{
    public class EditTagRequest
    {
        public Guid Id { get; set; }  // Unique identifier for the tag
        public string Name { get; set; }  // Name of the tag
    }
}
