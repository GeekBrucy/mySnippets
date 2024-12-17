# CDK

- Compile the code into CloudFormation template (JSON/YAML)

# CDK vs SAM

## SAM

- Serverless focused
- Write template declaratively in JSON or YAML
- Great for quickly getting started with Lambda
- Leverages CloudFormation

## CDK

- All AWS services
- Write infra in a programming language JS/TS, python, java and dotnet
- Leverage CloudFormation

# CDK + SAM

- use SAM CLI to locally test the CDK apps
- Must first run cdk synth

# Useful Commands

`npm install -g aws-cdk-lib`: install the CDK CLI and libraries
`cdk init app`: create a new CDK project from a specified template
`cdk synth`: Synthesizes and prints the CloudFormation template
`cdk bootstrap`: Deploys the CDK Toolkit staging Stack
`cdk deploy`: Deploy the Stack(s)
`cdk diff`: View differences of local CDK and deployed Stack
`cdk destroy`: Destroy the Stack(s)

# TODO:

Hands on to do CDK
