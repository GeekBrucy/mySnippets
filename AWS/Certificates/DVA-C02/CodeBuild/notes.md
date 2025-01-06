- Typically, resources in an VPC are not accessible by AWS CodeBuild. To enable access, you must provide **additional VPC-specific configuration information** as part of your AWS CodeBuild project configuration. This includes the **VPC ID**, the VPC **subnet IDs**, and the **VPC security group IDs**. VPC-enabled builds are then able to access resources inside your VPC.

- VPC connectivity from AWS CodeBuild builds makes it possible to:
  - Run integration tests from your build against data in an Amazon RDS database that’s isolated on a private subnet.
  - Query data in an Amazon ElastiCache cluster directly from tests.
  - Interact with internal web services hosted on Amazon EC2, Amazon ECS, or services that use internal Elastic Load Balancing.

# Security

- To access resources in your VPC, make sure you specify a VPC configuration for your CodeBuild
- Secrets in CodeBuild: (DO NOT store them as plaintext in environment variables)
  - Environment variables can reference parameter store parameters
  - Environment variables can reference secrets manager secrets
