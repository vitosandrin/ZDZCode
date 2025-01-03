using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public interface IUnityOfWork
    {
        IAccountRepository AccountRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        Task CommitAsync();
    }

    public class UnityOfWork(
        AppDbContext context,
        IAccountRepository accountRepository,
        ITransactionRepository transactionRepository) : IUnityOfWork, IDisposable
    {
        private IAccountRepository? _accountRepository = accountRepository;
        private ITransactionRepository? _transactionRepository = transactionRepository;

        private readonly AppDbContext _context = context;

        public IAccountRepository AccountRepository
        {
            get
            {
                return _accountRepository ??= new AccountRepository(_context);
            }
        }
        public ITransactionRepository TransactionRepository
        {
            get
            {
                return _transactionRepository ??= new TransactionRepository(_context);
            }
        }


        public async Task CommitAsync()
            => await _context.SaveChangesAsync();

        public void Dispose()
            => _context.Dispose();
    }

}
