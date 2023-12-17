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
                .NotNull().WithMessage("{PropertyName} Couldnot be Null")
                .MaximumLength(50).WithMessage("{ProppertyName} Must not Exceed 50 Charachter");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} Couldnot be Empty")
                .NotNull().WithMessage("{PropertyName} Couldnot be Null")
                .MaximumLength(50).WithMessage("{ProppertyName} Must not Exceed 50 Charachter");

            RuleFor(p => p.Email).NotEmpty().WithMessage("{PropertyName} Couldnot be Empty")
                .NotNull()
                .MustAsync(async (email, _) =>
                {
                    return await _userRepository.IsEmailUniq(email);
                }).WithMessage("Email is Existed before, choose another one")
                .EmailAddress().WithMessage("{PropertyName} Must be a Valid Email Address");

            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("{PropertyName} Couldnot be Empty")
               .NotNull().WithMessage("{PropertyName} Couldnot be Null");


            RuleFor(p => p.Password).NotEmpty()
                .WithMessage("{PropertyName} Couldnot be Empty")
               .NotNull()
               .MinimumLength(5).WithMessage("Password lenght should be atleast 5");

        }
    }
}
