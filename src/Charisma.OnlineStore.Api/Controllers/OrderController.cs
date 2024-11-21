using Charisma.OnlineStore.Api.Response;
using Charisma.OnlineStore.Application.Commands.Orders.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Charisma.OnlineStore.Api.Controllers
{

    public class OrderController(IMediator mediator) : BaseController
    {
        private readonly IMediator mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrderCommand command,CancellationToken cancellationToken)
        {
            await mediator.Send(command,cancellationToken);
            return Ok(ApiResponse.Ok());
        }

    }
}
