using System.Reflection;
using System.Text.Json;
using api.Models;
using api.SchemasFilter;
using api.Services;
using Swashbuckle.AspNetCore.Swagger;

var builder = WebApplication.CreateBuilder(args);
var hasGetDocumentCommand = Environment.CommandLine.ToLower().Contains("getdocument");
Console.WriteLine(new string('@', 50));
Console.WriteLine(Environment.GetCommandLineArgs());
Console.WriteLine(Environment.CommandLine);
if (hasGetDocumentCommand)
{
    Console.WriteLine("run with get document");
}
else
{
    builder.Services.AddScoped<TestService>();
    Console.WriteLine("run without get document");
}
Console.WriteLine(new string('@', 50));
// Add services to the container.
Console.WriteLine();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Add external document
    options.SwaggerDoc("external", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "External API",
        Version = "v1"
    });

    // Add internal document
    options.SwaggerDoc("internal", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Internal API",
        Version = "v1"
    });

    options.UseOneOfForPolymorphism();
    options.DocInclusionPredicate((documentName, apiDescription) =>
    {
        var groupName = apiDescription.GroupName;
        return documentName switch
        {
            "external" => groupName == "external",
            "internal" => groupName == "internal",
            _ => false
        };
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/external/swagger.json", "External API");
        c.SwaggerEndpoint("/swagger/internal/swagger.json", "Internal API");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
