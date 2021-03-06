using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace V6shopSolution.ViewModel.System.Users
{
  public  class LoginRequestValidator : AbstractValidator<LoginRequest> //1 class chứa các rule mà ta muốn validate
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("password is at least 6  characters");
        }
    }
}
