namespace BookStoreApp.Models.Domain
{
    public class TransactionHistory
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public DateTime TransactionTime { get; set; }
        public Guid UserId { get; set; }
    }
}
