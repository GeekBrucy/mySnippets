# In General

## AWS Regions

- AWS has **Regions** all around the world
- Names can be us-east-1, eu-west-3...
- A region is a **cluster of data centers**

### How to choose an AWS Region?

If you need to launch a new application, where should you do it?

Answer: It depends, please consider the following:

- **Compliance** with data governance and legal requirements: Data never leaves a region without your explicit permission.
- **Proximity** to customers: Reduced latency
- **Available services** within a Region: new services and new features aren't available in every Region
- **Pricing**: Pricing varies region to region and is transparent in the service pricing page.

## AWS Availability Zones

- Each region has many availability zones (usually 3, min is 3, max is 6).
- Each AZ is one or more discrete data centers with redundant power, networking and connectivity
- They are separate from each other, so that they're isolated from disasters
- They are connected with high bandwidth ultra-low latency networking

For example:

Sydney Region: ap-southeast-2 may have the following availability zones:

- ap-southeast-2a
- ap-southeast-2b
- ap-southeast-2c

## AWS Points of Presence (Edge Locations)

- Amazon has 400+ Points of Presence (400+ Edge Locations & 10+ Regional Caches) in 90+ cities across 40+ countries
- Content is delivered to end users with lower latency

## Tour of the AWS Console

### AWS has Global Services:

- Identity and Access Management (IAM)
- Route 53 (DNS service)
- CloudFront (Content Delivery Network)
- WAF (Web Application Firewall)

### Most AWS Services are Region-scoped:

- Amazon EC2 (Infrastructure as a Service)
- Elastic Beanstalk (Platform as a Service)
- Lambda (Function as a Service)
- Rekognition (Software as a Service)

### Region Table:

https://aws.amazon.com/about-aws/global-infrastructure/regional-product-services/
