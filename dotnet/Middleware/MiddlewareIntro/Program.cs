var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Map("/test", async (pipeBuilder) =>
{
  pipeBuilder.Use(async (context, next) =>
  {
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync("1 start <br/>");
    await next.Invoke(); // invoke line 17
    await context.Response.WriteAsync("1 end <br/>");
  });
  pipeBuilder.Use(async (context, next) =>
  {
    await context.Response.WriteAsync("2 start <br/>");
    await next.Invoke(); // invoke line 23
    await context.Response.WriteAsync("2 end <br/>");
  });
  pipeBuilder.Run(async ctx =>
  {
    await ctx.Response.WriteAsync("Run <br/>");
  });
});

app.Run();
