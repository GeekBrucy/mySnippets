# Intro

EC2 = Elastic Compute Cloud = Infrastructure as a Service

It mainly consists in the capability of:

- Rending virtual machines (EC2)
- Storing data on virtual drives (EBS)
- Distributing load across machines (ELB)
- Scaling the services using an auto-scaling group (ASG)

## EC2 sizing & configuration options

- OS: Linux, Windows or Mac OS
- How much compute power & cores (CPU)
- How much random-access memory (RAM)
- How much storage space:

  - Network-attached (EBS & EFS)
  - Hardware (EC2 Instance Store)

- Network card: speed of the card, public IP address
- Firewall rules: security group
- Bootstrap script (configure at first launch): EC2 user data

### EC2 User Data

- It is possible to bootstrap our instances using an EC2 User data script
- Bootstrapping means launching commands when a machine starts.
- EC2 user data is used to automate boot tasks such as:

  - Installing updates
  - Installing software
  - Downloading common files from the internet
  - Anything you can think of

## EC2 Instance Types - Overview

You can use different types of EC2 instances that are optimised for different use cases (https://aws.amazon.com/ec2/instance-types/)

### EC2 Instance Types - General Purpose

- Great for a diversity of workloads such as web servers or code repositories
- Balance between

  - Compute

  - Memory

  - Networking

### EC2 Instance Types - Compute optimized

- Great for compute-intensive tasks that require high performance processors

  - Batch processing workloads

  - Media transcoding

  - High performance web servers

  - High performance computing (HPC)

  - Scientific modeling & machine learning

  - Dedicated gaming servers

### EC2 Instance Types - Memory Optimized

- Fast performance for workloads that process large data sets in memory

  - High performance, relational/non-relational databases

  - Distributed web scale cache stores

  - In-memory databases optimized for BI (business intelligence)

  - Applications performing real-time processing of big unstructured data

### EC2 Instance Types - Storage Optimized

- Great for storage-intensive tasks that require high, sequential read and write access to large data sets on local storage

  - High frequency online transaction processing (OLTP) systems

  - Relational & NoSQL databases

  - Cache for in-memory databases (for example, Redis)

  - Data warehousing applications

  - Distributed file systems

### Naming convention

For example: m5.2xlarge

- m: instance class
- 5: generation (AWS improves them over time)
- 2xlarge: size within the instance class

## Security

### Security Groups

- Security Groups are the fundamental of network security in AWS
- They control how traffic is allowed into or out of our EC2 Instances
- Security groups only contain allow rules
- Security groups rules can reference by IP or by security group
- Security groups are acting as a "firewall" on EC2 instances
- They regulate:
  - Access to ports
  - Authorized by IP ranges - IPv4 and IPv6
  - Control of inbound network (from other to the instance)
  - Control of outbound network (from the instance to other)

### Good to know

- Can be attached to multiple instances
- Locked down to a region / VPC combination (will introduce VPC later)
- Does live "outside" the EC2 - if traffic is blocked the EC2 instance won't see it
- It's good to maintain one separate security group for SSH access
- If your application is not accessible (time out), then it's a security group issue
- If your application gives a "connection refused" error, then it's an application error or it's not launched
- All inbound traffic is **blocked** by default
- All outbound traffic is **authorised** by default

### Classic ports to know

- 22 = SSH (Secure Shell) - log into a linux instance
- 21 = FTP (File Transfer Protocol) - upload files into a file share
- 22 = SFTP (Secure File Transfer Protocol) - upload files using SSH
- 80 = HTTP - access unsecured websites
- 443 = HTTPS - access secured websites
- 3389 = RDP (Remote desktop protocol) - log into a windows instance

## SSH to EC2

Command: `ssh ec2-user@xx.xx.xx.xx -i Yourkey.pem`

## EC2 Instance Roles

If you need to do something as the EC2 instance, make sure you assign roles to the instance. DO NOT use access key in the EC2 instance.

1. Select EC2 instance
2. In the Actions dropdown, find Security option
3. Find and access Modify IAM role
4. Search and assign desired role

## Handy tools:

- [ec2 instances info](https://instances.vantage.sh/)
