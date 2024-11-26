using Application.CQRS.Orders.Request.Command;
using Application.CQRS.ProductType.Request.Command;
using Application.Repository;
using Application.Response;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Orders.Handler.Command
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, BaseCommandResponse>
    {

        BaseCommandResponse response;
        private IOrderRepository _OrderRepository;
        private IMapper _mapper;

        public DeleteOrderCommandHandler(IOrderRepository OrderRepository, IMapper mapper)
        {
            _OrderRepository = OrderRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var order = await _OrderRepository.GetById(request.Id);
            try
            {
                await _OrderRepository.Delete(order);
                response.Success = true;
                response.Message = "Successfully Deleted";
                response.Status = "200";
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;
                response.Status = "404";
            }

            return response;
        }

    }
}
