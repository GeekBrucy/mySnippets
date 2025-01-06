- For cross-account access, imagine that you own multiple accounts and need to access resources in each account. You could create long-term credentials in each account to access those resources. However, managing all those credentials and remembering which one can access which account can be time consuming. Instead, you can create one set of long-term credentials in one account and then use temporary security credentials to access all the other accounts by assuming roles in those accounts.

- The credentials file takes precedence over the IAM role

- additional step is needed to assign an AWS role and its associated permissions to an EC2 instance and make them available to its applications. This extra step is the creation of an instance profile that is attached to the instance

- [Versioning IAM policies](https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies_managed-versioning.html)

# Authorization Model Evaluation of Policies (simplified)

1. If there's an explicit DENY, end decision and DENY
2. If there's an ALLOW end decision with ALLOW
3. Else DENY

# IAM Policies & S3 Bucket Policies

- IAM Policies are attached to users, roles, groups
- S3 Bucket Policies are attached to buckets
- When evaluating if an IAM Principal can perform an operation X on a bucket, the union of its assigned IAM Policies and S3 Bucket Policies will be evaluated.

## IAM Policy + S3 Bucket Policy = Total Policy Evaluated

# Dynamic Policy example

```json
{
  "Sid": "AllowAllS3ActionsInUserFolder",
  "Action": ["s3:*"],
  "Effect": "Allow",
  "Resource": ["arn:aws:s3:::my-company/home/${aws:username}/*"]
}
```

# Inline vs Managed Policies

- AWS Managed Policy
  - Maintained by AWS
  - Good for power users and administrators
  - Updated in case of new services / new APIs
- Customer Managed Policy
  - Best Practice, re-usable, can be applied to many principals
  - Version controlled + rollback, central change management
- Inline
  - Strict one-to-one relationship between policy and principal
  - Policy is deleted if you delete the IAM principal

# IAM PassRole

## Trust allows
