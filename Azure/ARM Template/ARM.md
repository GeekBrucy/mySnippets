# What if command

```bash
az deployment group what-if --resource-group testrg --name rollout01 --template-uri https://myresource/azuredeploy.json --parameters @myparameters.json
```

# reference() function limitations

Cannot use `reference()` in the following cases:

- Inside resource names
- Inside copy loop count field
- Inside variables or parameters sections
- Nested inside another reference() function
- Inside ARM functions

# Get key from service

Official doc lists the `listXXX()` function for each services
https://learn.microsoft.com/en-us/azure/azure-resource-manager/templates/template-functions-resource#listkeys

## Function app

```
[listKeys(concat(resourceId('Microsoft.Web/sites', variables('function_app_name')), '/host/default'), '2022-09-01').functionKeys.default]
```

To check return value: https://learn.microsoft.com/en-us/rest/api/appservice/web-apps/list-host-keys?view=rest-appservice-2023-12-01

## Search service

Admin Key

```
[listAdminKeys(resourceId('Microsoft.Search/searchServices', variables('search_service_name')), '2022-09-01').primaryKey]
```

To check return value: https://learn.microsoft.com/en-us/rest/api/searchmanagement/admin-keys/get?view=rest-searchmanagement-2023-11-01&tabs=HTTP

Query Key (it is an array)

```
[listQueryKeys(resourceId('Microsoft.Search/searchServices', variables('search_service_name')), '2022-09-01').value[0].key]
```

To check return value: https://learn.microsoft.com/en-us/rest/api/searchmanagement/query-keys/list-by-search-service?view=rest-searchmanagement-2023-11-01&tabs=HTTP
