- Using CloudWatch Events, you can monitor the progress of jobs, build AWS Batch custom workflows with complex dependencies, generate usage reports or metrics around job execution, or build your own custom dashboards. With AWS Batch and CloudWatch Events, you can eliminate scheduling and monitoring code that continuously polls AWS Batch for job status changes. Instead, handle AWS Batch job state changes asynchronously using any CloudWatch Events target, such as AWS Lambda, Amazon Simple Queue Service, Amazon Simple Notification Service, or Amazon Kinesis Data Streams.

# Encryption

- You can encrypt CloudWatch logs with KMS keys
- Encryption is enabled at the log group level, by associating a CMK with a log group, either when you create the log group or after it exists
- You **cannot** associate a CMK with a log group using the CloudWatch console.
- You must use the CloudWatch Logs API:
  - associate-kms-key: if the log group already exists
  - create-log-group: if the log group doesn't exist yet

# CloudWatch Evidently

- Safely validate new features by serving them to a specified % of your users
  - Reduce risk and identify unintended consequences
  - Collect experiment data, analyze using stats, monitor performance
- Launches (=feature flags): enable and disable features for a subset of users
- Experiments (= A/B testing): compare multiple versions of the same feature
- Overrides: pre-define a variation for a specific user
- Store evaluation events in CloudWatch Logs or S3
