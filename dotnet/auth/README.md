# Dotnet auth tute

[Official Doc - Create Starter App](https://learn.microsoft.com/en-us/aspnet/core/security/authorization/secure-data?view=aspnetcore-8.0#create-the-starter-app)

# Step 1

Run `dotnet new webapp -o ContactManager -au Individual`

- -au: The type of authentication to use
- -uld: Whether to use LocalDB instead of SQLite (this may not be needed)

# Step 2

Run `dotnet new gitignore` to avoid committing useless stuff

# Step 3

Create Contact Model

# Step 4

Create initial migration and update the databsae

```bash
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet tool install -g dotnet-aspnet-codegenerator
dotnet-aspnet-codegenerator razorpage -m Contact -udl -dc ApplicationDbContext -outDir Pages\Contacts --referenceScriptLibraries -sqlite
dotnet ef database drop -f
dotnet ef migrations add initial
dotnet ef database update
```

# Useful links
https://learn.microsoft.com/en-us/aspnet/core/security/authentication/configure-oidc-web-authentication?view=aspnetcore-9.0
https://learn.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-9.0#authentication-handler
https://learn.microsoft.com/en-us/aspnet/core/blazor/security/blazor-web-app-with-oidc?view=aspnetcore-9.0&pivots=without-bff-pattern

## AWS cognito old doc
https://github.com/aws-samples/aws-netcore-aspnetmvc-amazon-cognito-authentication-authorization-samples