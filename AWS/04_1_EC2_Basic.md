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

## Handy tools:

- [ec2 instances info](https://instances.vantage.sh/)
