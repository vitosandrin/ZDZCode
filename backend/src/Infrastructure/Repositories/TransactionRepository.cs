using Domain.Aggregates;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetByAccountIdAsync(Guid accountId);
        Task<Transaction?> GetByIdAsync(Guid transactionId);
    }
    public class TransactionRepository(AppDbContext context) : ITransactionRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Transaction>> GetByAccountIdAsync(Guid accountId)
            => await _context.Transactions
                .Where(t => EF.Property<Guid>(t, "AccountId") == accountId)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

        public async Task<Transaction?> GetByIdAsync(Guid transactionId)
            => await _context.Transactions
                .FirstOrDefaultAsync(t => t.Id == transactionId);

        private async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
