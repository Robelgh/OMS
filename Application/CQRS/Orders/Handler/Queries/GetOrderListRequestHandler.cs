using Application.CQRS.Orders.Request.Queries;
using Application.CQRS.ProductType.Request.Queries;
using Application.DTO.Order;
using Application.DTO.ProductType;
using Application.Repository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Orders.Handler.Queries
{
    public class GetOrderListRequestHandler : IRequestHandler<GetOrderListRequest, List<OrderDto>>
    {

        private IOrderRepository _OrderRepository;
        private IMapper _mapper;

        public GetOrderListRequestHandler(IOrderRepository OrderRepository, IMapper mapper)
        {
            _OrderRepository = OrderRepository;
            _mapper = mapper;
        }
        public async Task<List<OrderDto>> Handle(GetOrderListRequest request, CancellationToken cancellationToken)
        {
            var ProductType = await _OrderRepository.GetAll();
            return _mapper.Map<List<OrderDto>>(ProductType);
        }
    }
}
