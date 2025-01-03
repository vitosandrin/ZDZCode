namespace Domain.Aggregates
{
    public class Account
    {
        private readonly List<Transaction> _transactions = new();

        public Guid Id { get; private set; }
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public IReadOnlyCollection<Transaction> Transactions => _transactions.AsReadOnly();

        private Account() { }

        public Account(string accountNumber, decimal initialDeposit)
        {
            if (initialDeposit < 0)
                throw new ArgumentException("Initial deposit cannot be negative.");

            Id = Guid.NewGuid();
            AccountNumber = accountNumber;
            Balance = initialDeposit;
            _transactions.Add(new Transaction(initialDeposit, "Initial Deposit"));
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be greater than zero.");

            if (Balance < amount)
                throw new InvalidOperationException("Insufficient balance.");

            Balance -= amount;
            _transactions.Add(new Transaction(-amount, "Withdrawal"));
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be greater than zero.");

            Balance += amount;
            _transactions.Add(new Transaction(amount, "Deposit"));
        }
    }
}
