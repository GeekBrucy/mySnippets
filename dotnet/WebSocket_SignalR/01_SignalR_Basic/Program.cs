using _01_SignalR_Basic.WebSocketHub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR().AddStackExchangeRedis("127.0.0.1", opt =>
{
    opt.Configuration.ChannelPrefix = "Test1_";
});
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder => builder
        .WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
    );
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapHub<MyHub>("/myHub");
app.MapControllers();

app.Run();
