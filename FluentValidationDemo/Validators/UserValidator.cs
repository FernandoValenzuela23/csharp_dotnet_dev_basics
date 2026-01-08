using FluentValidation;
using FluentValidationDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationDemo.Validators
{
    public class UserValidator : AbstractValidator<User>
    {

        public UserValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MinimumLength(15).WithMessage("Name must be at least 15 characters long.");

            RuleFor(user => user.Age)
                .InclusiveBetween(16, 120).WithMessage("Age must be up to 16.");
        }
    }
}
