# Aurora

## Tips

- transactional + scalable database + high write consistency + linked tables = Amazon Aurora

## Aurora replicas

- Independent endpoints in an Aurora DB cluster
- Best used for scaling read operations and increasing availability
- Up to 15 Aurora replicas to be distributed across the availability zones that a DB cluster spans within an AWS region
- Replica lag varies depending on the rate of database change
- Fully dedicated to read operations on your cluster volume

### Failover option

- Aurora Replicas can be used as failover targets. If the primary instance fails, an Aurora Replica is promoted to the primary instance

## What is the best solution to separate the read requests from the write requests?

Create a read replica and modify the application to use the appropriate endpoint.

# Elastic Beanstalk

## Supported load balancer type:

- Classic Load Balancer (deprecated)
- Network Load Balancer:
  - An network layer load balancer
  - Routes TCP request traffic to different ports on environment instances
  - Supports both **active** and **passive** health checks.
- Application Load Balancer:
  - An application layer load balancer
  - Routes HTTP or HTTPs request traffic to different ports on environment instances based on the request path

# AWS Fargate

# EFS

- Scale automatically
- Accessed concurrently by multiple EC2

# AWS FSx for Lustre

- Easy and cost effective to launch and run popular file systems
- Supports concurrent access
- Use it for workloads where speed matters
  - machine learning
  - high performance computing
  - video processing
  - financial modeling

## Integration

- S3

# FSx for windows

With Amazon FSx, you can leverage the rich feature sets and fast performance of widely-used open source and commercially-licensed file systems, while avoiding time-consuming administrative tasks like hardware provisioning, software configuration, patching, and backups

# AWS Global Accelerator

# EC2

## How to

### Create a copy of your EC2:

https://aws.amazon.com/premiumsupport/knowledge-center/copy-ami-region/

1. Create an AMI of your EC2 instance
2. Copy the AMI of your EC2 instance to another AWS Region
3. After the copy operation completes, launch a new EC2 instance from your AMI in the new AWS Region

### How do I attach backend instances with private IP addresses to my internet-facing load balancer in ELB?

https://repost.aws/knowledge-center/public-load-balancer-private-ec2

## Auto Scaling

## ELB

### Network Load Balancer

- Handle Layer 4 traffic
- can route traffic to targets based on IP addresses
- support cross-VPC routing if IP addresses are used

### Application Load Balancer

- Operates at the application layer (layer 7)
- can route traffic based on IP addresses.
- support cross-VPC routing if IP addresses are used

## Types

## Placement group

### Cluster placement groups - low latency and high throughput

- logical grouping of instances within a single AZ
- can span peered VPCs in the same region
- Instances in the same cluster placement group
  - higher per-flow throughput limit of up to 10 gbps for TCP/IP traffic
  - placed in the same high-bisection bandwidth segment of the network
- Recommended for application
  - benefit from low network latency
  - high network throughput
  - or both
  - when the majority of the network traffic is between the instances in the group

### Partition placement groups:

- Help reduce the likelihood of correlated hardware failures for your application
- each partition within a placement group has its own set of racks
  - each rack has its own network and power source
- Can be used to
  - Deploy large distributed and replicated workloads, such as
    - HDFS
    - HBase
    - Cassandra
- Recommended for applications
  - have a small number of critical instances that should be kept separate from each other

# EBS

## Types

### General Purpose SSD (gp3)

### General Purpose SSD (gp2)

### Provisioned IOPS SSD (io1)

### Provisioned IOPS SSD (io2)

### Cold HDD (sc1)

### Throughput Optimized HDD (st1)

Provide low-cost magnetic storage that is a good fit for large, sequential workloads, such as

- Amazon EMR
- ETL
- Data warehouse
- Log processing

#### Tips

- huge amount of data + sequential processing + consistent = EBS Throughput Optimized HDD

### Magnetic (standard)

## Metrics

### Solid state drive (SSD) volumes

![image](./EBS_SSD_metrics.png)

### Hard disk drive (HDD) volumes

![image](./EBS_HDD_metrics.png)

# API Gateway

# Amazon DynamoDB

## Tips

### key-value store + changeable schema = Amazon DynamoDB

- Fully managed
- multi-region
- multi-master
- durable db with built-in security, backup and restore
- in-memory caching
- key-value document db
- single-digit millisecond performance at any scale
- can handle more than 10 trillion requests per day
  - support peaks of more than 20 million requests per second

### data in chunks + little latency = NoSQL DB = DynamoDB

### fully managed + scalable + durable + flexible schema =Amazon DynamoDB

# Route 53

- CNAME
- Alias
- etc.

## Targets

- Alias records
  - CloudFront distribution
  - Elastic Beanstalk env
  - ELB
  - API Gateway
  - S3
  - VPC interface endpoint

## Health check

- active-active failover
  - Use this failover configuration when you want all of your resources to be available the majority of the time, when a resource becomes unavailable, Route 53 can detect that it's unhealthy and stop including it when responding to queries
  - all the records that have the same name, the same type (such as A or AAAA), and the same routing policy (such as weighted or latency) are active unless Route 53 considers them unhealthy
- active-passive failover
  - Use an this failover configuration when you want a primary resource or group of resources to be available the majority of the time and you want a secondary resource or group of resources to be on standby in case all the primary resources become unavailable

# AWS database types

## Amazon Redshift

an enterprise-level, petabyte scale, fully managed data warehousing service

### To run different queries types (fast and slow) on big data

Use Redshift workload management (WLM)

# S3

## Amazon S3 Transfer Acceleration

Speeds up uploads and downloads by routing traffic through optimized network paths using CloudFront’s edge locations.

## Tips

- S3 is eventually consistent, reading after writing may return old data.
  - S3 provides read-after-write consistency for PUTS of new objects in your S3 bucket in all Regions with one caveat. The caveat is that if you make a **HEAD or GET** request to a key name **before** the object is **created**, then **create** the object shortly after that, a subsequent **GET** might not return the object due to eventual consistency. Amazon S3 offers eventual consistency for overwrite PUTS and DELETES in all Regions

## Pre-signed URL

### Upload with pre-signed url

https://docs.aws.amazon.com/AmazonS3/latest/userguide/PresignedUrlUploadObject.html

## Storage class

- Amazon S3 Standard - General Purpose
- Amazon S3 Standard-Infrequent Access (IA)
  - Use Cases: Disaster Recovery, backups
- Amazon S3 One Zone-Infrequent Access
  - Use Cases: storing secondary backup copies of on-premises data, or data you can recreate
- Amazon S3 Glacier Instant Retrieval
  - Low-cost
  - Pricing: price for storage + object retrieval cost
  - Millisecond retrieval, great for data accessed once a quarter
  - Minimum storage duration of 90 days
- Amazon S3 Glacier Flexible Retrieval
  - Low-cost
  - Pricing: price for storage + object retrieval cost
  - Expedited (1 to 5 minutes), Standard (3 to 5 hours), Bulk (5 to 12 hours) – free
  - Minimum storage duration of 90 days
- Amazon S3 Glacier Deep Archive
  - Low-cost
  - Pricing: price for storage + object retrieval cost
  - Standard (12 hours), Bulk (48 hours)
  - Minimum storage duration of 180 days
- Amazon S3 Intelligent Tiering
  - Designed for 3 use cases:
    - Unpredictable workloads
    - Changing access patterns
    - Lack of experience with storage optimization

## Configuring a static website using a custom domain registered with Route 53

https://docs.aws.amazon.com/AmazonS3/latest/userguide/website-hosting-custom-domain-walkthrough.html

# VPC

## default state of VPC security group

- There are no inbound rules and traffic will be implicitly denied
- There is an outbound rule that allows all traffic to all IP addresses

## Private Virtual Interface

A private virtual interface for **AWS Direct Connect** provides a dedicated, private connection between your on-premises network and your Amazon VPC. It allows you to route traffic to your VPC using private IP addresses, bypassing the public internet.

## VPC endpoint

## egress-only internet gateway

- allow outbound **IPv6** traffic from a VPC to the internet while blocking inbound traffic from the internet to the VPC.
- managed AWS service - cost-effective
  - Auto scale

## Security

- https://docs.aws.amazon.com/vpc/latest/peering/vpc-peering-security-groups.html

## NAT Gateway

- For IPv4
- Enable instances in a private subnet to connect to the internet or other AWS services
- Prevent the internet from initiating a connection with those instances

### Tips

- provide internet to private subnet = use NAT gateway

- An internet gateway must be attached to the VPC for any outbound connections to work.

## VPC Flow logs

- Capture information about the IP traffic going to and from network interfaces in your VPC
- Can publish log to **Cloudwatch** logs or **S3**
- Can help with the following tasks
  - Diagnosing overly restrictive security group rules
  - Monitoring the traffic that is reaching your instance
  - Determining the direction of the traffic to and from the network interfaces

# Messaging

## SQS - decouple the web application from the database

### Visibility timeout

- 30 seconds by default

## SNS

- Good for sending notifications or messages to multiple endpoints
- does NOT guarantee message order
- NOT designed for high-throughput, ordered streaming data

### 2 Types of message queues:

- Standard queues
  - offer maximum throughput
  - best-effort ordering
  - at least once delivery
- FIFO queues
  - guarantee the messages are processed **exactly once** in the **exact order** that they are sent

# Snowball Family

data transport solution that accelerates moving **terabytes to petabytes** of data into and out of AWS using storage appliances designed to be secure for **physical transport**

Using snowball helps eliminate challenges:

- high network costs
- long transfer times
- security concerns

# AWS Direct Connect

a cloud service solution that makes it easy to establish a dedicated network connection from your premises to AWS

- Establish private connectivity between AWS and your data center, office, or colocation environment

# CloudTrail

a service that enables governance, compliance, operational auditing, and risk auditing of your AWS account

# Amazon RDS (Relational Database Service)

## Scenarios

### heavy read and write queries, and having throughput issues

- Run SELECT queries for stale data on read replica

because replicas might not always be up to date

# CloudFront

a fast content delivery network (CDN) service that securely delivers data, videos, applications, and APIs to customers globally with low latency, high transfer speeds, all within a developer-friendly environment

## Tips

### Use CloudFront Signed Cookies restrict access to multiple files

CloudFront signed cookies allow you to control who can access your content when you don’t want to change your current URLs or when you want to provide access to multiple restricted files

### Use CloudFront Signed URL restrict access to a Single file

## Scenarios

### To deliver video on demand (VOD) streaming with CloudFront

https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/on-demand-video.html

# Kinesis Firehose

the easiest way to reliably load streaming data into data lakes, data stores and analytics tools

- NOT directly connect with databases or other data services
- Sources:
  - Kinesis Data Stream
  - Lambda
  - Custom App
- Destinations:
  - S3
  - Redshift
  - Elasticsearch
  - Splunk
  - Custom HTTP endpoints

# Kinesis Data Stream

## Tips

- IOT data + streams + Partition by equipment + s3 = Use Amazon Kinesis Data Streams

# Amazon Kubernetes - EKS

# AWS secrets manager

# AWS parameter store

# AWS Cloudformation

simplifies provisioning and management on AWS

## Tips

### administrate VPCs = Use AWS CloudFormation

# AWS Lex

a service for building conversational interfaces into any application using voice and text.

# AWS software version control

# AWS PrivateLink

## Components

## Tips

### allow the application to access service endpoints in the same region = Use AWS PrivateLink

# IAM

## Tips

### Every IAM user starts with no permissions

### SSO

- AWS Security Token Service (STS)
  - a web service that enables you to request temporary, limited-privilege credentials for IAM users or for users that you authenticate (such as federated users from an on-premise directory).

## Amazon Cognito

used for authenticating users to web and mobile apps

# AWS Batch

eliminates the need to operate third-party commercial or open source batch processing solutions

# AWS Pen test

https://aws.amazon.com/security/penetration-testing/

# AWS Step Functions

orchestrates serverless workflows including coordination, state, and function chaining as well as combining long-running executions not supported within Lambda execution limits by breaking into multiple steps or by calling workers running on Amazon Elastic Compute Cloud (Amazon EC2) instances or on-premises

# AWS CodeCommit

fully managed source control service that allows you to host secure and scalable Git repositories

# AWS CodeStar

enables you to quickly develop, build, and deploy applications on AWS

# AWS CloudHSM

a cloud-based hardware security module (HSM) that enables you to easily generate and use your own encryption keys on the AWS Cloud

# AWS EMR

a web service that enables businesses, researchers, data analysts, and developers to easily and cost-effectively process vast amounts of data

EMR utilizes a hosted Hadoop framework running on Amazon EC2 and Amazon S3.
