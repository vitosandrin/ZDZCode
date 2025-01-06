using Domain.Aggregates;
using Infrastructure.Exceptions;
using Infrastructure.Repositories;
using MediatR;

namespace Application.UseCases.Commands
{
    public sealed record WithdrawCommand(Guid AccountId, decimal Amount) : IRequest;

    public class WithdrawHandler(IUnityOfWork unityOfWork) : IRequestHandler<WithdrawCommand>
    {
        private readonly ITransactionRepository _transactionRepository = unityOfWork.TransactionRepository;
        private readonly IAccountRepository _accountRepository = unityOfWork.AccountRepository;
        public async Task Handle(WithdrawCommand command, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByIdAsync(command.AccountId)
                ?? throw new NotFoundException("Account", command.AccountId);

            account.Withdraw(command.Amount);

            await _transactionRepository.AddAsync(account.Transactions.Last());
        }
    }
}
