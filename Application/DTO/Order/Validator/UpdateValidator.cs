﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Order.Validator
{
    public class UpdateValidator : AbstractValidator<updateOrderDto>
    {
        public UpdateValidator()
        {
            RuleFor(p => p.Quantity)
               .NotEmpty().WithMessage("{PropertyName} is requiered.")
               .NotNull();
        }
    }
}
