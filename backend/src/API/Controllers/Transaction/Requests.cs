namespace API.Controllers.Transaction
{
    public static class Request
    {
        public sealed record Withdraw(Guid AccountId, decimal Amount);
        public sealed record Deposit(Guid AccountId, decimal Amount);
        public sealed record ListTransactions(string AccountNumber);
    }
}
