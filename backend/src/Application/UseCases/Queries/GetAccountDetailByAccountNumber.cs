using Domain.Aggregates;
using Infrastructure.Exceptions;
using Infrastructure.Repositories;
using MediatR;

namespace Application.UseCases.Queries
{
    public sealed record GetAccountDetailByAccountNumberQuery(string AccountNumber) : IRequest<Account>;
    public class GetAccountDetailByAccountNumber(IAccountRepository accountRepository) : IRequestHandler<GetAccountDetailByAccountNumberQuery, Account>
    {
        private readonly IAccountRepository _accountRepository = accountRepository;

        public async Task<Account> Handle(GetAccountDetailByAccountNumberQuery query, CancellationToken cancellationToken)
            => await _accountRepository.FindAsync(x => x.AccountNumber == query.AccountNumber) 
                ?? throw new NotFoundException("Account", query.AccountNumber);
    }
}
