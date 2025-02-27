# Official doc
https://docs.fluentvalidation.net/en/latest/

### 1. **Can FluentValidation be applied to an interface?**
Yes, you can apply FluentValidation to an interface, but it requires a bit of workaround since FluentValidation works directly with concrete classes. Here's how you can achieve this:

#### Example: Common Validation for Interface
Suppose you have an interface `IUser` with common fields, and multiple classes implement this interface.

```csharp
public interface IUser
{
    string Username { get; set; }
    string Email { get; set; }
    string Password { get; set; }
}

public class User : IUser
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class AdminUser : IUser
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
```

You can create a base validator for the interface and reuse it for concrete classes:

```csharp
public class UserValidator<T> : AbstractValidator<T> where T : IUser
{
    public UserValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");
    }
}

// Specific validators for concrete classes
public class AdminUserValidator : UserValidator<AdminUser>
{
    public AdminUserValidator()
    {
        RuleFor(x => x.Role)
            .NotEmpty().WithMessage("Role is required.");
    }
}
```

**Usage:**
```csharp
var user = new User { Username = "test", Email = "test@example.com", Password = "password" };
var validator = new UserValidator<User>();
var result = validator.Validate(user);

var adminUser = new AdminUser { Username = "admin", Email = "admin@example.com", Password = "password", Role = "" };
var adminValidator = new AdminUserValidator();
var adminResult = adminValidator.Validate(adminUser);
```

---

### 2. **How complex can FluentValidation go?**
FluentValidation is extremely flexible and can handle very complex validation scenarios. Here are some examples:

#### a. **Cross-Field Validation**
You can validate one field based on the value of another field.

```csharp
RuleFor(x => x.EndDate)
    .GreaterThan(x => x.StartDate)
    .WithMessage("End date must be after the start date.");
```

#### b. **Conditional Validation**
You can apply validation rules conditionally.

```csharp
RuleFor(x => x.Password)
    .NotEmpty()
    .When(x => x.RequiresPassword)
    .WithMessage("Password is required when RequiresPassword is true.");
```

#### c. **Custom Validation Logic**
You can define custom validation logic using the `Must` method.

```csharp
RuleFor(x => x.Username)
    .Must(BeUniqueUsername)
    .WithMessage("Username must be unique.");

private bool BeUniqueUsername(string username)
{
    // Check if the username is unique in the database
    return !_userRepository.Exists(username);
}
```

#### d. **Collection Validation**
You can validate collections within a model.

```csharp
RuleForEach(x => x.OrderItems)
    .SetValidator(new OrderItemValidator());
```

#### e. **Inheritance and Reusability**
You can create reusable validators and inherit from them, as shown in the interface example above.

---

### 3. **How to do async validation with FluentValidation?**
FluentValidation supports asynchronous validation using the `MustAsync` or `CustomAsync` methods. This is useful for scenarios like checking if a value exists in a database.

#### Example: Async Validation
```csharp
public class UserValidator : AbstractValidator<User>
{
    private readonly IUserRepository _userRepository;

    public UserValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MustAsync(BeUniqueUsernameAsync).WithMessage("Username must be unique.");
    }

    private async Task<bool> BeUniqueUsernameAsync(string username, CancellationToken cancellationToken)
    {
        return !await _userRepository.ExistsAsync(username);
    }
}
```

**Usage:**
```csharp
var user = new User { Username = "test" };
var validator = new UserValidator(new UserRepository());
var result = await validator.ValidateAsync(user);
```

---

### 4. **Can FluentValidation do dependency injection?**
Yes, FluentValidation integrates seamlessly with dependency injection (DI) in ASP.NET Core. You can inject services into your validators.

#### Example: Dependency Injection
1. **Register Validators in DI Container:**
   ```csharp
   public void ConfigureServices(IServiceCollection services)
   {
       services.AddControllers();
       services.AddScoped<IUserRepository, UserRepository>();
       services.AddValidatorsFromAssemblyContaining<UserValidator>();
   }
   ```

2. **Inject Services into Validator:**
   ```csharp
   public class UserValidator : AbstractValidator<User>
   {
       private readonly IUserRepository _userRepository;

       public UserValidator(IUserRepository userRepository)
       {
           _userRepository = userRepository;

           RuleFor(x => x.Username)
               .NotEmpty().WithMessage("Username is required.")
               .MustAsync(BeUniqueUsernameAsync).WithMessage("Username must be unique.");
       }

       private async Task<bool> BeUniqueUsernameAsync(string username, CancellationToken cancellationToken)
       {
           return !await _userRepository.ExistsAsync(username);
       }
   }
   ```

3. **Automatic Validation in ASP.NET Core:**
   FluentValidation automatically integrates with ASP.NET Core's model validation pipeline. Just use the `[ApiController]` attribute, and it will handle validation for you.

---

### Summary
- **Interfaces**: You can create reusable validators for interfaces using generics.
- **Complexity**: FluentValidation can handle very complex validation scenarios, including cross-field validation, conditional validation, and custom logic.
- **Async Validation**: Use `MustAsync` or `CustomAsync` for asynchronous validation.
- **Dependency Injection**: Validators can use dependency injection to access services like repositories.

FluentValidation is a powerful and flexible library that can handle almost any validation scenario you throw at it. Let me know if you need further clarification or examples!