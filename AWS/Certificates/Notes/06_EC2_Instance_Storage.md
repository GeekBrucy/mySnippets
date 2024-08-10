# EC2 Instance Storage

## EBS Volume

- An EBS (Elastic Block Store) Volume is a network drive you can attach to your instances while they run
  - It uses the network to communicate the instance, which means there might be a bit of latency
  - It can be detached from an EC2 instance and attached to another one quickly
- It allows your instances to persist data, even after their termination
- They can only be mounted to one instance at a time (at the Certified Cloud Practitioner level)
- They are bound to a specific availability zone
  - To move a volume across, you first need to snapshot it
- Have a provisioned capacity (size in GBs, and IOPS)
  - You get billed for all the provisioned capacity
  - You can increase the capacity of the drive over time

Analogy: Think of them as a "network USB stick"

Free tier: 30 GB of free EBS storage of type General Purpose (SSD) or Magnetic per month

### Delete on termination attribute

- Controls the EBS behavior when an EC2 instance terminates
- Use case: preserve root volume when instance is terminated

### EBS Volume Types

[Official Doc](https://docs.aws.amazon.com/ebs/latest/userguide/ebs-volume-types.html)

- EBS Volumes come in 6 types
  - gp2 / gp3 (SSD): General purpose SSD volume that balances price and performance for a wide variety of workloads
  - io1 / io2 Block Express (SSD): Highest-performance SSD volume for mission-critical low-latency or high-throughput workloads
  - st 1 (HDD): Low cost HDD volume designed for frequently accessed, throughput-intensive workloads
  - sc 1 (HDD): Lowest cost HDD volume designed for less frequently accessed workloads
- EBS Volumes are characterized in Size | Throughput | IOPS (I/O Ops Per Sec)
- **Only gp2 / gp3 and io1/io2 Block Express** can be used as boot volumes

#### EBS Volume Types Use Cases - General Purpose SSD (gp2 / gp3)

- Cost effective storage, low-latency
- System boot volumes, Virtual desktops, Development and test environments
- 1 GB - 16 TB
- gp3:
  - Baseline of 3,000 IOPS and throughput of 125 mb/s
  - Can increase IOPS up to 16,000 and throughput up to 1000 mb/s independently
- gp2:
  - Small gp2 volumes can burst IOPS to 3,000
  - Size of the volume and IOPS are linked, max IOPS is 16,000
  - 3 IOPS per GB, means that 5,334 GB we are at the max IOPS

#### EBS Volume Types Use Cases - Provisioned IOPS (PIOPS) SSD (io1 / io2)

- Critical business applications with sustained IOPS performance
- Or applications that need more than 16,000 IOPS
- Great for databases workloads (sensitive to storage performance and consistency)
- io1 (4 GB - 16 TB):
  - Max PIOPS: 64,000 for Nitro EC2 instances & 32,000 for other
  - Can increase PIOPS independently from storage size
- io2 Block Express (4 GB - 64 TB):
  - Sub-millisecond latency
  - Max PIOPS: 256,000 with an IOPS:GB ratio of 1,000:1
- Supports EBS Multi-attach

#### EBS Volume Types Use Cases - Hard Disk Drives (HDD) (st1 / sc1)

- Cannot be a boot volume
- 125 GB to 16 TB
- Throughput Optimized HDD (st1)
  - Big Data, Data Warehouses, Log Processing
  - Max throughput 500 MB/s - max IOPS 500
- Cold HDD (sc1)
  - For data that is infrequently accessed
  - Scenarios where lowest cost is important
  - Max throughput 250 MB/s - max IOPS 250

## EBS Snapshots

- Make a backup (snapshot) of your EBS volume at a point in time
- Not necessary to detach volume to do snapshot, but recommended
- Can copy snapshots across AZ or Region

### EBS Snapshots Features

- EBS Snapshot Archive
  - Move a snapshot to an "archive tier" that is 75% cheaper
  - Takes within 24 to 72 hours for restoring the archive
- Recycle Bin for EBS snapshots
  - Setup rules to retain deleted snapshots so you can recover them after an accidental deletion
  - Specify retention (from 1 day to 1 year)
- Fast snapshot restore (FSR)
  - Force full initialization of snapshot to have no latency on the first use ($$$)

## EBS Multi-Attach - io1 / io2 family

This feature is only available from within a specified availability zone

- Attach the same EBS volume to multiple EC2 instances in the same AZ
- Each instance has full read & write permissions to the high-performance volume
- Use case:
  - Achieve higher application availability in clustered linux applications (ex. Teradata)
  - Applications must manage concurrent write operations
- Up to 16 EC2 Instances at a time
- Must use a file system that's cluster-aware (not XFS, EXT4, etc...)

## EBS Encryption

- When you create an encrypted EBS volume, you get the following:
  - Data at rest is encrypted inside the volume
  - All the data in flight moving between the instance and the volume is encrypted
  - All snapshots are encrypted
  - All volumes created from the snapshot are encrypted
- Encryption and decryption are handled transparently (you have nothing to do, it's all handled by EC2 and EBS behind the scenes)
- Encryption has a minimal impact on latency
- EBS Encryption leverages keys from KMS (AES-256)
- Copying an unencrypted snapshot allows encryption
- Snapshots of encrypted volumes are encrypted

### Encryption: encrypt an unencrypted EBS volume

- Create an EBS snapshot of the volume
- Encrypt the EBS snapshot (using copy)
- Create new EBS volume from the snapshot (the volume will also be encrypted)
- Now you can attach the encrypted volume to the original instance

## AMI Overview

- AMI = Amazon Machine Image
- AMI are a customization of an EC2 instance
  - You add your own software, configuration, operating system, monitoring...
  - Faster boot / configuration time because all your software is pre-packaged
- AMI are built for a specific region (and can be copied across regions)
- You can launch EC2 instances from:
  - A public AMI: AWS provided
  - Your own AMI: you make and maintain them yourself
  - An AWS Marketplace AMI: an AMI someone else made (and potentially sells)

### AMI Process (from an EC2 instance)

- Start an EC2 instance and customize it
- Stop the instance (for data integrity)
- Build an AMI - this will also create EBS snapshots
- Launch instances from other AMIs

## EC2 Instance Store

EBS volumes are network drives with good but "limited" performance. If you need a high-performance hardware disk, use **EC2 Instance Store**

- Better I/O performance
- EC2 Instance Store lose their storage if they're stopped (ephemeral)
- Good for buffer / cache / scratch data / temporary content
- Risk of data loss if hardware fails
- Backups and Replication are your responsibility

## EFS - Elastic File System

- Managed NFS (Network File System) that can be mounted on many EC2
- EFS works with EC2 instances in multi-AZ
- Highly available, scalable, expensive ( 3 \* gp2), pay per use
- Use cases: content management, web serving, data sharing, Wordpress
- Uses NFSv4.1 protocol
- Uses security group to control access to EFS
- Only compatible with Linux based AMI (not Windows)
- Encryption at rest using KMS
- POSIX file system (~Linux) that has a standard file API
- File system scales automatically, pay-per-use, no capacity planning

### EFS Performance

- EFS Scale
  - 1000s of concurrent NFS clients, 10 GB+/s throughput
  - Grow to Petabyte-scale network file system, automatically
- Performance Mode (set at EFS creation time)
  - General Purpose (default) - latency-sensitive use cases (web server, CMS, etc...)
  - Max I/O - higher latency, throughput, highly parallel (big data, media processing)
- Throughput Mode
  - Bursting - 1 TB = 50 MB/s + burst of upt to 100 MB/s
  - Provisioned - set your throughput regardless of storage size, ex: 1 GB/s for 1 TB storage
  - Elastic - automatically scales throughput up or down based on your workloads
    - Up to 3 GB/s for reads and 1 GB/s for writes
    - Used for unpredicatable workloads

### EFS Storage Classes

- Storage Tiers (lifecycle management feature - move file after N days)
  - Standard: for frequently accessed files
  - Infrequent access (EFS-IA): cost to retrieve files, lower price to store
  - Archive: rarely accessed dta (few times each year), 50% cheaper
- Availability and durability
  - Standard: Multi-AZ, great for prod
  - One Zone: One AZ, great for dev, backup enabled by default, compatible with IA (EFS One Zone-IA)

### Mounting EFS to EC2 Issue

It looks like when mounting EFS to EC2 during EC2 creation is having issues. During the process, it will generate 2 security groups: `instance-sg-n` and `efs-sg-n`. The `efs-sg-n` will be automatically added to the EFS instance, and this security group contains the inbound rules that allow NFS protocol. However, the `instance-sg-n` is created successfully but it is never added to the EC2 instance which cause the mount failure, because `instance-sg-n` contains the outbound rule that allow the traffic to `efs-sg-n`. This `instance-sg-n` will need to be added manually and then reboot the EC2

## EBS vs EFS

### EBS volumes

- One instance (except multi-attach io1/io2)
- are locked at the AZ level
- gp2: IO increases if the disk size increases
- gp3 & io1: can increase IO independently
- To migrate an EBS volume across AZ
  - Take a snapshot
  - Restore the snapshot to another AZ
  - EBS backups use IO and you shouldn't run them while your application is handling a lot of traffic
- Root EBS volumes of instances get terminated by default if the EC2 instance gets terminated (you can disable that)

### EFS

- Mounting 100s of instances across AZ
- EFS share websites files (WordPress)
- Only for Linux Instances (POSIX)
- EFS has a higher price point than EBS
- Can leverage Storage Tiers for cost savings

Remember: EFS vs EBS vs Instance store
