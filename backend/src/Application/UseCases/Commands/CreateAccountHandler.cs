using Domain.Aggregates;
using Infrastructure.Repositories;
using MediatR;

namespace Application.UseCases.Commands
{
    public sealed record CreateAccountCommand(string AccountNumber, decimal InitialDeposit) : IRequest<Guid>;

    public class CreateAccountHandler(IAccountRepository accountRepository) : IRequestHandler<CreateAccountCommand, Guid>
    {
        private readonly IAccountRepository _accountRepository = accountRepository;

        public async Task<Guid> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
        {
            var account = new Account(command.AccountNumber, command.InitialDeposit);
            
            await _accountRepository.AddAsync(account);

            return account.Id;
        }
    }
}
