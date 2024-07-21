# Private vs Public IP (IPv4)

## Public IP:

- Public IP means the machine can be identified on the internet
- Must be unique across the whole web (not two machines can have the same public IP)
- Can be geo-located easily

## Private IP:

- Private IP means the machine can only be identified on a private network
- The IP must be unique across the private network
- BUT two different private networks (two companies) can have the same IPs
- Machines connect to WWW using a NAT + internet gateway (a proxy)
- Only a specified range of IPs can be used as private IP

## EC2

- By default, your EC2 machine comes with:
  - A private IP for the internal AWS network
  - A public IP, for the WWW
- When we are doing SSH into our EC2 machines:
  - We can't use a private IP, because we are not in the same network (unless you are using VPN)
  - We can only use the public IP
- If your machine is stopped and then started, the public IP can change

# Elastic IPs

- When you stop and then start an EC2 instance, it can change its public IP
- If you need to have a fixed public IP for your instance, you need an Elastic IP
- An Elastic IP is a public IPv4 IP you own as long as you don't delete its
- You can attach it to one instance at a time
- With an Elastic IP address, you can mask the failure of an instance or software by rapidly remapping the address to another instance in your account
- You can only have 5 Elastic IP in your account (you can ask AWS to increase that)
- Overall, try to avoid using Elastic IP:
  - They often reflect poor architectural decisions
  - Instead, use a random public IP and register a DNS name to it
  - Or, as we'll see later, use a Load Balancer and don't use a public IP

# Placement Groups

- Sometimes you want to control over the EC2 instance placement strategy
- That strategy can be defined using placement groups
- When you create a placement group, you specify one of the following strategies for the group:
  - Cluster: clusters instances into a low-latency group in a single availability zone
  - Spread: spreads instances across underlying hardware (max 7 instances per group per AZ) - critical applications
  - Partition: spreads instances across many different partitions (which rely on different sets of racks) within an AZ. Scales to 100s of EC2 instances per group (Hadoop, Cassandra, Kafka)

# Elastic Network Interfaces (ENI)

- Logical component in a VPC that represents a virtual network card
- The ENI can have the following attributes:
  - Primary private IPv4, one or more secondary IPv4
  - One Elastic IP (IPv4) per private IPv4
  - One public IPv4
  - One or more security groups
  - A MAC address
- You can create ENI independently and attach them on the fly (move them) on EC2 instances for failover
- Bound to a specific AZ

Extra Reading: https://aws.amazon.com/blogs/aws/new-elastic-network-interfaces-in-the-virtual-private-cloud/

# EC2 Hibernate

- We know we can stop, terminate instances
  - Stop - the data on disk (EBS) is kept intact in the next start
  - Terminate - any EBS volumes (root) also set-up to be destroyed is lost
- On start, the following happens:
  - First start: the OS boots &the EC2 User Data script is run
  - Following starts: the OS boots up
  - Then your application starts, caches get warmed up, and that can take time
- Hibernate:
  - The in-memory (RAM) state is preserved
  - The instance boot is much faster (the OS is not stopped / restarted)
  - Under the hood: the RAM state is written to a file in the root EBS volume
  - The root EBS volume must be encrypted
- Use cases:
  - Long-running processing
  - Saving the RAM state
  - Services that take time to initialize

## Good to know

- Supported Instance Families - C3, C4, C5, I3, M3, M4, R3, R4, T2, T3...
- Instance RAM Size - must be less than 150GB
- Instance Size - not supported for bare metal instances
- AMI - Amazon Linux 2, Linux AMI, Ubuntu, RHEL, CentOS & Windows...
- Root Volume - must be EBS, encrypted, not instance store, and large enough to contain the RAM that you dump into it
- Available for On-Demand, Reserved and Spot Instances
- An instance can NOT be hibernated more than 60 days
