using Application.CQRS.Orders.Request.Command;
using Application.CQRS.ProductType.Request.Command;
using Application.DTO.Order.Validator;
using Application.DTO.ProductType.Validator;
using Application.Repository;
using Application.Response;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Orders.Handler.Command
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IOrderRepository _OrderRepository;
        private IMapper _mapper;


        public CreateOrderCommandHandler(IOrderRepository OrderRepository, IMapper mapper)
        {
            _OrderRepository = OrderRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator = new OrderValidator();
            var validationResult = await validator.ValidateAsync(request.OrderDto);

            if (validationResult.IsValid == false)
            {
                var error = "";
                for (int i = 0; i < validationResult.Errors.Count; i++)
                {
                    error = error + validationResult.Errors[i];
                    if (i != validationResult.Errors.Count - 1)
                    {
                        error = error + ", ";
                    }
                }
                response.Success = false;
                response.Message = error;
                response.Status = "404";
            }
            else
            {
                try
                {
                  
                    var order = _mapper.Map<Order>(request.OrderDto);
                    order.Status = 1;
                    var AllOrder = await _OrderRepository.GetAll();
                    //let's assume that a maximum of 10 pending orders are delivered a day
                    var pendingOrder= AllOrder.Where((x)=> x.OrderStatus == 0).ToList();
                    int addday = (int) pendingOrder.Count() / 10;
                    order.DeliveryTime = DateTime.Now.AddDays(addday);
                    int NumOrder = AllOrder.Count();
                    order.OrderCode ="EC_OR_" + DateTime.Now.ToString("yyyyMMddss") + NumOrder.ToString();
                    order.Id = Guid.NewGuid();
                    var data = await _OrderRepository.Add(order);
                    response.Success = true;
                    response.Message = "Successfully Created";
                    response.Status = "200";
                }
                catch (Exception ex)
                {

                    response.Success = false;
                    response.Message = ex.Message;
                    response.Status = "404";
                }

            }


            return response;
        }
    }
}
