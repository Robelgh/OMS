﻿using Application.DTO.Order;
using Application.DTO.ProductType;
using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Orders.Request.Command
{
    public class CreateOrderCommand : IRequest<BaseCommandResponse>
    {
        public OrderDto OrderDto { get; set; }
    }
}
