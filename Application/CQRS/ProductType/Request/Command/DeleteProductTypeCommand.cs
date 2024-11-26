﻿using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProductType.Request.Command
{
    public class DeleteProductTypeCommand : IRequest<BaseCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
