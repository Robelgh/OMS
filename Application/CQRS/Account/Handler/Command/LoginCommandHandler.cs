using Application.CQRS.Account.Request.Command;
using Application.CQRS.ProductType.Request.Command;
using Application.DTO.Account.Validator;
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

namespace Application.CQRS.Account.Handler.Command
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, BaseCommandResponseAcccount>
    {
        BaseCommandResponseAcccount response;
        private IAccountRepository _AccountRepository;
        private IMapper _mapper;

        public LoginCommandHandler(IAccountRepository AccountRepository, IMapper mapper)
        {
            _AccountRepository = AccountRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponseAcccount> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponseAcccount();
            var validator = new AccountTypeValidator();
            var validationResult = await validator.ValidateAsync(request.accountDto);

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
                    
                    var data =await _AccountRepository.IsAuthenticated(request.accountDto);
                    if (data.Success)
                    {
                        response.Success = true;
                        response.Token = data.Token;
                        response.Status = "200";
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Incorrect Password or User Name";
                        response.Status = "200";
                    }
                  
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
