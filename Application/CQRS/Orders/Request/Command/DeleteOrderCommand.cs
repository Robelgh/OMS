using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Orders.Request.Command
{
    public class DeleteOrderCommand : IRequest<BaseCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
