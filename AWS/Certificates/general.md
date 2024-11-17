# Security

## IAM

### IAM Security Tools

#### IAM Credentials Report (account-level)

- A report that lists all your account's users and the status of their various credentials

#### IAM Access Advisor (user-level) - This is renamed "Last Access" in a user view

- Access advisor shows the service permissions granted to a user and when those services were last accessed.

- You can use this information to revise your policies

# Best Practices

## IAM

- Do NOT use the root account except for AWS account setup
- One physical user = One AWS user
- Assign users to groups and assign permissions to groups
- Create a strong password policy
- Use and enforce the use of Multi Factor Authentication (MFA)
- Create and use Roles for giving permissions to AWS services
- Use Access Keys for Programmatic Access (CLI / SDK)
- Audit permissions of your account using IAM Credentials Report & IAM Access Advisor
- Never share IAM users & Access Keys
