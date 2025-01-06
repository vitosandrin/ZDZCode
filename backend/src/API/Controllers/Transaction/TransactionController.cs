using Application.UseCases.Commands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.UseCases.Queries;
using Domain.Aggregates;

namespace API.Controllers.Transaction
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [Route("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] Request.Withdraw request)
        {
            var command = new WithdrawCommand(request.AccountId, request.Amount);
            await _mediator.Send(command);
            return Ok(new { message = "Withdrawal successful." });
        }

        [HttpPost]
        [Route("deposit")]
        public async Task<IActionResult> Deposit([FromBody] Request.Deposit request)
        {
            var command = new DepositCommand(request.AccountId, request.Amount);
            await _mediator.Send(command);
            return Ok(new { message = "Deposit successful." });
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions([FromQuery] Request.ListTransactions request)
        {
            var transactions = await _mediator.Send(new ListTransactionsQuery(request.AccountId));
            return Ok(transactions);
        }
    }
}
