var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<MyAuthService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapGet("other", (HttpContext ctx) =>
{
    var cookie = ctx.Request.Headers.Cookie.FirstOrDefault(x => x.StartsWith("auth="));

    return cookie ?? "empty";
});
app.UseAuthorization();
app.MapGet("login", (MyAuthService auth) =>
{
    auth.Signin();
    return "ok";
});

app.MapControllers();

app.Run();


public class MyAuthService
{
    private readonly IHttpContextAccessor _ctx;

    public MyAuthService(IHttpContextAccessor ctx)
    {
        _ctx = ctx;
    }

    public void Signin()
    {
        _ctx.HttpContext.Response.Headers["set-cookie"] = "auth=name:test";
    }
}