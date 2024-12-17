- Capability to force rotation of secrets every X days
- Automate generation of secrets on rotation (uses Lambda)
- Integration with RDS (MySQL, PostgreSQL, Aurora)
- Secrets are encrypted using KMS
- Mostly meant for RDS integration

# Multi-Region Secrets

- Replicate Secrets across multiple AWS regions
- Secrets Manager keeps read replicas in sync with the primary secret
- Ability to promote a read replica secret to a standalone secret
- Uses cases: multi-region apps, disaster recovery strategies, multi-region DB...
