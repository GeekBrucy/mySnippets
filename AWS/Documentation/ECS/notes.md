# Amazon ECS terminology and components
There are three layers in Amazon ECS:

- **Capacity** - The infrastructure where your containers run

- **Controller** - Deploy and manage your applications that run on the containers

- **Provisioning** - The tools that you can use to interface with the scheduler to deploy and manage your applications and containers

## Capacity

### Options
- EC2 instances: you choose the instance type, the number of instances, and manage the capacity.
- 
- Serverless (Fargate): Fargate is a serverless, pay-as-you-go compute engine. With Fargate you don't need to manage servers, handle capacity planning, or isolate container workloads for security.
- 
- On-prem: Amazon ECS Anywhere provides support for registering an external instance such as an on-premises server or virtual machine (VM), to your Amazon ECS cluster.

## Controller
The Amazon ECS scheduler is the software that manages your applications.

## Provisioning
There are multiple options for provisioning Amazon ECS:
- **AWS Management Console** — Provides a web interface that you can use to access your Amazon ECS resources.

- **AWS Command Line Interface (AWS CLI)** — Provides commands for a broad set of AWS services, including Amazon ECS. It's supported on Windows, Mac, and Linux. For more information, see AWS Command Line Interface.

- **AWS SDKs** — Provides language-specific APIs and takes care of many of the connection details. These include calculating signatures, handling request retries, and error handling. For more information, see AWS SDKs.

- **Copilot** — Provides an open-source tool for developers to build, release, and operate production ready containerized applications on Amazon ECS. For more information, see Copilot on the GitHub website.

- **AWS CDK** — Provides an open-source software development framework that you can use to model and provision your cloud application resources using familiar programming languages. The AWS CDK provisions your resources in a safe, repeatable manner through AWS CloudFormation.

![ECS Layers](./ecs-layers.png)


# Application lifecycle

![ECS Lifecycle](./ecs-lifecycle.png)

# Cluster

An Amazon ECS cluster is a **logical grouping of tasks or services**. In addition to tasks and services, a cluster consists of the following resources:

- The infrastructure capacity which can be a combination of the following:

  - Amazon EC2 instances in the AWS cloud

  - Serverless (AWS Fargate) in the AWS cloud

  - On-premises virtual machines (VM) or servers

- The network (VPC and subnet) where your tasks and services run

  - When you use Amazon EC2 instances for the capacity, the subnet can be in Availability Zones, Local Zones, Wavelength Zones or AWS Outposts.

- An optional namespace

  - The namespace is used for service-to-service communication with Service Connect.

- A monitoring option

  - CloudWatch Container Insights comes at an additional cost and is a fully managed service. It automatically collects, aggregates, and summarizes Amazon ECS metrics and logs.

# Fargate

## Role

# CLI