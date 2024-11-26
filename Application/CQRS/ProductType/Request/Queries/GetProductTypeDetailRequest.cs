using Application.DTO.ProductType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProductType.Request.Queries
{
    public class GetProductTypeDetailRequest : IRequest<ProductTypeDto>
    {
        public Guid Id { get; set; }
    

    }
}
