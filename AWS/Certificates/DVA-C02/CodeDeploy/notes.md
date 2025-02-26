- You need to specify the –with-decryption option, this allows the CodeDeploy service to decrypt the password so that it can be used in the application. Also, use IAM Roles to ensure the CodeDeploy service can access the KMS service

- AWS CodeDeploy generates "HEALTH_CONSTRAINTS_INVALID" error, when a minimum number of healthy instances defined in deployment group are not available during deployment. To mitigate this error, make sure required number of healthy instances are available during deployments.

- [Run order of the hooks for in-place deployments](https://docs.aws.amazon.com/codedeploy/latest/userguide/reference-appspec-file-structure-hooks.html#reference-appspec-file-structure-hooks-run-order)

