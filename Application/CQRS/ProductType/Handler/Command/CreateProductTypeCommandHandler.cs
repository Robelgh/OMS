using Application.CQRS.ProductType.Request.Command;
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

namespace Application.CQRS.ProductType.Handler.Command
{
    public class CreateProductTypeCommandHandler : IRequestHandler<CreateProductTypeCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IProductTypeRepository _ProductTypeRepository;
        private IMapper _mapper;
        public CreateProductTypeCommandHandler(IProductTypeRepository ProductTypeRepository, IMapper mapper)
        {
            _ProductTypeRepository = ProductTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator = new ProductTypeValidator();
            var validationResult = await validator.ValidateAsync(request.ProductTypeDto);

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
                    var ProductType = _mapper.Map<ProductTypes>(request.ProductTypeDto);
                    ProductType.Status = 1;
                    var Allpro = await _ProductTypeRepository.GetAll();
                    int NumOrder = Allpro.Count();
                    ProductType.ProductTypeCode = "EC_PRO_" + DateTime.Now.ToString("yyyyMMddss") + NumOrder.ToString();
                    ProductType.Id = Guid.NewGuid();
                    var data = await _ProductTypeRepository.Add(ProductType);
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
