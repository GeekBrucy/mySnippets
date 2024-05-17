# Restrict access to a specific Azure Front Door instance

Traffic from Azure Front Door to your application originates from a well known set of IP ranges defined in the AzureFrontDoor.Backend service tag. Using a service tag restriction rule, you can restrict traffic to only originate from Azure Front Door. To ensure traffic only originates from your specific instance, you need to further filter the incoming requests based on the unique http header that Azure Front Door sends.

NOTE: This seems not working when the front door is on top of an SPA app (angular etc.)

## ARM template

```json
{
  "ipSecurityRestrictions": [
    {
      "ipAddress": "AzureFrontDoor.Backend",
      "action": "Allow",
      "tag": "ServiceTag",
      "priority": 100,
      "name": "Front Door Access Only",
      "description": "Rule to allow front door access",
      "headers": {
        "x-azure-fdid": ["[parameters('frontDoorID')]"]
      }
    },
    {
      "ipAddress": "Any",
      "action": "Deny",
      "priority": 2147483647,
      "name": "Deny all",
      "description": "Deny all access"
    }
  ]
}
```
