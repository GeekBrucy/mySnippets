# Query user roles

```sql
SELECT
    [U].[name] AS [UserName],
    [R].[name] AS [RoleName]
FROM
    [sys].[database_principals] AS [U]
JOIN
    [sys].[database_role_members] AS [RM] ON [U].[principal_id] = [RM].[member_principal_id]
JOIN
    [sys].[database_principals] AS [R] ON [RM].[role_principal_id] = [R].[principal_id]
;
```
