using Domain.Aggregates;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IAccountRepository
    {
        Task<Account?> GetByIdAsync(Guid id);
        Task<Account?> FindAsync(Expression<Func<Account, bool>> predicate);
        Task AddAsync(Account account);
    }

    public class AccountRepository(AppDbContext context) : IAccountRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Account?> GetByIdAsync(Guid id)
            => await _context.Accounts
                             .Include(a => a.Transactions)
                             .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<Account?> FindAsync(Expression<Func<Account, bool>> predicate)
            => await _context.Accounts
                             .Include(a => a.Transactions)
                             .FirstOrDefaultAsync(predicate);

        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }
    }
}
