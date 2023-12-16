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
               .Matches("?<FirstName>[A-Z]\\.?\\w*\\-?[A-Z]?\\w*)\\s?").WithMessage("{PropertyName} Must be a Valid Name")
               .MaximumLength(50).WithMessage("{ProppertyName} Must not Exceed 50 Charachter");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} Couldnot be Empty")
                .NotNull()
                .Matches("?<FirstName>[A-Z]\\.?\\w*\\-?[A-Z]?\\w*)\\s?").WithMessage("{PropertyName} Must be a Valid Name")
                .MaximumLength(50).WithMessage("{ProppertyName} Must not Exceed 50 Charachter");

            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("{PropertyName} Couldnot be Empty")
               .NotNull()
               .Matches("^(?:(?<1>[(])?(?<AreaCode>[2-9]\\d{2})(?(1)[)])(?(1)(?<2>[ ])|(?:(?<3>[-])|(?<4>[ ])))?)?(?<Prefix>[1-9]\\d{2})(?(AreaCode)(?:(?(1)(?(2)[- ]|[-]?))|(?(3)[-])|(?(4)[- ]))|[- ]?)(?<Suffix>\\d{4})$");
        }
    }
}
