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