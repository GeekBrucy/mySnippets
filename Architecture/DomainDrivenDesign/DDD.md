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

## Entity Code

- Entity creation
- Entity state
- ...

## Domain Service (biggest module)

Contains business logics of aggregation

## Application Service

Contains the logics that across multiple aggregation and systems outside of aggregation

## Responsibilities

- Domain model will not directly interact with external systems (Domain service will not involve database operations)
- Domain service contains business logic
- Application service will interact with external systems
- Domain service is not 100% necessary, like simple CRUD. In this case, application service is responsible for everything.

## Repository

- fetch data
- save data

## Unit of Work

- Multiple related operations in an aggregation is called unit of work.
- All succeed or all fail

## Domain Event

## Integration Event

## Anemic Domain Model (贫血模型)

- A class only has properties or fields, no methods

## Rich Domain Model (充血模型)

- A class has properties, fields and methods

### EF Core Rich Domain Model Features

- Some properties may be readonly or only can be modified internally
- Define constructor that requires arguments
- Need to map private fields that don't have corresponding properties to the database
- Some properties don't need to be saved to database

#### Some Tips

- If in a model, all constructors have arguments and you need EF Core to initialize the properties from arguments value, the arguments name MUST be the same as the properties
- You can also define a private constructor that has no argument, this will be only for EF
- Map private field to column: `builder.Property("Your_Private_Field_Name")`
- For readonly property, EF has a feature called "backing field". In model config, use `HasField("readonly_field_Name")`

# DDD Classic Use Case Process

1. Prepare business logic data

```c#
Person p = new Person();
p.Init() // some init code
ctx.Persons.Add(p);
```

2. Execute one or more operations that alter the entity state

```c#
p.Age++;
```

3. Apply the changes to external system

```c#
ctx.SaveChanges();
```
