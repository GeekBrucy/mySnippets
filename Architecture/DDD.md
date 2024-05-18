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

## Common Language

Language with precise meanings, free from ambiguity.

## Bounded Context

At high level, it is the environment of the common language

## Entity

Has unique identity

## Value object

- No identity
- Multiple properties

### Example

`Position` object, `Color` object in C#

## Aggregate

Goal: high cohesion, low coupling

## Aggregate Root

There is one entity will act as aggregate root in an aggregation. External and internal access the objects in the aggregation via that entity AKA the aggregate root.

Aggregate root act as a manager in the aggregation

## Aggregation Design

- Make the aggregation as small as possible
- One aggregate root per aggregation
- Entity only has minimum properties

Small aggregation is more micro-service friendly