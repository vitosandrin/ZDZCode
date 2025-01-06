using Infrastructure.Exceptions;
using Infrastructure.Repositories;
using MediatR;

namespace Application.UseCases.Commands
{
    public sealed record DepositCommand(Guid AccountId, decimal Amount) : IRequest;

    public class DepositHandler(IUnityOfWork unityOfWork) : IRequestHandler<DepositCommand>
    {
        private readonly ITransactionRepository _transactionRepository = unityOfWork.TransactionRepository;
        private readonly IAccountRepository _accountRepository = unityOfWork.AccountRepository;
        public async Task Handle(DepositCommand command, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByIdAsync(command.AccountId)
                ?? throw new NotFoundException("Account", command.AccountId);

            account.Deposit(command.Amount);

            await _transactionRepository.AddAsync(account.Transactions.Last());
        }
    }
}
