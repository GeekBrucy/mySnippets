# Azure SQL

## Tips

###

## Private endpoint

An Azure Private Endpoint is a network interface that connects your virtual network privately to a service powered by Azure Private Link. This allows you to access Azure services over an Azure Private Link, which is a private endpoint in your virtual network. This means that traffic between your virtual network and the service traverses over the Microsoft Azure backbone network, eliminating exposure from the public internet.

## Managed Identity Connection string

https://learn.microsoft.com/en-us/azure/app-service/tutorial-connect-msi-sql-database?tabs=vscode%2Cefcore%2Cdotnet

### TLDR

Replace the connection string with:

`"Server=tcp:<server-name>.database.windows.net;Authentication=Active Directory Default; Database=<database-name>;"`

## Connect Azure Web App to Azure SQL

0. Provision Azure web app service and Azure SQL

   0.1 Deploy a solution to Azure Web app service that performs simple CRUD to the Azure SQL

### Networking

1. Create a `Virtual Network` service (Not `Virtual Network Gateway`) with default setup
2. Create 1 subnet for web app service. Default setup will do
3. (optional) Create 1 subnet for Azure SQL. If you want to use the default subnet, then this is not needed
4. Go to SQL Server service -> Networking -> Private access -> Create a private endpoint. All with default setup, just need to select the created VNet and subnet. This step will provision 3 resources: Private endpoint, Network Interface and Private DNS Zone
5. Go to SQL Server service -> Networking -> Public access -> Disable (Disable for now, will re-enable for local dev) -> Untick `Allow Azure services and resources to access this server` (ticking this will cause security issue, because it allows ALL resources on Azure, yes, including strangers)
6. Go to App Service -> Networking -> Virtual network integration -> select the available subnet. (you won't be able to select the same one as SQL server)
7. Test Remote: Send request to App service, it should still be able to get data from SQL
8. Test Local: Spin up a local instance and send request to the app, you should find you will get connection exception. Then add your ip address to SQL Server firewall rules. Send the request again, you should then get the data from the DB

### Managed Identity

1. Go to App Service -> Identity -> System assigned -> switch the toggle to `On` -> Save
2. Go to SQL Server -> Microsoft Entra ID -> Set Admin (you cannot set yourself as Admin)
3. Admin Go to the SQL Database -> Query Editor -> use Microsoft Entra authentication -> Run the following command

```SQL
CREATE USER [<identity-name>] FROM EXTERNAL PROVIDER;
ALTER ROLE db_datareader ADD MEMBER [<identity-name>];
ALTER ROLE db_datawriter ADD MEMBER [<identity-name>];
ALTER ROLE db_ddladmin ADD MEMBER [<identity-name>];
GO
```

4. Go back to App Service -> Change the connection string to the following (change local to the same connection string)
   `Server=tcp:<server-name>.database.windows.net;Authentication=Active Directory Default; Database=<database-name>;`
5. Test remote: Send request to App service, it should still be able to get data from SQL
6. Test local:
   6.1 For VS Code + command line: run `az login` in the command line, then spin up a local instance, you should get the data after sending a request
   6.2 For VS Code and run project in VS Code: Install Azure extension and login

#### Managed Identity Issues

- Login failed for user '<token-identified principal>'. The server is not currently configured to accept this token

  ~~Tried to run `CREATE USER [user email] FROM EXTERNAL PROVIDER;` in the database, but got this error: `Failed to execute query. Error: Server identity does not have Azure Active Directory Readers permission. Please follow the steps here : https://docs.microsoft.com/azure/azure-sql/database/authentication-aad-service-principal`~~

  ~~Relevant docs:~~
  ~~https://learn.microsoft.com/en-us/answers/questions/1161482/login-creation-failed-while-using-service-principa provides this doc:~~
  ~~https://learn.microsoft.com/en-us/azure/azure-sql/database/authentication-azure-ad-user-assigned-managed-identity?view=azuresql#grant-permissions~~

  Solution:
  After `az login`, run `az account set --subscription {target subscription}`

- Invalid value for key 'authentication'.
  This might just be old version of ef core and sql driver
