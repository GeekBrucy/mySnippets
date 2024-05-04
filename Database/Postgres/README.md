# Default port

5432

# Default user

postgres

# Create table (UUID as PK and auto generate)

```sql
create table Config (
	Id UUID PRIMARY key not null default gen_random_uuid(),
	Name varchar unique not null,
	Value varchar not null
)
```

# Reset auto increment

```sql
truncate "AspNetUsers" restart identity cascade
```
