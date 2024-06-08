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
