# User Guide link
https://docs.aws.amazon.com/IAM/latest/UserGuide/introduction.html

# Overview
## Access management

After a user is set up in IAM, they use their sign-in credentials to authenticate with AWS. Authentication is provided by matching the sign-in credentials to a principal (an IAM user, federated user, IAM role, or application) trusted by the AWS account. Next, a request is made to grant the principal access to resources. Access is granted in response to an authorization request if the user has been given permission to the resource. For example, when you first sign in to the console and are on the console Home page, you aren't accessing a specific service. When you select a service, the request for authorization is sent to that service and it looks to see if your identity is on the list of authorized users, what policies are being enforced to control the level of access granted, and any other policies that might be in effect. Authorization requests can be made by principals within your AWS account or from another AWS account that you trust.

Once authorized, the principal can take action or perform operations on resources in your AWS account. For example, the principal could launch a new Amazon Elastic Compute Cloud instance, modify IAM group membership, or delete Amazon Simple Storage Service buckets.

## Service availability

IAM, like many other AWS services, is **eventually consistent**. IAM achieves high availability by replicating data across multiple servers within Amazon's data centers around the world. If a request to change some data is successful, the change is committed and safely stored. However, the change must be replicated across IAM, which can take some time. Such changes include creating or updating users, groups, roles, or policies. We recommend that you do not include such IAM changes in the critical, high-availability code paths of your application. Instead, make IAM changes in a separate initialization or setup routine that you run less frequently. Also, be sure to verify that the changes have been propagated before production workflows depend on them. For more information, see Changes that I make are not always immediately visible.

## Service cost information

AWS Identity and Access Management (IAM), AWS IAM Identity Center and AWS Security Token Service (AWS STS) are features of your AWS account offered at no additional charge. You are charged only when you access other AWS services using your IAM users or AWS STS temporary security credentials.

IAM Access Analyzer external access analysis is offered at no additional charge. However, you will incur charges for unused access analysis and customer policy checks. For a complete list of charges and prices for IAM Access Analyzer, see IAM Access Analyzer pricing.

For information about the pricing of other AWS products, see the Amazon Web Services pricing page.

## Integration with other AWS services

IAM is integrated with many AWS services. For a list of AWS services that work with IAM and the IAM features the services support, see [AWS services that work with IAM](https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_aws-services-that-work-with-iam.html).

# Why should I use IAM?

AWS Identity and Access Management is a powerful tool for securely managing access to your AWS resources. One of the primary benefits of using IAM is the ability to grant shared access to your AWS account. Additionally, IAM allows you to assign granular permissions, enabling you to control exactly what actions different users can perform on specific resources. This level of access control is crucial for maintaining the security of your AWS environment. IAM also provides several other security features. You can add multi-factor authentication (MFA) for an extra layer of protection, and leverage identity federation to seamlessly integrate users from your corporate network or other identity providers. IAM also integrates with AWS CloudTrail, providing detailed logging and identity information to support auditing and compliance requirements. By taking advantage of these capabilities, you can help ensure that access to your critical AWS resources is tightly controlled and secure.

## Shared access to your AWS account

You can grant other people permission to administer and use resources in your AWS account without having to share your password or access key.

## Granular permissions

You can grant different permissions to different people for different resources. For example, you might allow some users complete access to Amazon Elastic Compute Cloud (Amazon EC2), Amazon Simple Storage Service (Amazon S3), Amazon DynamoDB, Amazon Redshift, and other AWS services. For other users, you can allow read-only access to just some Amazon S3 buckets, or permission to administer just some Amazon EC2 instances, or to access your billing information but nothing else.

## Secure access to AWS resources for applications that run on Amazon EC2

You can use IAM features to securely provide credentials for applications that run on EC2 instances. These credentials provide permissions for your application to access other AWS resources. Examples include S3 buckets and DynamoDB tables.

## Multi-factor authentication (MFA)

You can add two-factor authentication to your account and to individual users for extra security. With MFA you or your users must provide not only a password or access key to work with your account, but also a code from a specially configured device. If you already use a FIDO security key with other services, and it has an AWS supported configuration, you can use WebAuthn for MFA security. For more information, see Supported configurations for using passkeys and security keys

## Identity federation

You can allow users who already have passwords elsewhere—for example, in your corporate network or with an internet identity provider—to access your AWS account. These users are granted temporary credentials that comply with IAM best practice recommendations. Using identity federation enhances the security of your AWS account.

## Identity information for assurance

If you use AWS CloudTrail, you receive log records that include information about those who made requests for resources in your account. That information is based on IAM identities.

## PCI DSS Compliance

IAM supports the processing, storage, and transmission of credit card data by a merchant or service provider, and has been validated as being compliant with Payment Card Industry (PCI) Data Security Standard (DSS). For more information about PCI DSS, including how to request a copy of the AWS PCI Compliance Package, see PCI DSS Level 1.

# When do I use IAM?

AWS Identity and Access Management is a core infrastructure service that provides the foundation for access control based on identities within AWS. You use IAM every time you access your AWS account. The way you use IAM will depend on the specific responsibilities and job functions within your organization. Users of AWS services use IAM to access the AWS resources required for their day-to-day work, with administrators granting the appropriate permissions. IAM administrators, on the other hand, are responsible for managing IAM identities and writing policies to control access to resources. Regardless of your role, you interact with IAM whenever you authenticate and authorize access to AWS resources. This could involve signing in as an IAM user, assuming an IAM role, or leveraging identity federation for seamless access. Understanding the various IAM capabilities and use cases is crucial for effectively managing secure access to your AWS environment. When it comes to creating policies and permissions, IAM provides a flexible and granular approach. You can define trust policies to control which principals can assume a role, in addition to identity-based policies that specify the actions and resources a user or role can access. By configuring these IAM policies, you can help ensure that users and applications have the appropriate level of permissions to perform their required tasks.

## When you are performing different job functions

AWS Identity and Access Management is a core infrastructure service that provides the foundation for access control based on identities within AWS. You use IAM every time you access your AWS account.

How you use IAM differs, depending on the work that you do in AWS.

- Service user – If you use an AWS service to do your job, then your administrator provides you with the credentials and permissions that you need. As you use more advanced features to do your work, you might need additional permissions. Understanding how access is managed can help you request the right permissions from your administrator.

- Service administrator – If you're in charge of an AWS resource at your company, you probably have full access to IAM. It's your job to determine which IAM features and resources your service users should access. You must then submit requests to your IAM administrator to change the permissions of your service users. Review the information on this page to understand the basic concepts of IAM.

- IAM administrator – If you're an IAM administrator, you manage IAM identities and write policies to manage access to IAM.

## When you are authorized to access AWS resources

Authentication is how you sign in to AWS using your identity credentials. You must be authenticated (signed in to AWS) as the AWS account root user, as an IAM user, or by assuming an IAM role.

You can sign in to AWS as a federated identity by using credentials provided through an identity source. AWS IAM Identity Center (IAM Identity Center) users, your company's single sign-on authentication, and your Google or Facebook credentials are examples of federated identities. When you sign in as a federated identity, your administrator previously set up identity federation using IAM roles. When you access AWS by using federation, you are indirectly assuming a role.

Depending on the type of user you are, you can sign in to the AWS Management Console or the AWS access portal. For more information about signing in to AWS, see How to sign in to your AWS account in the AWS Sign-In User Guide.

If you access AWS programmatically, AWS provides a software development kit (SDK) and a command line interface (CLI) to cryptographically sign your requests by using your credentials. If you don't use AWS tools, you must sign requests yourself. For more information about using the recommended method to sign requests yourself, see AWS Signature Version 4 for API requests in the IAM User Guide.

Regardless of the authentication method that you use, you might be required to provide additional security information. For example, AWS recommends that you use multi-factor authentication (MFA) to increase the security of your account. To learn more, see Multi-factor authentication in the AWS IAM Identity Center User Guide and AWS Multi-factor authentication in IAM in the IAM User Guide.

## When you sign-in as an IAM user

An **IAM user** is an identity within your AWS account that has specific permissions for a single person or application. Where possible, we recommend relying on temporary credentials instead of creating IAM users who have long-term credentials such as passwords and access keys. However, if you have specific use cases that require long-term credentials with IAM users, we recommend that you rotate access keys. For more information, see Rotate access keys regularly for use cases that require long-term credentials in the IAM User Guide.

An **IAM group** is an identity that specifies a collection of IAM users. You can't sign in as a group. You can use groups to specify permissions for multiple users at a time. Groups make permissions easier to manage for large sets of users. For example, you could have a group named IAMAdmins and give that group permissions to administer IAM resources.

Users are different from roles. A user is uniquely associated with one person or application, but a role is intended to be assumable by anyone who needs it. Users have permanent long-term credentials, but roles provide temporary credentials. To learn more, see Use cases for IAM users in the IAM User Guide.

## When you assume an IAM role

An IAM role is an identity within your AWS account that has specific permissions. It is similar to an IAM user, but is not associated with a specific person. To temporarily assume an IAM role in the AWS Management Console, you can switch from a user to an IAM role (console). You can assume a role by calling an AWS CLI or AWS API operation or by using a custom URL. For more information about methods for using roles, see [Methods to assume a role](https://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_manage-assume.html) in the IAM User Guide.

IAM roles with temporary credentials are useful in the following situations:

- **Federated user access** – To assign permissions to a federated identity, you create a role and define permissions for the role. When a federated identity authenticates, the identity is associated with the role and is granted the permissions that are defined by the role. For information about roles for federation, see Create a role for a third-party identity provider (federation) in the IAM User Guide. If you use IAM Identity Center, you configure a permission set. To control what your identities can access after they authenticate, IAM Identity Center correlates the permission set to a role in IAM. For information about permissions sets, see Permission sets in the AWS IAM Identity Center User Guide.

- **Temporary IAM user permissions** – An IAM user or role can assume an IAM role to temporarily take on different permissions for a specific task.

-- **Cross-account access** – You can use an IAM role to allow someone (a trusted principal) in a different account to access resources in your account. Roles are the primary way to grant cross-account access. However, with some AWS services, you can attach a policy directly to a resource (instead of using a role as a proxy). To learn the difference between roles and resource-based policies for cross-account access, see [Cross account resource access in IAM](https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies-cross-account-resource-access.html) in the IAM User Guide.

- **Cross-service access** – Some AWS services use features in other AWS services. For example, when you make a call in a service, it's common for that service to run applications in Amazon EC2 or store objects in Amazon S3. A service might do this using the calling principal's permissions, using a service role, or using a service-linked role.

  - **Forward access sessions (FAS)** – When you use an IAM user or role to perform actions in AWS, you are considered a principal. When you use some services, you might perform an action that then initiates another action in a different service. FAS uses the permissions of the principal calling an AWS service, combined with the requesting AWS service to make requests to downstream services. FAS requests are only made when a service receives a request that requires interactions with other AWS services or resources to complete. In this case, you must have permissions to perform both actions. For policy details when making FAS requests, see Forward access sessions.

  - **Service role** – A service role is an IAM role that a service assumes to perform actions on your behalf. An IAM administrator can create, modify, and delete a service role from within IAM. For more information, see Create a role to delegate permissions to an AWS service in the IAM User Guide.

  - **Service-linked role** – A service-linked role is a type of service role that is linked to an AWS service. The service can assume the role to perform an action on your behalf. Service-linked roles appear in your AWS account and are owned by the service. An IAM administrator can view, but not edit the permissions for service-linked roles.

- **Applications running on Amazon EC2** – You can use an IAM role to manage temporary credentials for applications that are running on an EC2 instance and making AWS CLI or AWS API requests. This is preferable to storing access keys within the EC2 instance. To assign an AWS role to an EC2 instance and make it available to all of its applications, you create an instance profile that is attached to the instance. An instance profile contains the role and enables programs that are running on the EC2 instance to get temporary credentials. For more information, see Use an IAM role to grant permissions to applications running on Amazon EC2 instances in the IAM User Guide.

## When you create policies and permissions

You grant permissions to a user by creating a policy, which is a document that lists the actions that a user can perform and the resources those actions can affect. Any actions or resources that are **not explicitly allowed are denied by default**. Policies can be created and attached to principals (users, groups of users, roles assumed by users, and resources).

You can use these policies with an IAM role:

- **Trust policy** – Defines which principal can assume the role, and under which conditions. A trust policy is a specific type of resource-based policy for IAM roles. A role can have only one trust policy.

- **Identity-based policies** (inline and managed) – These policies define the permissions that the user of the role is able to perform (or is denied from performing), and on which resources.

# How do I manage IAM?

Managing AWS Identity and Access Management within an AWS environment involves leveraging a variety of tools and interfaces. The most common method is through the AWS Management Console, a web-based interface that allows you to perform a wide range of IAM administrative tasks, from creating users and roles to configuring permissions.

For users more comfortable with command line interfaces, AWS provides two sets of command line tools - the AWS Command Line Interface and the AWS Tools for Windows PowerShell. These allow you to issue IAM-related commands directly from the terminal, often more efficiently than navigating the console. Additionally, AWS CloudShell enables you to run CLI or SDK commands directly from your web browser, using the permissions associated with your console sign-in.

Beyond the console and command line, AWS offers Software Development Kits (SDKs) for various programming languages, enabling you to integrate IAM management functionality directly into your applications. Alternatively, you can access IAM programmatically using the IAM Query API, which allows you to issue HTTPS requests directly to the service. Leveraging these different management approaches provides you with the flexibility to incorporate IAM into your existing workflows and processes.

## Use the AWS Management Console

## AWS Command Line Tools

## AWS Command Line Interface (CLI) and Software Development Kits (SDKs)

## Use the AWS SDKs

## Use the IAM Query API

# How IAM works

1. a human user or an application uses their **sign-in credentials** to authenticate with AWS. IAM matches the sign-in credentials to a **principal** (an IAM user, federated user, IAM role, or application) trusted by the AWS account and authenticates permission to access AWS.
2. IAM makes a request to grant the principal access to resources.

## Components of a request

When a principal tries to use the AWS Management Console, the AWS API, or the AWS CLI, that principal sends a request to AWS. The request includes the following information:

- **Actions or operations** – The actions or operations that the principal wants to perform., such as an action in the AWS Management Console, or an operation in the AWS CLI or AWS API.

- **Resources** – The AWS resource object upon which the principal requests to perform an action or operation.

- **Principal** – The person or application that used an entity (user or role) to send the request. Information about the principal includes the permission policies.

- **Environment data** – Information about the IP address, user agent, SSL enabled status, and the timestamp.

- **Resource data** – Data related to the resource requested, such as a DynamoDB table name or a tag on an Amazon EC2 instance.

AWS gathers the request information into a request context, which IAM evaluates to authorize the request.

## How principals are authenticated
A principal signs in to AWS using their credentials which IAM authenticates to permit the principal to send a request to AWS. Some services, such as Amazon S3 and AWS STS, allow specific requests from anonymous users. However, they're the exception to the rule. Each type of user goes through authentication.

- **Root user** – Your sign in credentials used for authentication are the email address you used to create the AWS account and the password you specified at that time.

- **Federated user** – Your identity provider authenticates you and passes your credentials to AWS, you don't have to sign-in directly to AWS. Both IAM Identity Center and IAM support federated users.

- **Users in AWS IAM Identity Center directory**(not federated)– Users created directly in the IAM Identity Center default directory sign in using the AWS access portal and provide your username and password.

- **IAM user** – You sign-in by providing your account ID or alias, your username, and password. To authenticate workloads from the API or AWS CLI, you might use temporary credentials through assuming a role or you might use long-term credentials by providing your access key and secret key.

  To learn more about the IAM entities, see IAM users and IAM roles.

AWS recommends that you use multi-factor authentication (MFA) with all users to increase the security of your account. To learn more about MFA, see AWS Multi-factor authentication in IAM.

## Authorization and permission policy basics
Authorization refers to the principal having the required permissions to complete their request. During authorization, IAM identifies the policies that apply to the request using values from the request context. It then uses the policies to determine whether to allow or deny the request. IAM stores most permission policies as **JSON documents** that specify the permissions for principal entities.

There are several types of policies that can affect an authorization request. To **provide your users** with permissions to access the AWS resources in your account, you can use **identity-based policies**. **Resource-based policies** can grant **cross-account** access. To make a request in a different account, a policy in the other account must allow you to access the resource and the IAM entity that you use to make the request must have an identity-based policy that allows the request.

IAM checks each policy that applies to the context of your request. IAM policy evaluation uses an **explicit deny**, which means that if a single permissions policy **includes a denied action**, IAM **denies** the entire request and stops evaluating. Because requests are denied by default, the applicable permissions policies must allow every part of your request for IAM to authorize your request. The evaluation logic for a request within a single account follows these basic rules:

- By default, **all requests are denied**. (In general, requests made using the AWS account root user credentials for resources in the account are always allowed.)

- An explicit allow in any permissions policy (identity-based or resource-based) overrides this default.

- The existence of an **Organizations service control policy (SCP)** or **resource control policy (RCP)**, **IAM permissions boundary**, or a **session policy** overrides the allow. If one or more of these policy types exists, they must all allow the request. Otherwise, it's implicitly denied. For more information on SCPs and RCPs, see [Authorization policies in AWS Organizations](https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_policies_authorization_policies.html) in the AWS Organizations User Guide.

- An **explicit deny** in any policy **overrides** any **allows** in any policy.

To learn more, see [Policy evaluation logic](https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies_evaluation-logic.html).

# Compare IAM identities and credentials

We recommend centralizing root access to help you **centrally secure the root user credentials** of your AWS accounts managed using **AWS Organizations**. [Centrally manage root access for member accounts](https://docs.aws.amazon.com/IAM/latest/UserGuide/id_root-user.html#id_root-user-access-management) lets you centrally remove and prevent long-term root user credential recovery, preventing unintended root access at scale. After you enable centralized root access, you can assume a privileged session to perform actions on member accounts.

## Terms

### IAM Resource
The IAM service stores these resources. You can add, edit, and remove them from the IAM console.

- IAM user
- IAM **group**
- IAM **role**
- Permission policy
- Identity-provider object

### IAM Entity
IAM resources that AWS uses for authentication. Specify the entity as a Principal in a resource-based policy.
- IAM user
- IAM role

### IAM Identity
The IAM resource that's authorized in policies to perform actions and to access resources. Identities include IAM users, IAM groups, and IAM roles.

![iam identity](./iam-terms-2.png)

### Principals
An AWS account root user, IAM user or an IAM role that can make a request for an action or operation on an AWS resource. Principals include human users, workloads, federated users and assumed roles. After authentication, IAM grants the principal either permanent or temporary credentials to make requests to AWS, depending on the principal type.

*Human users* are also known as human identities, such as the people, administrators, developers, operators, and consumers of your applications.

*Workloads* are a collection of resources and code that delivers business value, such as an application, process, operational tools, and other components.

*Federated users* are users whose identity and credentials are managed by another identity provider, such as Active Directory, Okta, or Microsoft Entra.

*IAM roles* are an IAM identity that you can create in your account that has specific permissions that determine what the identity can and can't do. However, instead of being uniquely associated with one person, a role is intended to be assumable by anyone who needs it.

IAM grants IAM users and the root user long-term credentials and IAM roles temporary credentials. Federated users and users in AWS IAM Identity Center assume IAM roles when they sign-in to AWS, which grants them temporary credentials. As a best practice, we recommend that you require human users and workloads to access AWS resources using temporary credentials.

## Difference between IAM users and users in IAM Identity Center

**IAM users** aren't separate accounts; they're individual users within your account. Each user has their own password for access to the AWS Management Console. You can also create an individual access key for each user so that the user can make programmatic requests to work with resources in your account.

IAM users and their access keys have long-term credentials to your AWS resources. The primary use for IAM users is to give workloads that can't use IAM roles the ability to make programmatic requests to AWS services using the API or CLI.

Workforce identities (people) are users in AWS **IAM Identity Center** that have different permission needs depending on the role they're performing and can work in various AWS accounts across an organization. If you have use cases that require access keys, you can support those use cases with users in AWS IAM Identity Center. People who sign-in through the AWS access portal can obtain access keys with short-term credentials to your AWS resources. For **centralized access management**, we recommend that you use AWS **IAM Identity Center** to manage access to your accounts and permissions within those accounts. IAM Identity Center is automatically configured with an Identity Center directory as your default identity source where you can add people and groups, and assign their level of access to your AWS resources. For more information, see What is AWS IAM Identity Center in the AWS IAM Identity Center User Guide.

The **main difference** between these two types of users is that users in IAM Identity Center automatically assume an IAM role when they sign-in to AWS before they access the management console or AWS resources. IAM roles grant temporary credentials each time the user signs-in to AWS. For IAM users to sign in using an IAM role they must have permission to assume and switch roles and they must explicitly choose to switch to the role they want to assume after accessing the AWS account.

## Federate users from an existing identity source

If the users in your organization are already authenticated when they sign in to your corporate network, you don't have to create separate IAM users or users in IAM Identity Center for them. Instead, you can federate those user identities into AWS using either IAM or AWS IAM Identity Center. Federated users assume an IAM role that gives them permissions to access specific resources. For more information about roles, see Roles terms and concepts.

# Root account
Strongly recommend that you **don't** use the **root user** for your everyday tasks. Safeguard your root user credentials and use them to perform the tasks that only the root user can perform.

## Tasks that require root user credentials


### Here is the list of [tasks that require root user](https://docs.aws.amazon.com/IAM/latest/UserGuide/id_root-user.html#root-user-tasks):

#### Account Management Tasks
- [Change your account settings](https://docs.aws.amazon.com/accounts/latest/reference/manage-acct-update-root-user.html). This includes the account name, email address, root user password, and root user access keys. Other account settings, such as contact information, payment currency preference, and AWS Regions, don't require root user credentials.
- [Restore IAM user permissions](https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies_manage-edit.html). If the only IAM administrator accidentally revokes their own permissions, you can sign in as the root user to edit policies and restore those permissions.
- [Close your AWS account.](https://docs.aws.amazon.com/accounts/latest/reference/manage-acct-closing.html)
  - [How do I assign ownership of my AWS account to another entity?.](https://repost.aws/knowledge-center/transfer-aws-account)

#### Billing Tasks
- [Activate IAM access to the Billing and Cost Management console.](https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/control-access-billing.html#ControllingAccessWebsite-Activate)

- Some Billing tasks are limited to the root user. See Managing an AWS account in AWS Billing User Guide for more information.

- View certain tax invoices. An IAM user with the aws-portal:ViewBilling permission can view and download VAT invoices from AWS Europe, but not AWS Inc. or Amazon Internet Services Private Limited (AISPL).

#### AWS GovCloud (US) Tasks
- Sign up for AWS GovCloud (US).

- Request AWS GovCloud (US) account root user access keys from AWS Support.

#### Amazon EC2 Task
- Register as a seller in the Reserved Instance Marketplace.

#### AWS KMS Task
- In the event that an AWS Key Management Service key becomes unmanageable, an administrator can recover it by contacting AWS Support; however, AWS Support responds to your root user's primary phone number for authorization by confirming the ticket OTP.

#### Amazon Mechanical Turk Task
- Link Your AWS account to your MTurk Requester account.

#### Amazon Simple Storage Service Tasks
- Configure an Amazon S3 bucket to enable MFA (multi-factor authentication).

- Edit or delete an Amazon S3 bucket policy that denies all principals.

  - You can use privileged actions to unlock an Amazon S3 bucket with a misconfigured bucket policy. For details, see Perform a privileged task on an AWS Organizations member account.

#### Amazon Simple Queue Service Task
- Edit or delete an Amazon SQS resource-based policy that denies all principals.

  - You can use privileged actions to unlock an Amazon SQS queue with a misconfigured resource-based policy. For details, see Perform a privileged task on an AWS Organizations member account.