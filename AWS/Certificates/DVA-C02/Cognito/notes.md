- Amazon Cognito identity pools support both authenticated and unauthenticated identities. Authenticated identities belong to users who are authenticated by any supported identity provider. Unauthenticated identities typically belong to guest users.

- Amazon Cognito Sync is an AWS service and client library that enable cross-device syncing of application-related user data. You can use it to synchronize user profile data across mobile devices and web applications. The client libraries cache data locally so your app can read and write data regardless of device connectivity status. When the device is online, you can synchronize data, and if you set up push sync, notify other devices immediately that an update is available.

# User Pools:

- Sign in functionality for app users
- Integrate with API Gateway & Application Load Balancer

## Integration

- API Gateway
- ALB

# Identity Pools (Federated Identity):

- Provide AWS credentials to users so they can access AWS resource directly
- Integrate with Cognito User Pools as an identity provider

# Host Cognito UI on Custom Domain

- MUST create an ACM certificate in **us-east-1**
- Custom domain must be defined in the "App Integration" section

# Adaptive Authentication

- Block sign-ins or require MFA if the login appears suspicious
- Cognito examines each sign-in attempt and generates a risk score (low, medium, high) for how likely the sign-in request is to be from a malicious attacker
- Users are prompted for a second MFA only when risk is detected
- Risk score is based on different factors such as if the user has used the same device, location, or IP address
- Checks for compromised credentials, account takeover protection, and phone and email verification
- Integration with CloudWatch Logs (sign-in attempts, risk score, failed challenges...)

# User Pools vs Identity Pools

## User Pools (for authentication = identity verification)

- Database of users for your web and mobile app
- Allows to federate logins through Public Social, OIDC, SAML...
- Can customize the hosted UI for authentication (including the logo)
- Has triggers with AWS Lambda during the authentication flow
- Adapt the sign-in experience to different risk levels (MFA, adaptive authentication, etc...)

## Cognito Identity Pools (for authorization = access control)

- Obtain AWS credentials for your users
- Users can login through Public Social, OIDC, SAML & Cognito User Pools
- Users can be unauthenticated (guests)
- Users are mapped to IAM roles & policies, can leverage policy variables
