var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(b =>
    {
        var origins = builder.Configuration.GetSection("AllowedHosts").Value;
        b.WithOrigins(origins) // allow domains
        .AllowAnyMethod() // allow all methods. Use "WithMethods" to specify methods
        .AllowAnyHeader() // allow headers. 
        // .AllowCredentials() // allow credential and origin wild card cannot be set at the same time
        ;

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
// app.UseCors(x =>
// {
//     var origins = builder.Configuration.GetSection("AllowedHosts").Value;
//     x.WithOrigins(origins);
//     x.AllowAnyHeader();
//     x.AllowAnyMethod();
//     x.SetIsOriginAllowed(origin => true);
//     x.AllowCredentials();
// });
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
