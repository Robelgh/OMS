using Application.CQRS.Orders.Request.Command;
using Application.DTO.Order.Validator;
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
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IOrderRepository _OrderRepository;
        private IMapper _mapper;


        public UpdateOrderCommandHandler(IOrderRepository OrderRepository, IMapper mapper)
        {
            _OrderRepository = OrderRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator = new UpdateValidator();
            var validationResult = await validator.ValidateAsync(request.updateOrderDto);

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
                    var ordertoupdate = await _OrderRepository.GetById(request.updateOrderDto.Id);
                    if(request.updateOrderDto.commandApprove == 1)
                    {
                        ordertoupdate.OrderStatus = 1;
                    }
                    else
                    {
                        _mapper.Map(request.updateOrderDto, ordertoupdate);
                              
                    }

                    await _OrderRepository.Update(ordertoupdate);
                    response.Success = true;
                    response.Message = "Successfully Updated";
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
