using ConfigServices.Interfaces;
using ConfigServices.Services;
using LogServices.Interfaces;
using LogServices.Providers;
using MailServices.Interfaces;
using MailServices.Services;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
  private static void Main(string[] args)
  {
    ServiceCollection services = new ServiceCollection();
    // services.AddScoped<IConfigService, EnvVarConfigService>();
    services.AddScoped<IConfigService>(s => new IniFileConfigService { FilePath = "./ConsoleMailClient/mail.ini" });
    services.AddScoped<IMailService, MailService>();
    services.AddScoped<ILogProvider, ConsoleLogProvider>();
    using var sp = services.BuildServiceProvider();
    var mailService = sp.GetRequiredService<IMailService>();
    mailService.Send("Test", "test@test.gov", "test mail service");
  }
}