# Dotnet Validation

## Built in

`DataAnnotations` can fulfill most of the scenarios.

It allows custom validations by developing `CustomValidationAttribute` or `IValidatableObject`

### Pros

Tightly coupled with the model. Violate `Single Responsibility`

## FluentValidation

- Nuget: `FluentValidation.AspNetCore`

### Basic usage

- Create a custom validator class
- Inherit from `AbstractValidator<T>`
- Write validation rules in the custom validator class constructor

```c#
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
```
