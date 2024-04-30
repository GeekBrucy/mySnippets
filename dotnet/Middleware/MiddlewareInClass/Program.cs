using MiddlewareInClass.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.Map("/test", async pipeBuilder =>
{
  pipeBuilder.UseMiddleware<CheckPwdMiddleware>();
  pipeBuilder.UseMiddleware<TestMiddleware>();
  pipeBuilder.Run(async ctx =>
  {
    await ctx.Response.WriteAsync("Run<br />");
    dynamic? obj = ctx.Items["BodyJson"];
    await ctx.Response.WriteAsync($"{obj}<br />");
  });
});
app.Run();
