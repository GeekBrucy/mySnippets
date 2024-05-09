using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_fluent_validation.Dtos;
using FluentValidation;

namespace _02_fluent_validation.Validators;

public class AddNewUserRequestValidator : AbstractValidator<AddNewUserRequest>
{
  public AddNewUserRequestValidator()
  {
    RuleFor(x => x.Email).NotNull().EmailAddress();
    RuleFor(x => x.UserName).NotNull().Length(3, 10);
    RuleFor(x => x.Password).Equal(x => x.ConfirmPassword)
    .WithMessage(x => $"{nameof(x.Password)} must be the same as {nameof(x.ConfirmPassword)}")
    .WithName("trest"); // automatically change the property name
  }
}
