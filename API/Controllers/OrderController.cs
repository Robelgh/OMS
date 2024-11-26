using Application.CQRS.Orders.Handler.Queries;
using Application.CQRS.Orders.Request.Command;
using Application.CQRS.Orders.Request.Queries;
using Application.CQRS.ProductType.Request.Command;
using Application.CQRS.ProductType.Request.Queries;
using Application.DTO.Order;
using Application.DTO.ProductType;
using Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> Get()
        {
            var producttype = await _mediator.Send(new GetOrderListRequest());
            return Ok(producttype);
        }


        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] OrderDto order)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateOrderCommand { OrderDto = order };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]

        public async Task<ActionResult<BaseCommandResponse>> Put([FromForm] updateOrderDto order)
        {
            var command = new UpdateOrderCommand { updateOrderDto = order };

            var response = await _mediator.Send(command);
            return Ok(response);
        }



        [HttpDelete("{id}")]

        public async Task<ActionResult<BaseCommandResponse>> Delete(Guid id)
        {
            var command = new DeleteOrderCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
