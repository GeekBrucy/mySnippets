# Overview

A framework specifically designed for building and deploying serverless applications

# commands

`sam package`

`sam deploy` - Package & Deploy

`sam sync --watch` - Quickly sync local changes to AWS Lambda (SAM Accelerate)

- SAM Accelerate
  - a set of features to reduce latency while deploying resources to AWS
  - sam sync
    - Synchronizes your project declared in SAM templates to AWS
    - Synchronizes code changes to AWS without updating infrastructure (uses service APIs & bypass CloudFormation)
  - sam sync (no options)
    - Synchronize code and infrastructure
  - sam sync --code
    - Synchronize code changes without updating infrastructure (bypass CloudFormation, update in seconds)
  - sam sync --code --resource AWS::Serverless::Function
    - Synchronize only all lambda functions and their dependencies
  - sam sync --code --resource-id HelloWorldLambdaFunction
    - Synchronize only a specific resource by its ID
  - sam sync --watch
    - Monitor for file changes and automatically synchronize when changes are detected
    - If changes include configuration, it uses `sam sync`
    - If changes are code only, it uses `sam sync --code`

# SAM policy list

https://docs.aws.amazon.com/serverless-application-model/latest/developerguide/serverless-policy-template-list.html
