using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Certificate;
using cert_auth_server.Services;
using cert_auth_server.Models;
using Microsoft.AspNetCore.Server.IISIntegration;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = IISDefaults.AuthenticationScheme;
        options.DefaultAuthenticateScheme = IISDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = IISDefaults.Negotiate;
        options.DefaultForbidScheme = IISDefaults.AuthenticationScheme;
    })
    .AddCertificate(options =>
    {
        // 配置证书验证选项
        options.AllowedCertificateTypes = CertificateTypes.All;
        options.ValidateCertificateUse = false; // 暂时禁用用途验证
        options.ValidateValidityPeriod = true;
        options.RevocationFlag = System.Security.Cryptography.X509Certificates.X509RevocationFlag.EntireChain;
        options.RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck;

        // 添加详细的证书验证事件处理
        options.Events = new CertificateAuthenticationEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("🔴 [Certificate Auth] Authentication failed");
                Console.WriteLine($"   Exception: {context.Exception?.Message}");
                Console.WriteLine($"   Exception Type: {context.Exception?.GetType().Name}");
                if (context.Exception?.InnerException != null)
                {
                    Console.WriteLine($"   Inner Exception: {context.Exception.InnerException.Message}");
                }
                return Task.CompletedTask;
            },

            OnChallenge = context =>
            {
                Console.WriteLine("🟡 [Certificate Auth] Certificate challenge issued");
                Console.WriteLine($"   Scheme: {context.Scheme.Name}");
                Console.WriteLine($"   Properties: {string.Join(", ", context.Properties?.Items.Select(kvp => $"{kvp.Key}={kvp.Value}") ?? Array.Empty<string>())}");
                return Task.CompletedTask;
            },

            OnCertificateValidated = context =>
            {
                Console.WriteLine("🟢 [Certificate Auth] Certificate validation event triggered");
                Console.WriteLine($"   Certificate Subject: {context.ClientCertificate.Subject}");
                Console.WriteLine($"   Certificate Issuer: {context.ClientCertificate.Issuer}");
                Console.WriteLine($"   Certificate Thumbprint: {context.ClientCertificate.Thumbprint}");
                Console.WriteLine($"   Certificate Serial Number: {context.ClientCertificate.SerialNumber}");
                Console.WriteLine($"   Certificate Valid From: {context.ClientCertificate.NotBefore}");
                Console.WriteLine($"   Certificate Valid To: {context.ClientCertificate.NotAfter}");

                // 获取验证服务
                var validationService = context.HttpContext.RequestServices
                    .GetRequiredService<ICertificateValidationService>();

                Console.WriteLine("🔍 [Certificate Auth] Starting custom validation...");

                if (validationService.ValidateCertificate(context.ClientCertificate))
                {
                    Console.WriteLine("✅ [Certificate Auth] Custom validation passed");

                    var claims = new[]
                    {
                        new Claim(
                            ClaimTypes.NameIdentifier,
                            context.ClientCertificate.Subject,
                            ClaimValueTypes.String, context.Options.ClaimsIssuer),
                        new Claim(
                            ClaimTypes.Name,
                            context.ClientCertificate.Subject,
                            ClaimValueTypes.String, context.Options.ClaimsIssuer),
                        new Claim("CertificateThumbprint", context.ClientCertificate.Thumbprint),
                        new Claim("CertificateIssuer", context.ClientCertificate.Issuer)
                    };

                    context.Principal = new ClaimsPrincipal(
                        new ClaimsIdentity(claims, context.Scheme.Name));
                    context.Success();

                    Console.WriteLine("✅ [Certificate Auth] Claims principal created successfully");
                    Console.WriteLine($"   Claims: {string.Join(", ", claims.Select(c => $"{c.Type}={c.Value}"))}");
                }
                else
                {
                    Console.WriteLine("❌ [Certificate Auth] Custom validation failed");
                    context.Fail("Certificate not found in trusted certificates list");
                }

                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Certificate", policy =>
    {
        policy.AddAuthenticationSchemes("Certificate")
        .RequireAuthenticatedUser();
    });
});

// 注册证书验证服务
builder.Services.Configure<List<TrustedCertificate>>(
    builder.Configuration.GetSection("TrustedCertificates"));
builder.Services.AddScoped<ICertificateValidationService, CertificateValidationService>();

builder.Services.AddControllers();
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

// 添加调试端点
app.MapGet("/debug-cert", (HttpContext context) =>
{
    Console.WriteLine("🔍 [Debug] /debug-cert endpoint called");

    var clientCert = context.Connection.ClientCertificate;
    var requestHeaders = context.Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString());

    Console.WriteLine($"   Has Client Certificate: {clientCert != null}");
    if (clientCert != null)
    {
        Console.WriteLine($"   Certificate Subject: {clientCert.Subject}");
        Console.WriteLine($"   Certificate Issuer: {clientCert.Issuer}");
        Console.WriteLine($"   Certificate Thumbprint: {clientCert.Thumbprint}");
    }

    Console.WriteLine($"   User Authenticated: {context.User.Identity?.IsAuthenticated}");
    Console.WriteLine($"   Authentication Type: {context.User.Identity?.AuthenticationType}");

    var result = new
    {
        HasClientCertificate = clientCert != null,
        ClientCertificate = clientCert != null ? new
        {
            Subject = clientCert.Subject,
            Issuer = clientCert.Issuer,
            Thumbprint = clientCert.Thumbprint,
            SerialNumber = clientCert.SerialNumber,
            NotBefore = clientCert.NotBefore,
            NotAfter = clientCert.NotAfter
        } : null,
        UserAuthenticated = context.User.Identity?.IsAuthenticated,
        AuthenticationType = context.User.Identity?.AuthenticationType,
        UserClaims = context.User.Claims.Select(c => new { c.Type, c.Value }).ToList(),
        RequestHeaders = requestHeaders,
        ConnectionInfo = new
        {
            RemoteIpAddress = context.Connection.RemoteIpAddress?.ToString(),
            RemotePort = context.Connection.RemotePort,
            LocalPort = context.Connection.LocalPort
        }
    };

    return Results.Ok(result);
});

app.Run();
