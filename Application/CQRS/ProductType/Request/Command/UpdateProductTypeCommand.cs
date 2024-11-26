using Application.DTO.ProductType;
using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProductType.Request.Command
{
    public class UpdateProductTypeCommand : IRequest<BaseCommandResponse>
    {
        public ProductTypeDto ProductTypeDto { get; set; }
    }
}
