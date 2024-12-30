- When multiple rules are assigned, rules are evaluated in a sequential order & IAM role for first matching rule is used unless a ‘CustomRoleArn” attribute is added to modify this sequence.

- An S3 bucket with server access logging enabled can accumulate many server log objects over time. Your application might need these access logs for a specific period after creation, and after that, you might want to delete them. You can use Amazon S3 lifecycle configuration to set rules so that Amazon S3 automatically queues these objects for deletion at the end of their life.

- Amazon S3 automatically scales to high request rates. For example, your application can achieve at least 3,500 PUT/POST/DELETE and 5,500 GET requests per second per prefix in a bucket. There are no limits to the number of prefixes in a bucket. It is simple to increase your read or write performance exponentially. For example, if you create 10 prefixes in an Amazon S3 bucket to parallelize reads, you could scale your read performance to 55,000 read requests per second.

# S3 policy that only allows vpc gateway endpoint

```json
{
  "Version": "2012-10-17",
  "Id": "Policy1415115909152",
  "Statement": [
    {
      "Sid": "Access-to-specific-VPCE-only",
      "Principal": "*",
      "Action": "s3:*",
      "Effect": "Deny",
      "Resource": [
        "arn:aws:s3:::YOUR-BUCKET-NAME",
        "arn:aws:s3:::YOUR-BUCKET-NAME/*"
      ],
      "Condition": {
        "StringNotEquals": {
          "aws:sourceVpce": "YOUR-VPCE-ID"
        }
      }
    }
  ]
}
```

**NOTE:** once this is applied, you will no longer be able to access the S3. Run the following command from the instances that connect to the vpc gateway endpoint to remove the policy:
`aws s3 rb s3://<bucketname> --force`
