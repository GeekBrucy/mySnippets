# Scalability & High Availability

## Scalability

Scalability means that an application / system can handle greater loads by adapting

- 2 kinds of scalability:
  - Vertical Scalability: increasing the size of the instance
  - Horizontal Scalability (= elasticity): increasing the number of instances / systems for your application
- Scalability is linked but different to high availability

## High Availability

- High availability usually goes hand in hand with horizontal scaling
- High availability means running your application / system in at least 2 data centers (== availability zones)
- The goal of high availability is to survive a data center loss
- The high availability can be passive (for RDS multi AZ for example)
- The high availability can be active (for horizontal scaling)

## High Availability & Scalability for EC2

- Vertical Scaling: Increase instance size (= scale up/down)
  - From: t2.nano - 0.5G of RAM, 1 vCPU
  - To: u-12tbl.metal - 12.3TB of RAM, 448 vCPUs
- Horizontal Scaling: Increase number of instances (= scale out/in)
  - Auto scaling group
  - Load balancer
- High Availability: Run instances for the same application across multi AZ
  - Auto scaling group multi AZ
  - Load balancer multi AZ

# Elastic Load Balancer (ELB) Overview

- Load balances are servers that forward traffic to multiple servers (e.g. EC2 instances) downstream

## Why use a load balancer?

- Spread load across multiple downstream instances
- Expose a single point of access (DNS) to your application
- Seamlessly handle failures of downstream instances
- Do regular health checks to your instances
- Provide SSL termination (HTTPS) for your websites
- Enforce stickiness with cookies
- High availability across zones
- Separate public traffic from private traffic

## Why use an Elastic Load Balancer?

- An ELS is a managed load balancer
  - AWS guarantees that it will be working
  - AWS takes care of upgrades, maintenance, high availability
  - AWS provides only a few configuration knobs
- It costs less to setup your own load balancer but it will be a lot more effort on your end
- It is integrated with many AWS offerings / services
  - EC2, EC2 Auto Scaling Groups, Amazon ECS
  - AWS Certificate Manager (ACM), CloudWatch
  - Route 53, AWS WAF, AWS Global Accelerator

## Health Checks

- Health checks are crucial for Load Balancers
- They enable the load balancer to know if instances it forwards traffic to are available to reply to requests
- The health check is done on a port and a route (/health is common)
- If the response is not 200 (OK), then the instance is unhealthy

## 4 Types of load balancer on AWS

- Classic Load Balancer (v1 - old generation) - 2009 - CLB (Deprecated)
  - HTTP, HTTPS, TCP, SSL (secure TCP)
- Application Load Balancer (v2 - new generation) - 2016 - ALB
  - HTTP, HTTPS, WebSocket
- Network Load Balancer (v2 - new generation) - 2017 - NLB
  - TCP, TLS (secure TCP), UDP
- Gateway Load Balancer - 2020 - GWLB
  - Operates at Layer 3 (Network layer) - IP Protocol

It is recommended to use the newer generation load balancers as they provide more features

Some load balancers can be setup as internal (private) or external (public) ELBs

## Load Balancer Security Groups

- Load Balancer Security Group: Allow 0.0.0.0/0 for port 80 and 443 with TCP protocol
- Services behind the load balancer (for example, EC2): only allow the load balancer security group for the inbound policy

### Application Load Balancer (v2)

- Application load balancer is Layer 7 (HTTP)
- Load balancing to multiple HTTP applications across machines (target groups)
- Load balancing to multiple applications on the same machine (ex: containers)
- Support for HTTP/2 and WebSocket
- Support redirects (from HTTP to HTTPS for example)
- Routing tables to different target groups:
  - routing based on path in URL (example.com/users, example.com/posts)
  - routing based on hostname in URL (one.example.com, two.example.com)
  - routing based on Query String, Headers (example.com/users?id=123&order=false)
- ALB are a great fit for micro services & container-based application (example: Docker & Amazone ECS)
- Has a port mapping feature to redirect to a dynamic port in ECS
- In comparison, we'd need multiple Classic Load Balancer per application

#### Application Load Balancer (v2) - Target Groups

- EC2 instances (can be managed by an Auto Scaling Group) - HTTP
- ECS tasks (managed by ECS itself) - HTTP
- Lambda functions - HTTP request is translated into a JSON event
- IP Addresses - must be private IPs
- ALB can route to multiple target groups
- Health checks are at the target group level

### Network Load Balancer (v2)

- Network load balancers (Layer 4) allow to:
  - Forward TCP & UDP traffic to your instances
  - Handle millions of request per seconds
  - Less latency ~100ms (vs 400ms for ALB)
- NLB has **one static IP per AZ** and supports assigning Elastic IP (helpful for whitelisting specific IP)
- NLB are used for extreme performance, TCP or UDP traffic
- **NOT** included in Free Tier

#### Network Load Balancer (v2) - Target Groups

- EC2 instances
- IP Addresses - must be private IPs
- Application Load Balancer
- Health Checks support the TCP, HTTP and HTTPS protocols

### Gateway Load Balancer

- Deploy, scale and mange a fleet of 3rd party network virtual appliances in AWS
- Example: Firewalls, Intrusion Detection and Prevention Systems, Deep packet inspection systems, payload manipulation, ...
- Operates at Layer 3 (Network Layer) - IP Packets
- Combines the following functions:
  - Transparent Network Gateway - single entry / exit for all traffic
  - Load Balancer - distributes traffic to your virtual appliances
- Uses the GENEVE protocol on port 6081

#### Gateway Load Balancer - Target Groups

- EC2 instances
- IP Addresses - must be private IPs

## Sticky Sessions (Session Affinity)

It is possible to implement stickiness so that the same client is always redirected to the same instance behind a load balancer. (Client 1 will always be redirected to a specific instance)

- This works for CLB, ALB, NLB
- The "cookie" used for stickiness has an expiration date you control (NOTE: NLB works without cookies)
- Use case: make sure the user doesn't lose his their data
- Enabling stickiness may bring imbalance to the load over the backend EC2 instances

### Sticky Sessions - Cookie Names

- Application-based Cookies
  - Custom cookie
    - Generated by the target
    - Can include any custom attributes required by the application
    - Cookie name must be specified individually for each target group
    - Don't use AWSALB, AWSALBAPP, or AWSALBTG (reserved for use by the ELB)
  - Application cookie
    - Generated by the load balancer
    - Cookie name is AWSALBAPP
- Duration-based Cookies
  - Cookie generated by the load balancer
  - Cookie name is AWSALB for ALB, AWSELB for CLB

## Cross Zone Load Balancing

With Cross Zone Load Balancing, each load balancer instance distributes evenly across all registered instances in all AZ

- Application Load Balancer
  - Enabled by default (can be disabled at the Target Group level)
  - No charges for inter AZ data
- Network Load Balancer & Gateway Load Balancer
  - Disabled by default
  - You pay charges ($) for inter AZ data if enabled
- Classic Load Balancer
  - Disabled by default
  - No charges for inter AZ data if enabled

## SSL/TLS - Basics

- An SSL Certificate allows traffic between your clients and your load balancer to be encrypted in transit (in-flight encryption)
- SSL refers to Secure Sockets Layer, used to encrypt connections
- TLS refers to Transport Layer Security, which is a newer version
- Nowadays, TLS certificates are mainly used, but people still refer as SSL
- Public SSL certificates are issued by Certificate Authorities (CA)
  - Comodo, Symantec, GoDaddy, GlobalSign, Digicert, Letsencrypt, etc...
- SSL certificates have an expiration date (you set) and must be renewed

### Load Balancer - SSL Certificates

- The load balancer uses an X.509 certificate (SSL/TLS server certificate)
- You can manage certificates using ACM (AWS Certificate Manager)
- You can create upload your own certificates alternatively
- HTTPS listener:
  - You must specify a default certificate
  - You can add an optional list of certs to support multiple domains
  - Clients can use SNI (Server Name Indication) to specify the hostname they reach
  - Ability to specify a security policy to support older versions of SSL/TLS (legacy clients)

#### Server Name Indication (SNI)

- SNI solves the problem of loading multiple SSL certificates onto one web server (to serve multiple websites)
- It's a "newer" protocol, and requires the client to indicate the hostname of the target server in the initial SSL handshake
- The server will then find the correct certificate, or return the default one

NOTE: Only works for ALB & NLB (newer generation), CloudFront. (NOT for CLB)

### Balancer type and SSL Certificates

- CLB (v1)
  - Support only one SSL certificate
  - Must use multiple CLB for multiple hostname with multiple SSL certificates
- ALB (v2)
  - Supports multiple listeners with multiple SSL certificates
  - Users Server Name Indication (SNI) to make it work
- NLB (v2)
  - Supports multiple listeners with multiple SSL certificates
  - Uses Server Name Indication (SNI) to make it work

## Connection Draining

- Feature naming
  - Connection Draining - for CLB
  - Deregistration Delay - for ALB & NLB
- Time to complete "in-flight requests" while the instance is de-registering or unhealthy
- Stops sending new requests to the EC2 instance which is de-registering
- Between 1 to 3600 seconds (default: 300 seconds)
- Can be disabled (set value to 0)
- Set to a low value if your requests are short

## What's an Auto Scaling Group

- In real-life, the load on your websites and application can change
- In the cloud, you can create and get rid of servers very quickly
- The goal of an Auto Scaling Group (ASG) is to:
  - Scale out (add EC2 instances) to match an increased load
  - Scale in (remove EC2 instances) to match a decreased load
  - Ensure we have a minimum and a maximum number of ECC2 instances running
  - Automatically register new instances to a load balancer
  - Re-create an EC2 instance in case a previous one is terminated (ex: if unhealthy)
- ASG are free (you only pay for the underlying EC2 instances)

### Auto Scaling Group Attributes

- A Launch Template (older "Launch Configurations" are deprecated)
  - AMI + Instance Type
  - EC2 User Data
  - EBS Volumes
  - Security Groups
  - SSH Key Pair
  - IAM Roles for your EC2 Instances
  - Network + Subnets Information
  - Load Balancer Information
- Min Size / Max Size / Initial Capacity
- Scaling Policies

#### Auto Scaling Group - Scaling Policies

- Dynamic Scaling
  - Target Tracking Scaling
    - Simple to set-up
    - Example: I want the average ASG CPU to stay at around 40%
  - Simple / Step Scaling
    - When a CloudWatch alarm is triggered (example: CPU > 70%), then add 2 units
    - When a CloudWatch alarm is triggered (example: CPU < 30%>), then remove 1
  - Scheduled Scaling
    - Anticipate a scaling based on known usage patterns
    - Example: increase the min capacity to 10 at 5pm on Fridays
  - Predicative scaling: continuously forecast load and schedule scaling ahead
- Good metrics to scale on
  - CPUUtilization: Average CPU: utilization across your instances
  - RequestCountPerTarget: to make sure the number of requests per EC2 instances is stable
  - Average Network In/Out (if your application is network bound)
  - Any custom metric (that you push using CloudWatch)

#### Auto Scaling Group - Scaling Cooldowns

- After a scaling activity happens, you are in the cooldown period (default 300 seconds)
- During the cooldown period, the ASG will not launch or terminate additional instances (to allow for metrics to stabilize)
- Advice: Use a ready-to-use AMI to reduce configuration time in order to be serving request faster and reduce the cooldown period

### Auto Scaling - CloudWatch Alarms & Scaling

- It is possible to scale an ASG based onCloudWatch alarms
- An alarm monitors a metric (such as Average CPU, or a custom metric)
- Metrics such as Average CPU are computed for the overall ASG instances
- Based on the alarm:
  - We can create scale-out policies (increase the number of instances)
  - We can create scale-in policies (decrease the number of instances)

## Good to know

- Fixed hostname (xxx.region.elb.amazonaws.com)
- The application servers don't see the IP of the client directly
  - The true IP of the client is inserted in the header `X-Forwarded-For`
  - We can also get port (`X-Forwarded-Port`) and protocol (`X-Forwarded-Proto`)

## Tips

When testing the scaling policy, the stress tool is very handy. To install stress tool in Amazon Linux 2023 AMI, here are the steps (https://cloudkatha.com/how-to-install-stress-on-amazon-linux-2023/):

```bash
sudo dnf update

sudo dnf install stress -y

or

sudo dnf install stress-ng -y

stress

stress --cpu 4 --timeout 300
```
