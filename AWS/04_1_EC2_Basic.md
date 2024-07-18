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
