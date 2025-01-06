using Domain.Aggregates;
using Infrastructure.Exceptions;
using Infrastructure.Repositories;
using MediatR;

namespace Application.UseCases.Queries
{
    public sealed record ListTransactionsQuery(Guid AccountId) : IRequest<IEnumerable<Transaction>>;

    public class ListTransactionsHandler(IUnityOfWork unityOfWork) : IRequestHandler<ListTransactionsQuery, IEnumerable<Transaction>>
    {
        private readonly ITransactionRepository _transactionRepository = unityOfWork.TransactionRepository;
        private readonly IAccountRepository _accountRepository = unityOfWork.AccountRepository;

        public async Task<IEnumerable<Transaction>> Handle(ListTransactionsQuery query, CancellationToken cancellationToken)
        {
            var _ = await _accountRepository.GetByIdAsync(query.AccountId)
                ?? throw new NotFoundException("Account", query.AccountId);

            var transactions = await _transactionRepository.GetByAccountIdAsync(query.AccountId);

            return transactions;
        }
    }
}
