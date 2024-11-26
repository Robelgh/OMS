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
    public class GetProductTypeListRequestHandler : IRequestHandler<GetProductTypeListRequest, List<ProductTypeDto>>
    {
        private IProductTypeRepository _ProductTypeRepository;
        private IMapper _mapper;

        public GetProductTypeListRequestHandler(IProductTypeRepository ProductTypeRepository, IMapper mapper)
        {
            _ProductTypeRepository = ProductTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductTypeDto>> Handle(GetProductTypeListRequest request, CancellationToken cancellationToken)
        {
            var ProductType = await _ProductTypeRepository.GetAll();
            //var activeDeduction = Deduction.Where(Deduction => Deduction.Status == 1).ToList();
            return _mapper.Map<List<ProductTypeDto>>(ProductType);
        }
    }
}
