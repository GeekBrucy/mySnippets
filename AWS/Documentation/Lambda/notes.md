# Function Scaling

Concurrency is the number of in-flight requests that your AWS Lambda function is handling at the same time. For each concurrent request, Lambda provisions a separate instance of your execution environment. As your functions receive more requests, Lambda **automatically** handles scaling the number of execution environments **until** you reach your account's concurrency **limit**. By default, Lambda provides your account with a total concurrency limit of **1,000 concurrent executions** across **all functions** in an AWS **Region**. To support your specific account needs, you can request a quota increase and configure function-level concurrency controls so that your critical functions don't experience throttling.

## Calculating concurrency for a function

`Concurrency = (average requests per second) * (average request duration in seconds)`

## Provisioned Concurrency

This is the number of **pre-initialized** execution environments allocated to your function. These execution environments are ready to respond immediately to incoming function requests. Provisioned concurrency is useful for **reducing cold start** latencies for functions. Configuring provisioned concurrency incurs **additional charges** to your AWS account.

Useful for reducing cold start latencies.

## Reserved concurrency

This represents the **maximum number of concurrent instances** allocated to your function. When a function has reserved concurrency, no other function can use that concurrency. Reserved concurrency is useful for **ensuring** that your most critical functions always have **enough concurrency** to handle incoming requests. Configuring reserved concurrency for a function incurs **no additional charges**.

Useful if you don't want other functions taking up all the available unreserved concurrency.

# Lambda authorizer
for Custom authorization scheme

## Two types of Lambda authorizers

### Token-based Lambda authorizer (TOKEN authorizer)
Receives the caller's identity in a bearer token, such as a JSON Web Token (JWT) or an OAuth token

### Request parameter-based Lambda authorizer (REQUEST authorizer)
Receives the caller's identity in a combination of headers, query string parameters, state variables, and $context variables
