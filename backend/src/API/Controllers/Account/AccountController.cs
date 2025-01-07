using Application.UseCases.Commands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.UseCases.Queries;

namespace API.Controllers.Account
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateAccount([FromBody] Request.CreateAccount request)
        {
            var command = new CreateAccountCommand(request.AccountNumber, request.InitialDeposit);

            var accountId = await _mediator.Send(command);
            return Ok(new { AccountId = accountId });
        }

        [HttpGet]
        [Route("{accountNumber}")]
        public async Task<IActionResult> GetAccountDetail([FromRoute] string accountNumber)
        {
            var account = await _mediator.Send(new GetAccountDetailByAccountNumberQuery(accountNumber));
            return Ok(account);
        }
    }
}
