# Intro

IAM = Identity and Access Management, Global service

# Root account

Created by default, should NOT be used or shared

# Users & Groups

**Users** are people within your organization, and can be grouped
**Groups** only contain users, not other groups

# IAM: Permissions

Users or Groups can be assigned JSON documents called policies

```json
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Sid": "1",
      "Effect": "Allow",
      "Action": "ec2:Describe*",
      "Resource": "*"
    },
    {
      "Sid": "1",
      "Effect": "Allow",
      "Action": "elasticloadbalancing:Describe*",
      "Principal": {
        "AWS": ["arn:aws:iam::123456789012:root"]
      },
      "Resource": ["arn:aws:s3:::mybucket/*"]
    },
    {
      "Sid": "1",
      "Effect": "Allow",
      "Action": [
        "cloudwatch:ListMetrics",
        "cloudwatch:GetMetricStatistics",
        "cloudwatch:Describe*"
      ],
      "Resource": "*"
    }
  ]
}
```

These policies define the permissions of the users

In AWS you apply the least privilege principle: Don't give more permissions than a user needs

## IAM Policies Structure

### Consists of

- **Version**: policy language version, always include "2012-10-17"
- **Id**: an identifier for the policy (optional)
- **Statement**: one or more individual statements (required)

### Statements consists of

- **Sid**: an identifier for the statement (optional)
- **Effect**: whether the statement allows or denies access (allow, deny)
- **Principal**: account/user/role to which this policy applied to
- **Action**: list of actions this policy allows or denies
- **Resource**: list of resources to which the actions applied to
- **Condition**: conditions for when this policy is in effect (optional)

# IAM Password Policy

In AWS, you can setup a password policy:

- Set a minimum password length
- Require specific character types:

  - uppercase letters

  - lowercase letters

  - numbers

  - non-alphanumeric characters

- Allow all IAM users to change their own passwords
- Require users to change their password after some time (password expiration)
- Prevent password re-use

# IAM MFA

MFA = password you know + security device you own

## MFA devices options in AWS

- Virtual MFA device

  - Google Authenticator

  - MS Authenticator

  - Authy

- Universal 2nd Factor (U2F) Security Key

  - **YubiKey** by Yubico (3rd party)

- Hardware Key Fob MFA Device

- Hardware Key Fob MFA Device for AWS GovCloud (US)

To setup MFA, click on the user dropdown on the top right, and find `Security Credentials`

# AWS Access

To access AWS, you have 3 options:

- AWS Management Console (protected by password + MFA)
- AWS Command Line Interface (CLI): Protected by access keys
- AWS Software Developer Kit (SDK) - for code: protected by access keys

Access Keys are generated through the AWS Console. Users manage their own access keys

NOTE: Access keys are secret, just like a password. Don't share them.

Access Key ID ~= username
Secret Access Key ~= password

## AWS CLI

https://github.com/aws/aws-cli

# Hands on to create a user

1. Log in to AWS console UI
2. Search "iam" in the service search bar and go to "IAM" service
3. On the left, find and access "Users"
4. Click "Create User"
5. Fill in username, and tick `Provide user access to the AWS Management Console`

   5.1 After ticking `Provide user access to the AWS Management Console`, there will be 2 more options: `Specify a user an Identity Center` and `I want to create an IAM user`. Choose `I want to create an IAM user` for the exam for now.

6. Hit "Next", Click the "Create group" button.

   6.1 Fill in group name, in this case "admin"

   6.2 Tick the `AdministratorAccess` policy

   6.3 Click "Create"

7. Tick the newly created group "admin" and "Next", then create the user
8. Copy the account id from console, then open a new private browser
9. In the AWS login page, select IAM user. Input the account id and the new user credential, the login

Note: The IAM is a global service, the created users here will be available to all regions
