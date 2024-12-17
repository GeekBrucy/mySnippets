- Allows to grant limited and temporary access to AWS resources (up to 1 hour)
- **AssumeRole**: Assume roles within your account or cross account
- **AssumeRoleWithSAML**: return credentials for users logged with SAML
- **AssumeRoleWithWebIdentity**
  - return creds for users logged with an IdP (Facebook Login, Google Login, OIDC compatible...)
  - AWS recommends against using this, and using Cognito Identity Pools instead
- **GetSessionToken**: for MFA, from a user or AWS account root user
- **GetFederationToken**: obtain temporary creds for a federated user
- **GetCallerIdentity**: return details about the IAM user or role used in the API call
- **DecodeAuthorizationMessage**: decode error message when an AWS API is denied

# Using STS to Assume a Role

- Define an IAM Role within your account or cross-account
- Define which principals can access this IAM Role
- Use AWS STS (Security Token Service) to retrieve credentials and impersonate the IAM Role you have access to (**AssumeRoleAPI**)
- Temporary credentials can be valid between 15 minutes to 1 hour

# STS with MFA

- Use **GetSessionToken** from STS
- Appropriate IAM policy using IAM conditions
- `aws: MultiFactorAuthPresent:true`
- Reminder, GetSessionToken returns:
  - Access ID
  - Secret Key
  - Session Token
