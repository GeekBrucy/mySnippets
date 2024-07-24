# Instantiating Applications quickly

- When launching a full stack (EC2, EBS, RDS), it can take time to:
  - Install applications
  - Insert initial (or recovery) data
  - Configure everything
  - Launch the application
- We can take advantage of the cloud to speed that up!

## EC2 Instances:

- Use a Golden AMI: Install your applications, OS dependencies etc.. beforehand and launch your EC2 instance from the Golden AMI
- Bootstrap using User Data: For dynamic configuration, use User Data scripts
- Hybrid: mix Golden AMI and User Data (Elastic Beanstalk)

## RDS Databases:

- Restore from a snapshot: the database will have schemas and data ready!

## EBS Volumes:

- Restore from a snapshot: the disk will already be formatted and have data!
