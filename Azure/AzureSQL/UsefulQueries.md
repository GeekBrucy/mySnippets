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

# Create user and assign roles

```sql
CREATE USER [user-name] FROM EXTERNAL PROVIDER;
ALTER ROLE db_datareader ADD MEMBER [user-name];
ALTER ROLE db_datawriter ADD MEMBER [user-name];
ALTER ROLE db_ddladmin ADD MEMBER [user-name];
GO
```

# List roles

```sql
SELECT
    [name] AS [RoleName]
FROM
    [sys].[database_principals]
WHERE
    [type] = 'R'  -- 'R' denotes roles
ORDER BY
    [name];
```
