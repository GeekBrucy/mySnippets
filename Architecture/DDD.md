# DDD: Domain Driven Design

## Core Domain

Solve core problem, closely related to business

## Supporting Domain

Solve non-core problem, has organization feature

## Generic Domain

Solve generic problem, no organization feature

### Example: Mobile Phone Company

- Mobile Phone Design: Core Domain
- Mobile Phone Manufacture: Core Domain
- Software Design: Supporting Domain
- Sales: Generic
- Marketing: Generic
- After sales: Generic
- Logistic: Generic
- Human Resource: Generic

### Example: Software Company

- Database: Generic
- OS: Generic
- Devops: Supporting
- Security: Generic
- Data Center: Generic
- Business System Development: Core

## Domain Modeling

1. Start with business logic and identify entities (NOT thinking about tech stack, db table design, etc.)
   1.1 Use business language to describe and construct system. Rather than technical language
   1.2 Avoid transaction scripting and no-design, not-thinking-scalability, not-thinking-maintainability, haphazard programming style
