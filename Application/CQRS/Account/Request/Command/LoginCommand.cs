using Application.DTO.Account;
using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Account.Request.Command
{
    public class LoginCommand : IRequest<BaseCommandResponseAcccount>
    {
       public AccountDto accountDto { get; set; }
    }
}
