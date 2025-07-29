using BusinessLayer.Dto.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class RegisterValidator: AbstractValidator<RegisterRequestDTO>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.TcNumber).NotEmpty().WithMessage("TC number can not be empty.")
                .Length(11).WithMessage("Tc number must be 11 digits long.")
                .Matches("^[0-9]{11}$").WithMessage("TC number must consist of digits only.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email can not be empty.")
                .EmailAddress().WithMessage("Please enter a valid email adress.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can not be empty.")
                .MinimumLength(6).WithMessage("Password must have at least 6 characters.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Password can not be empty.")
                .Equal(x => x.Password).WithMessage("Passwords do not match.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Name can not be empty.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Name can not be empty.");
        }
    }
}
