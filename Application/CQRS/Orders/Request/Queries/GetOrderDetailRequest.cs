using Application.DTO.Order;
using Application.DTO.ProductType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Orders.Request.Queries
{
    public class GetOrderDetailRequest : IRequest<OrderDto>
    {
        public Guid Id { get; set; }


    }
}
