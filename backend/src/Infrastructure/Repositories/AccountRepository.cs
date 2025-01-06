using Domain.Aggregates;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetByIdAsync(Guid id);
        Task AddAsync(Account account);
    }

    public class AccountRepository(AppDbContext context) : IAccountRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Account> GetByIdAsync(Guid id)
            => await _context.Accounts
                                 .Include(a => a.Transactions)
                                 .FirstOrDefaultAsync(a => a.Id == id);

        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }
    }
}
