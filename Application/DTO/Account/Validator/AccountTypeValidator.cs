using Application.DTO.ProductType;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Account.Validator
{
    public class AccountTypeValidator : AbstractValidator<AccountDto>
    {
        public AccountTypeValidator()
        {
            RuleFor(p => p.UserName)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();

            RuleFor(p => p.Password)
              .NotEmpty().WithMessage("{PropertyName} is requiered.")
              .NotNull();
        }
    }
}
