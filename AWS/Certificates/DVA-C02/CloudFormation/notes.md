- As your infrastructure grows, common patterns can emerge in which you declare the same components in each of your templates. You can separate out these common components and create dedicated templates for them. That way, you can mix and match different templates but use nested stacks to create a single, unified stack. Nested stacks are stacks that create other stacks. To create nested stacks, use the AWS::CloudFormation::Stack resource in your template to reference other templates.

- The optional Conditions section contains statements that define the circumstances under which entities are created or configured. For example, you can create a condition and then associate it with a resource or output so that AWS CloudFormation only creates the resource or output if the condition is true. Similarly, you can associate the condition with a property so that AWS CloudFormation only sets the property to a specific value if the condition is true. If the condition is false, AWS CloudFormation sets the property to a different value that you specify.

  - You might use conditions when you want to reuse a template that can create resources in different contexts, such as a test environment versus a production environment. In your template, you can add an EnvironmentType input parameter, which accepts either prod or test as inputs.

- When you need to update a stack, understanding how your changes will affect running resources before you implement them can help you update stacks with confidence. Change sets allow you to preview how proposed changes to a stack might impact your running resources

# Dynamic References

- Reference external values stored in Systems Manager Parameter Store and Secrets Manager within CloudFormation templates
- CloudFormation retrieves the value of the specified reference during create/update/delete operations
- Supports
  - ssm - for plaintext values stored in SSM Parameter Store
  - ssm-secure - for secure strings stored in SSM Parameter Store
  - secretsmanager - for secret values stored in Secrets Manager

`{{resolve:service-name:reference-key:version}}`

## SSM

```yaml
Resources:
  S3Bucket:
    Type: AWS::S3::Bucket
    Properties:
      AccessControl: "{{resolve:ssm:S3AccessControl:2}}"
```

## SSM Secure

```yaml
Resources:
  IAMUser:
    Type: AWS::IAM::User
    Properties:
      UserName: john
      LoginProfile:
        Password: "{{resolve:ssm-secure:IAMUserPassword:10}}"
```

## Secrets Manager

```yaml
Resources:
  DBInstance:
    Type: AWS::IAM::DBInstance
    Properties:
      DBName: MyRDSInstance
      MasterUsername: "{{resolve:secretsmanager:MyRDSSecret:SecretString:username}}"
      MasterUserPassword: "{{resolve:secretsmanager:MyRDSSecret:SecretString:password}}"
```

# CloudFormation, Secrets Manager & RDS

## Option 1 - ManageMasterUserPassword

- ManageMasterUserPassword - creates admin secret implicitly
- RDS, Aurora will manage the secret in Secrets manager and its rotation

```yaml
Resources:
  MyCluster:
    Type: AWS::RDS::DBCluster
    Properties:
      Engine: aurora-mysql
      MasterUserName: masteruser
      ManageMasterUserPassword: true
Outputs:
  Secret:
    Value: !GetAtt MyCluster.MasterUserSecret.SecretArn
```

## Option2 - Dynamic Reference

1. Secret is generated

```yaml
Resources:
  MyDatabaseSecret:
    Type: AWS::SecretsManager::Secret
    Properties:
      Name: MyDatabaseSecret
      GenerateSecretString:
        SecretStringTemplate: '{"username": "admin"}'
        GenerateStringKey: "password"
        PasswordLength: 16
        ExcludeCharacters: '"@/\'
```

2. Reference secret in RDS DB instance

```yaml
MyDBInstance:
  Type: AWS::RDS::DBInstance
  Properties:
    DBName: mydatabase
    AllocatedStorage: 20
    DBInstanceClass: db.t2.micro
    Engine: mysql
    MasterUsername: "{{resolve:secretsmanager:MyDatabaseSecret:SecretString:username}}"
    MasterUserPassword: "{{resolve:secretsmanager:MyDatabaseSecret:SecretString:password}}"
```

3. link the secret to RDS DB instance (for rotation)

```yaml
SecretRDSAttachment:
  Type: AWS::SecretsManager::SecretTargetAttachment
  Properties:
    SecretId: !Ref MyDatabaseSecret
    TargetId: !Ref MyDBInstance
    TargetType: AWS::RDS::DBInstance
```
