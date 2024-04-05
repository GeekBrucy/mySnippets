[back](./README.md)

# EF Core Migrations Table of contents

1. [Official Doc](#official-doc)
2. [Migration Up and Down](#migration-up-and-Down)
3. [Remove migration](#remove-migration)
4. [Generate SQL Script](#generate-sql-script)
5. [Caution]()

# Official Doc

https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli

# Migration Up and Down

## Up

Run all migrations:
`dotnet ef database update`

Run specific migration:
`dotnet ef database update [Migration name]`

## Down

`dotnet ef database update [Previous Migration name]`

# Remove migration

Remove last migration
`dotnet ef migrations remove`

# Generate SQL Script

`dotnet ef migrations script -o [file name]`

# Caution

Same migration may not be compatible among the databases. For example, the migrations generated for Sql Server are not compatible to MySql.

## Solution

Use `-o` to output the migration files to different directory. For example, you can generate Sql Server migrations to `migrations/SqlServer` directory, MySql migrations to `migrations/MySql` directory.
