

using Application.CQRS.Account.Request.Command;
using Application.CQRS.ProductType.Handler.Queries;
using Application.CQRS.ProductType.Request.Command;
using Application.CQRS.ProductType.Request.Queries;
using Application.DTO.Account;
using Application.DTO.ProductType;
using Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            this._httpContextAccessor = httpContextAccessor;
        }

      


        [HttpPost("login")]
        public async Task<ActionResult<BaseCommandResponseAcccount>> Post([FromForm] AccountDto account)
        {
            var user = _httpContextAccessor.HttpContext.User;
            var command = new LoginCommand { accountDto = account };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

     
    }
}

