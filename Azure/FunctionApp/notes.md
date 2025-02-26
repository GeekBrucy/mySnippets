# Key Vault Dependency Injection with Autofac in .NET Core 3.1

To use **dependency injection (DI)** with Key Vault in a .NET Core 3.1 Function App, you can configure Autofac to resolve the `SecretClient` or other Key Vault-related services. Here’s how:

---
## **Step 1: Install Required Packages**
Install the following NuGet packages:
- `Azure.Identity`
- `Azure.Security.KeyVault.Secrets`
- `Autofac`
- `Microsoft.Azure.Functions.Extensions` (for Functions startup configuration)

```bash
dotnet add package Azure.Identity
dotnet add package Azure.Security.KeyVault.Secrets
dotnet add package Autofac
dotnet add package Microsoft.Azure.Functions.Extensions
```

---
## **Step 2: Create a Startup Class** (optional, this is for default DI)
Create a `Startup` class register the `SecretClient`.

```csharp
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Autofac;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

[assembly: FunctionsStartup(typeof(MyFunctionApp.Startup))]

namespace MyFunctionApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Register Autofac
            builder.Services.AddAutofac();

            // Register Key Vault services
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            string keyVaultUri = config["KeyVaultUri"];

            builder.Services.AddSingleton(sp =>
            {
                return new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());
            });
        }
    }
}
```

---
## **Step 3: Configure Autofac Container**
Configure the Autofac container in the `Startup` class.

```csharp
using Autofac;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        // Register Autofac
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterModule(new MyModule());
        containerBuilder.Populate(builder.Services);
        var container = containerBuilder.Build();
        builder.Services.Replace(ServiceDescriptor.Singleton(typeof(IServiceProviderFactory<ContainerBuilder>), new AutofacServiceProviderFactory(containerBuilder));
    }
}

public class MyModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // Register Key Vault services
        builder.Register(c =>
        {
            var config = c.Resolve<IConfiguration>();
            string keyVaultUri = config["KeyVaultUri"];
            return new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());
        }).As<SecretClient>().SingleInstance();
    }
}
```

---

## **Step 4: Use Dependency Injection in Your Function**
Inject the `SecretClient` into your function class.

```csharp
using Azure.Security.KeyVault.Secrets;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

public class MyFunction
{
    private readonly SecretClient _secretClient;

    public MyFunction(SecretClient secretClient)
    {
        _secretClient = secretClient;
    }

    [FunctionName("MyFunction")]
    public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer, ILogger log)
    {
        string secretName = "AzureWebJobsStorage";
        KeyVaultSecret secret = _secretClient.GetSecret(secretName);
        string storageConnectionString = secret.Value;

        log.LogInformation($"Storage connection string: {storageConnectionString}");
    }
}
```

---

## **Step 5: Configure `local.settings.json`**
Add the Key Vault URI to your `local.settings.json`:

```json
{
  "IsEncrypted": false,
  "Values": {
    "KeyVaultUri": "https://<your-key-vault-name>.vault.azure.net/",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet"
  }
}
```

---

### **Key Points**
- **Key Vault References**: If you’re only using Key Vault for the storage account connection string, you can use Key Vault references in your Function App configuration instead of writing code.
- **Dependency Injection**: Use Autofac to inject the `SecretClient` into your functions.
- **Local Development**: Use `local.settings.json` to store the Key Vault URI and other settings.

---

### **Example: Key Vault References (No Code Changes)**
If you want to avoid writing code to fetch secrets, you can use **Key Vault references** in your Function App configuration:

#### **In Azure Portal**:
1. Go to your Function App’s **Configuration**.
2. Add a new app setting:
   - Name: `AzureWebJobsStorage`
   - Value: `@Microsoft.KeyVault(SecretUri=https://<your-key-vault-name>.vault.azure.net/secrets/<secret-name>/)`

#### **In `local.settings.json`**:
For local development, you can still use the connection string directly:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "<your-storage-connection-string>",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet"
  }
}
```

# Integrating Azure Key Vault with an Azure Function App
## Step 1: Install Required NuGet Packages
```sh
dotnet add package Azure.Extensions.AspNetCore.Configuration.Secrets
dotnet add package Azure.Identity
```
## Step 2: Register Azure Key Vault in Startup.cs
```c#
using System;
using Azure.Identity;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(MyNamespace.Startup))]

namespace MyNamespace
{
    public class Startup : FunctionsStartup
    {
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            var config = builder.ConfigurationBuilder.Build();

            string keyVaultUri = config["AzureKeyVaultUri"];  // Example: "https://myvault.vault.azure.net/"

            if (!string.IsNullOrEmpty(keyVaultUri))
            {
                builder.ConfigurationBuilder.AddAzureKeyVault(
                    new Uri(keyVaultUri),
                    new DefaultAzureCredential()
                );
            }
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Additional dependency injection if needed
        }
    }
}
```