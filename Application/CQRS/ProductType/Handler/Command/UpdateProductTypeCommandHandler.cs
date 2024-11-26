using Application.CQRS.ProductType.Request.Command;
using Application.DTO.ProductType.Validator;
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
    public class UpdateProductTypeCommandHandler : IRequestHandler<UpdateProductTypeCommand, BaseCommandResponse>
    {

        BaseCommandResponse response;
        private IProductTypeRepository _ProductTypeRepository;
        private IMapper _mapper;

        public UpdateProductTypeCommandHandler(IProductTypeRepository ProductTypeRepository, IMapper mapper)
        {


            _ProductTypeRepository = ProductTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateProductTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new ProductTypeValidator();
            var validationResult = await validator.ValidateAsync(request.ProductTypeDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var ProductType = await _ProductTypeRepository.GetById(request.ProductTypeDto.Id);
            _mapper.Map(request.ProductTypeDto, ProductType);
            try
            {
                await _ProductTypeRepository.Update(ProductType);
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
