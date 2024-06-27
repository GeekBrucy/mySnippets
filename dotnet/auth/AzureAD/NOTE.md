# App Registration

The `AzureADWebAPI` is connected with app registration `azure-ad-dotnet-core-practice`

## Official doc

https://learn.microsoft.com/en-us/entra/identity-platform/tutorial-web-app-dotnet-prepare-app?tabs=visual-studio-code

# FAQ

- What are `Access tokens (used for implicit flows)` and `ID tokens (used for implicit and hybrid flows)` on Authentication page in an App Registration?

- What is the `Consent on behalf of your organization` when first time connecting to the app registration?

Consent is the process of a user granting authorization to an application to access protected resources on their behalf. An admin or user can be asked for consent to allow access to their organization/individual data.

- What is the consent for in the add scope page?

- What is the scope / API permissions?

# Handy commands

## Create dotnet project with auth template:

`dotnet new webapp -o YourAppName --auth SingleOrg`

# Authenticate with OAuth 2.0 Authentication in Postman

1. Select OAuth 2.0 in Postman
2. In Configure New Token

   2.1 Select `Authorization Code` for Grant Type

   2.2 Check `Authorize using browser`

   2.3 Enter `https://login.microsoftonline.com/{tenant id}/oauth2/v2.0/authorize` for Auth URL (can find it from app registration -> Overview -> Endpoints)

   2.4 Enter `https://login.microsoftonline.com/{tenant id}/oauth2/v2.0/token` for access token URL (can find it from app registration -> Overview -> Endpoints)

   2.5 Client ID for Client ID

   2.6 Client Secret Value for Client Secret

   2.7 `api://xxxxxx` to Scope (Can generate from Expose an API)
