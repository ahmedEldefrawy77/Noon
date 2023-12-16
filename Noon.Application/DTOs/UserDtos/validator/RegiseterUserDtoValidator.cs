using FluentValidation;
using Noon.Application.Contracts.Persistence.IRepository;
using Noon.Application.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Application.DTOs.UserDtos.validator
{
    public class RegiseterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        private readonly IUserRepository _userRepository;

        public RegiseterUserDtoValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

            RuleFor(p => p.Email).NotEmpty().WithMessage("{PropertyName} Couldnot be Empty")
                .NotNull()
                .MustAsync(async (email, _) =>
                {
                    return await _userRepository.IsEmailUniq(email);
                }).WithMessage("Email is Existed before, choose another one")
                .EmailAddress().WithMessage("{PropertyName} Must be a Valid Email Address")
                .Matches("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$");

            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("{PropertyName} Couldnot be Empty")
               .NotNull()
               .Matches("^(?:(?<1>[(])?(?<AreaCode>[2-9]\\d{2})(?(1)[)])(?(1)(?<2>[ ])|(?:(?<3>[-])|(?<4>[ ])))?)?(?<Prefix>[1-9]\\d{2})(?(AreaCode)(?:(?(1)(?(2)[- ]|[-]?))|(?(3)[-])|(?(4)[- ]))|[- ]?)(?<Suffix>\\d{4})$");

            RuleFor(p => p.Password).NotEmpty()
                .WithMessage("{PropertyName} Couldnot be Empty")
               .NotNull()
               .MinimumLength(5).WithMessage("Password lenght should be atleast 5");

        }
    }
}
