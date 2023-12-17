using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.DTOs.Validator
{
    public class IUserValidator : AbstractValidator<IUserDto>
    {
        public IUserValidator()
        {
            RuleFor(p => p.FirstName)
               .NotEmpty().WithMessage("{PropertyName} Couldnot be Empty")
               .NotNull()
               .MaximumLength(50).WithMessage("{ProppertyName} Must not Exceed 50 Charachter");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} Couldnot be Empty")
                .NotNull()

                .MaximumLength(50).WithMessage("{ProppertyName} Must not Exceed 50 Charachter");

            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("{PropertyName} Couldnot be Empty")
               .NotNull().WithMessage("{PropertName} Cannot be Null");
              
        }
    }
}
