- By default, an alias points to a single Lambda function version. When the alias is updated to point to a different function version, incoming request traffic in turn instantly points to the updated version. This exposes that alias to any potential instabilities introduced by the new version. To minimize this impact, you can implement the routing-config parameter of the Lambda alias that allows you to point to two different versions of the Lambda function and dictate what percentage of incoming traffic is sent to each version.

- Avoid using recursive code in your Lambda function, wherein the function automatically calls itself until some arbitrary criteria is met. This could lead to unintended volume of function invocations and escalated costs. If you do accidentally do so, set the function concurrent execution limit to 0 immediately to throttle all invocations to the function, while you update the code..

- Environment variables for Lambda functions enable you to dynamically pass settings to your function code and libraries, without making changes to your code. Environment variables are key-value pairs that you create and modify as part of your function configuration, using either the AWS Lambda Console, the AWS Lambda CLI or the AWS Lambda SDK. AWS Lambda then makes these key value pairs available to your Lambda function code using standard APIs supported by the language, like process.env for Node.js functions.

- If your Lambda function code is executing, but you don’t see any log data being generated after several minutes, this could mean your execution role for the Lambda function did not grant permissions to write log data to CloudWatch Logs. For information about how to make sure that you have set up the execution role correctly to grant these permissions, see Manage Permissions: Using an IAM Role (Execution Role)

- Any Lambda function invoked asynchronously is retried twice before the event is discarded. If the retries fail and you’re unsure why, use Dead Letter Queues (DLQ) to direct unprocessed events to an Amazon SQS queue or an Amazon SNS topic to analyze the failure.

- Minimize your deployment package size to its runtime necessities. This will reduce the amount of time that it takes for your deployment package to be downloaded and unpacked ahead of invocation. For functions authored in Java or .NET Core, avoid uploading the entire AWS SDK library as part of your deployment package. Instead, selectively depend on the modules which pick up components of the SDK you need

- You can insert logging statements into your code to help you validate that your code is working as expected. Lambda automatically integrates with Amazon CloudWatch Logs and pushes all logs from your code to a CloudWatch Logs group associated with a Lambda function (/aws/lambda/).

- To resolve “LambdaThrottledException” error while using Amazon Cognito Events, you need to perform retry on sync operations while writing Lambda function.

- If the lambda function was created with the default settings , it would have the default timeout of 3 seconds

- For errors such as “ServiceException”, best practice is to Retry invoking Lambda function. Within a Retry Code “ErrorEquals” field is required string which matches error names & all other fields are optional.

- Lambda Catch code is only used after a number of retries are performed by State function.

- BackoffRate field is optional in Lambda Retry code & if not specified Default value of 2.0 is considered.

- Lambda Catch code is only used after a number of retries are performed by State function. ResultPath is an optional field in a Catch Code, ErrorEquals & Next are required strings.

- If you are writing code that uses other resources, such as a graphics library for image processing, or you want to use the AWS CLI instead of the console, you need to first create the Lambda function deployment package, and then use the console or the CLI to upload the package.

- Take advantage of Execution Context reuse to improve the performance of your function. Make sure any externalized configuration or dependencies that your code retrieves are stored and referenced locally after initial execution. Limit the re-initialization of variables/objects on every invocation. Instead use static initialization/constructor, global/static variables and singletons. Keep alive and reuse connections (HTTP, database, etc.) that were established during a previous invocation.

- Integration Type “Aws_Proxy” can be used for an API method to be integrated with the Lambda Function where incoming requests from the clients is passed as input to Lambda Function.

- AWS Lambda uses environment variables to facilitate communication with the X-Ray daemon and configure the X-Ray SDK.

  - \_X_AMZN_TRACE_ID: Contains the tracing header, which includes the sampling decision, trace ID, and parent segment ID. If Lambda receives a tracing header when your function is invoked, that header will be used to populate the \_X_AMZN_TRACE_ID environment variable. If a tracing header was not received, Lambda will generate one for you.
  - AWS_XRAY_CONTEXT_MISSING: The X-Ray SDK uses this variable to determine its behavior in the event that your function tries to record X-Ray data, but a tracing header is not available. Lambda sets this value to LOG_ERROR by default.
  - AWS_XRAY_DAEMON_ADDRESS: This environment variable exposes the X-Ray daemon’s address in the following format: IP_ADDRESS:PORT. You can use the X-Ray daemon’s address to send trace data to the X-Ray daemon directly, without using the X-Ray SDK.

- With the Lambda proxy integration, Lambda is required to return an output of the following format … In this output, statusCode is typically 4XX for a client error and 5XX for a server error. API Gateway handles these errors by mapping the Lambda error to an HTTP error response, according to the specified statusCode. For API Gateway to pass the error type (for example, InvalidParameterException), as part of the response to the client, the Lambda function must include a header (for example, “X-Amzn-ErrorType“:“InvalidParameterException“) in the headers property.

- You can assign an alias to a specific version and link the S3 trigger to that alias. If you want to change the version of the Lambda triggered by S3, you just need to edit the alias

- Lambda@Edge functions can only be created and deployed in the us-east-1 (N. Virginia) Region
