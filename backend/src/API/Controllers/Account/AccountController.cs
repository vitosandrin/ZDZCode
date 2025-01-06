using Application.UseCases.Commands;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace API.Controllers.Account
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAccount([FromBody] Request.CreateAccount request)
        {
            var command = new CreateAccountCommand(request.AccountNumber, request.InitialDeposit);

            var accountId = await _mediator.Send(command);
            return Ok(new { AccountId = accountId });
        }
    }
}
