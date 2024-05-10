using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_fluent_validation.Dtos;
using FluentValidation;
using IdentityServerConfig.Data;

namespace _02_fluent_validation.Validators;

public class AddNewUserRequestValidator : AbstractValidator<AddNewUserRequest>
{
  public AddNewUserRequestValidator(MyDbContext dbContext)
  {
    RuleFor(x => x.Email).NotNull().EmailAddress();
    RuleFor(x => x.UserName).NotNull().Length(3, 10)
      // it is recommended to use async to query db, but fluent validation v11+ doesn't allow async validation check
      // the solution could be add another layer to perform domain validation
      .Must(x => dbContext.Users.Any(db => db.UserName == x) == false).WithMessage("User exists");
    RuleFor(x => x.Password).Equal(x => x.ConfirmPassword)
    .WithMessage(x => $"{nameof(x.Password)} must be the same as {nameof(x.ConfirmPassword)}")
    .WithName("trest"); // automatically change the property name
  }
}
