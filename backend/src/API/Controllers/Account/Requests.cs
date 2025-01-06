namespace API.Controllers.Account
{
    public static class Request
    {
        public sealed record CreateAccount(string AccountNumber, decimal InitialDeposit);
    }
}
