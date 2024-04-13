[back](README.md)

# Global Filter Table of Content

1. [Basic Settings](#basic-setting)
2. [Ignore Query Filter](#ignore-query-filter)

# Official Doc

https://learn.microsoft.com/en-us/ef/core/querying/filters

# Basic Setting

`builder.HasQueryFilter(a => a.IsDeleted == false);`

# Ignore query filter

`ctx.Articles.IgnoreQueryFilters().Where(...)`

# Pitfall

- This may cause performance issue
