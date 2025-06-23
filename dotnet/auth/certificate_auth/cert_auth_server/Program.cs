using Microsoft.AspNetCore.Authentication.Certificate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// 配置证书认证
builder.Services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme)
    .AddCertificate(options =>
    {
        options.AllowedCertificateTypes = CertificateTypes.All;
        options.ValidateCertificateUse = true;
        options.ValidateValidityPeriod = true;
        options.RevocationFlag = System.Security.Cryptography.X509Certificates.X509RevocationFlag.EntireChain;
        options.RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck;
    });

// 配置授权
builder.Services.AddAuthorization();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
