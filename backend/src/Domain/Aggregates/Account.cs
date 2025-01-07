namespace Domain.Aggregates
{
    public class Account
    {
        private readonly List<Transaction> _transactions = [];

        public Guid Id { get; private set; }
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public IReadOnlyCollection<Transaction> Transactions => _transactions.AsReadOnly();

        private Account() { }

        public Account(string accountNumber, decimal initialDeposit)
        {
            Id = Guid.NewGuid();
            AccountNumber = accountNumber;
            Balance = initialDeposit;
            _transactions.Add(new Transaction(initialDeposit, "Initial Deposit"));
            CreatedAt = DateTime.UtcNow;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
            _transactions.Add(new Transaction(-amount, "Withdrawal"));
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            _transactions.Add(new Transaction(amount, "Deposit"));
        }
    }
}
