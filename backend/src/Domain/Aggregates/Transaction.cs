namespace Domain.Aggregates
{
    public class Transaction
    {
        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Transaction() { }

        public Transaction(decimal amount, string description)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            Description = description;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
