using Domain.Aggregates;
using Infrastructure.Exceptions;
using Infrastructure.Repositories;
using MediatR;

namespace Application.UseCases.Queries
{
    public sealed record ListTransactionsQuery(string AccountNumber) : IRequest<IEnumerable<Transaction>>;

    public class ListTransactionsHandler(IUnityOfWork unityOfWork) : IRequestHandler<ListTransactionsQuery, IEnumerable<Transaction>>
    {
        private readonly ITransactionRepository _transactionRepository = unityOfWork.TransactionRepository;
        private readonly IAccountRepository _accountRepository = unityOfWork.AccountRepository;

        public async Task<IEnumerable<Transaction>> Handle(ListTransactionsQuery query, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.FindAsync(x => x.AccountNumber == query.AccountNumber)
                ?? throw new NotFoundException("Account", query.AccountNumber);

            var transactions = await _transactionRepository.GetByAccountIdAsync(account.Id);

            return transactions;
        }
    }
}
