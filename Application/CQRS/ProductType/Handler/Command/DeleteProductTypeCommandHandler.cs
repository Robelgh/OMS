using Application.CQRS.ProductType.Request.Command;
using Application.Exceptions;
using Application.Repository;
using Application.Response;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.ProductType.Handler.Command
{
    public class DeleteProductTypeCommandHandler : IRequestHandler<DeleteProductTypeCommand, BaseCommandResponse>
    {

        BaseCommandResponse response;
        private IProductTypeRepository _ProductTypeRepository;
        private IMapper _mapper;

        public DeleteProductTypeCommandHandler(IProductTypeRepository ProductTypeRepository, IMapper mapper)
        {
            _ProductTypeRepository = ProductTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteProductTypeCommand request, CancellationToken cancellationToken)
        {
            var Deduction = await _ProductTypeRepository.GetById(request.Id);
            try
            {
                await _ProductTypeRepository.Delete(Deduction);
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
         
            return response;
        }

    }
}
