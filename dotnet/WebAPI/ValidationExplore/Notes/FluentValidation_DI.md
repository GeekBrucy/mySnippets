### **How to Automatically Register Validators**
You can register all validators in your application with a single line of code using `AddValidatorsFromAssembly` or `AddValidatorsFromAssemblyContaining`.

#### Example: Registering Validators Automatically
1. **Install FluentValidation Dependency Injection Package**:
   Make sure you have the `FluentValidation.DependencyInjectionExtensions` package installed:
```bash
dotnet add package FluentValidation
dotnet add package FluentValidation.DependencyInjectionExtensions
```

2. **Register Validators in `Program.cs` or `Startup.cs`**:
   Use `AddValidatorsFromAssemblyContaining` to scan the assembly and register all validators.

   ```csharp
   using FluentValidation.AspNetCore;
   using FluentValidation;

   public class Program
   {
       public static void Main(string[] args)
       {
           var builder = WebApplication.CreateBuilder(args);

           // Add services to the container.
           builder.Services.AddControllers();

           // Register all validators in the assembly containing a specific validator
           builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

           var app = builder.Build();

           // Configure the HTTP request pipeline.
           app.UseHttpsRedirection();
           app.UseAuthorization();
           app.MapControllers();

           app.Run();
       }
   }
   ```

   Alternatively, you can scan all validators in a specific assembly:
   ```csharp
   builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
   ```

   This will automatically register all validators in the specified assembly.

---

### **How It Works**
- FluentValidation scans the specified assembly for classes that inherit from `AbstractValidator<T>`.
- It registers each validator with the DI container, so they can be resolved automatically when needed.
- You don’t need to manually register each validator.

---

### **Using Validators in Web API**
Once the validators are registered, FluentValidation integrates seamlessly with ASP.NET Core's model validation pipeline. You don’t need to manually invoke the validators in your controllers.

#### Example: Automatic Validation in Web API
1. **Enable Automatic Validation**:
   Ensure your controllers are decorated with the `[ApiController]` attribute. This enables automatic model validation.

   ```csharp
   [ApiController]
   [Route("api/[controller]")]
   public class UsersController : ControllerBase
   {
       [HttpPost]
       public IActionResult CreateUser(User user)
       {
           // If the model is invalid, the API will automatically return a 400 Bad Request
           // with validation error details.
           return Ok("User created successfully.");
       }
   }
   ```

2. **Validation Response**:
   If the model is invalid, ASP.NET Core will automatically return a `400 Bad Request` response with validation error details. For example:
   ```json
   {
     "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
     "title": "One or more validation errors occurred.",
     "status": 400,
     "errors": {
       "Username": ["Username is required."],
       "Email": ["Invalid email format."]
     }
   }
   ```

---

### **Customizing Validation Behavior**
If you want to customize the validation behavior (e.g., change the response format), you can use the `FluentValidation.AspNetCore` package.

1. **Install the Package**:
   ```bash
   dotnet add package FluentValidation.AspNetCore
   ```

2. **Configure FluentValidation in `Program.cs`**: 
   ```csharp
   builder.Services.AddControllers()
       .AddFluentValidation(fv =>
       {
           fv.RegisterValidatorsFromAssemblyContaining<UserValidator>();
           fv.AutomaticValidationEnabled = true; // Enable automatic validation
           fv.ImplicitlyValidateChildProperties = true; // Validate nested objects
       });
   ```

Note: the implementation above is obsoleted, use the following instead:
```c#
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<Customer>, CustomerValidator>(); // must have!!
```

3. **Customize Validation Response**:
   You can customize the validation response by overriding the `InvalidModelStateResponseFactory`:
   ```csharp
   builder.Services.Configure<ApiBehaviorOptions>(options =>
   {
       options.InvalidModelStateResponseFactory = context =>
       {
           var errors = context.ModelState
               .Where(e => e.Value.Errors.Count > 0)
               .ToDictionary(
                   kvp => kvp.Key,
                   kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
               );

           return new BadRequestObjectResult(new
           {
               Message = "Validation errors occurred.",
               Errors = errors
           });
       };
   });
   ```

---

### **When to Manually Register Validators**
In most cases, you won’t need to manually register validators. However, if you have validators in multiple assemblies or want to register specific validators, you can do so like this:
```csharp
builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddScoped<IValidator<Order>, OrderValidator>();
```

Alternatively, we can scan all assemblies:
```c#
var assemblies = AppDomain.CurrentDomain.GetAssemblies();
builder.Services.AddValidatorsFromAssemblies(assemblies);
```

---

### **Summary**
- You **do not need to manually register every validator** in the DI container.
- Use `AddValidatorsFromAssemblyContaining` or `AddValidatorsFromAssembly` to automatically register all validators in an assembly.
- FluentValidation integrates with ASP.NET Core's validation pipeline, so invalid models automatically return a `400 Bad Request` response with error details.
- You can customize the validation behavior and response format if needed.

This approach keeps your code clean and maintainable while leveraging the full power of FluentValidation. Let me know if you have further questions!