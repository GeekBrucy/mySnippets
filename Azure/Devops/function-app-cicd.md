# Bind Env Var
```yml
trigger:
- main

pool:
  vmImage: 'windows-latest'

variables:
  azureSubscription: '<your-azure-service-connection>'
  functionAppName: '<your-function-app-name>'
  resourceGroupName: '<your-resource-group>'
  buildConfiguration: 'Release'

steps:
- task: UseDotNet@2
  inputs:
    packageType: 'sdk'
    version: '6.x'
    installationPath: $(Agent.ToolsDirectory)/dotnet

- task: NuGetCommand@2
  inputs:
    restoreSolution: '**/*.sln'

- task: DotNetCoreCLI@2
  inputs:
    command: 'build'
    projects: '**/*.csproj'
    arguments: '--configuration $(buildConfiguration)'

- task: DotNetCoreCLI@2
  inputs:
    command: 'publish'
    projects: '**/*.csproj'
    arguments: '--configuration $(buildConfiguration) --output $(Build.ArtifactStagingDirectory)'
    zipAfterPublish: true

- task: AzureFunctionApp@2
  inputs:
    azureSubscription: '$(azureSubscription)'
    appType: 'functionApp'
    appName: '$(functionAppName)'
    package: '$(Build.ArtifactStagingDirectory)/**/*.zip'
    resourceGroupName: '$(resourceGroupName)'
    appSettings: |
      [
        {
          "name": "Port",
          "value": "5000",
          "slotSetting": false
        },
        {
          "name": "RequestTimeout",
          "value": "5000",
          "slotSetting": false
        },
        {
          "name": "WEBSITE_TIME_ZONE",
          "value": "Eastern Standard Time",
          "slotSetting": false
        }
      ]
```

The above is equivalent to `local.settings.json`
```json
{
  "IsEncrypted": false,
  "Values": {
    "Port": "5000",
    "RequestTimeout": "5000",
    "WEBSITE_TIME_ZONE": "Eastern Standard Time"
  }
}
```

Here is how to access the values:
```c#
string port = Environment.GetEnvironmentVariable("Port");
string requestTimeout = Environment.GetEnvironmentVariable("RequestTimeout");
string timeZone = Environment.GetEnvironmentVariable("WEBSITE_TIME_ZONE");
```

NOTE: The storage account binding is not done at code deployment, it is done at resource deployment

# Deploy Function App in ARM/Bicep

## ARM
```json
{
  "type": "Microsoft.Web/sites",
  "apiVersion": "2022-03-01",
  "name": "[parameters('functionAppName')]",
  "location": "[parameters('location')]",
  "properties": {
    "siteConfig": {
      "appSettings": [
        {
          "name": "AzureWebJobsStorage",
          "value": "[concat('DefaultEndpointsProtocol=https;AccountName=', parameters('storageAccountName'), ';AccountKey=', listKeys(resourceId('Microsoft.Storage/storageAccounts', parameters('storageAccountName')), ';EndpointSuffix=core.windows.net')]"
        },
        {
          "name": "FUNCTIONS_WORKER_RUNTIME",
          "value": "dotnet"
        }
      ]
    },
    "clientAffinityEnabled": false,
    "reserved": true
  },
  "dependsOn": [
    "[resourceId('Microsoft.Storage/storageAccounts', parameters('storageAccountName'))]"
  ]
}
```
## Bicep
```bicep
resource functionApp 'Microsoft.Web/sites@2022-03-01' = {
  name: functionAppName
  location: location
  properties: {
    siteConfig: {
      appSettings: [
        {
          name: 'AzureWebJobsStorage'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccount.name};AccountKey=${storageAccount.listKeys().keys[0].value};EndpointSuffix=core.windows.net'
        }
        {
          name: 'FUNCTIONS_WORKER_RUNTIME'
          value: 'dotnet'
        }
      ]
    }
    clientAffinityEnabled: false
    reserved: true
  }
  dependsOn: [
    storageAccount
  ]
}

resource storageAccount 'Microsoft.Storage/storageAccounts@2023-01-01' = {
  name: storageAccountName
  location: location
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {}
}
```

## CLI
```bash
az functionapp config appsettings set \
  --name <your-function-app-name> \
  --resource-group <your-resource-group> \
  --settings "AzureWebJobsStorage=<your-storage-connection-string>"
```

# **Best Practices**

1. **Use Managed Identity for Storage Accounts**:
    
    - Instead of using a connection string, consider using a **managed identity** for secure access to the storage account. This avoids storing sensitive connection strings in app settings.
        
    - Grant the Function App's managed identity the `Storage Blob Data Contributor` role on the storage account.
        
2. **Avoid Hardcoding Connection Strings**:
    
    - Use **Azure Key Vault** to store and retrieve the storage account connection string securely.
        
    - Reference the Key Vault secret in your ARM/Bicep template or app settings.
        
3. **Separate Infrastructure and Deployment**:
    
    - Use ARM/Bicep for infrastructure provisioning (e.g., creating the Function App and storage account).
        
    - Use Azure DevOps pipelines for deploying the Function App code.

## **Example: Using Azure Key Vault for Storage Connection String**

If you're using Azure Key Vault, you can reference the secret in your ARM/Bicep template or app settings:

#### ARM Template:
```json
{
  "type": "Microsoft.Web/sites",
  "apiVersion": "2022-03-01",
  "name": "[parameters('functionAppName')]",
  "location": "[parameters('location')]",
  "properties": {
    "siteConfig": {
      "appSettings": [
        {
          "name": "AzureWebJobsStorage",
          "value": "[reference(resourceId('Microsoft.KeyVault/vaults/secrets', parameters('keyVaultName'), parameters('storageConnectionStringSecretName'))).secretUriWithVersion]"
        }
      ]
    }
  }
}
```

#### Bicep Template:

```bicep
resource functionApp 'Microsoft.Web/sites@2022-03-01' = {
  name: functionAppName
  location: location
  properties: {
    siteConfig: {
      appSettings: [
        {
          name: 'AzureWebJobsStorage'
          value: '${keyVault.getSecret('storageConnectionStringSecretName')}'
        }
      ]
    }
  }
}
```

## Leverage Managed Identity
```bicep
resource functionApp 'Microsoft.Web/sites@2022-03-01' = {
  name: functionAppName
  location: location
  properties: {
    siteConfig: {
      appSettings: [
        {
          name: 'AzureWebJobsStorage__accountName'
          value: '<your-storage-account-name>'
        }
      ]
    }
  }
}
```
To specify which storage account to use, the settings above can help.