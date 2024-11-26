using Application.CQRS.ProductType.Request.Queries;
using Application.DTO.ProductType;
using Application.Exceptions;
using Application.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProductType.Handler.Queries
{
    public class GetProductTypeDetailRequestHandler : IRequestHandler<GetProductTypeDetailRequest, ProductTypeDto>
    {
        private IProductTypeRepository _ProductTypeRepository;
        private IMapper _mapper;

        public GetProductTypeDetailRequestHandler(IProductTypeRepository ProductTypeRepository, IMapper mapper)
        {
            _ProductTypeRepository = ProductTypeRepository;
            _mapper = mapper;
        }
        public async Task<ProductTypeDto> Handle(GetProductTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var ProductType = await _ProductTypeRepository.GetById(request.Id);
            if (ProductType == null )
                throw new NotFoundException(nameof(ProductType), request.Id);

            else
                return _mapper.Map<ProductTypeDto>(ProductType);
        }
    }
}
