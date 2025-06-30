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

        }
    }
}
