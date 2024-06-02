# RBAC

https://learn.microsoft.com/en-us/azure/key-vault/general/rbac-guide?tabs=azure-cli

## Funny fact

The owner of the key vault cannot add, update or view secrets

# Hierarchical keys

> Azure Key Vault secret names are limited to alphanumeric characters and dashes. Hierarchical values (configuration sections) use -- (two dashes) as a delimiter, as colons aren't allowed in Key Vault secret names. Colons delimit a section from a subkey in ASP.NET Core configuration. The two-dash sequence is replaced with a colon when the secrets are loaded into the app's configuration.

```bash
az keyvault secret set --vault-name {KEY VAULT NAME} --name "SecretName" --value "secret_value_1_prod"
az keyvault secret set --vault-name {KEY VAULT NAME} --name "Section--SecretName" --value "secret_value_2_prod"
```

# Packages

`Azure.Extensions.AspNetCore.Configuration.Secrets`
Add secrets to config

```c#
builder.Configuration.AddAzureKeyVault(new Uri("Key vault url"), new DefaultAzureCredential());
```

---

`Azure.Security.KeyVault.Secrets`
Dependency Injection `SecretClient`. This will requires `Azure.Identity`

```c#
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddSecretClient(new Uri("Key vault url"));
    clientBuilder.UseCredential(new DefaultAzureCredential());
});

```

# Errors

Local development instance, getting AKV10032

This is cross-tenant issue
