using Application.CQRS.ProductType.Handler.Queries;
using Application.CQRS.ProductType.Request.Command;
using Application.CQRS.ProductType.Request.Queries;
using Application.DTO.ProductType;
using Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductTypeController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductTypeDto>>> Get()
        {
            var producttype = await _mediator.Send(new GetProductTypeListRequest());
            return Ok(producttype);
        }

     
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] ProductTypeDto producttype)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateProductTypeCommand { ProductTypeDto = producttype };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] ProductTypeDto producttype)
        {
            var command = new UpdateProductTypeCommand { ProductTypeDto = producttype };

            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<BaseCommandResponse>> Delete(Guid id)
        {
            var command = new DeleteProductTypeCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
