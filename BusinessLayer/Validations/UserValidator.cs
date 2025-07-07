using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Dto;

namespace BusinessLayer.Validations
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator() 
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Lütfen adınızı giriniz.").Must(beStringOnly).WithMessage("Lütfen geçerli bir ad giriniz.");
            RuleFor(x => x.Tcnumber).NotNull().WithMessage("Lütfen TC numaranızı giriniz.").Length(11).WithMessage("Lütfen geçerli bir TC giriniz.");

        }

        private bool beStringOnly(string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            else
            {
                return value.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
            }       
        }
    }
}
