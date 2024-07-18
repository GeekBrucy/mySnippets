# Objective

- Launching virtual server using AWS console
- Get a first high-level approach to the various parameters
- See the web server is launched using EC2 user data
- Learn how to start / stop / terminate the instance

## Launching virtual server using AWS console

1. Log in as IAM user
2. Search `EC2` and access the service
3. It will bring up the EC2 dashboard
4. Find and access `Instances` from the side menu bar
5. Click `Launch instances`
6. Added tag (optional)
7. Choose proper machine image
8. Choose proper instance type
9. Click `Create key pair` under key pair section

   9.1 Provide key pair name

   9.2 select `RSA` as the key pair type

   9.3 select `.pem` (select `.ppk` for windows 7/8 or below)

   9.4 Click create button. This will download the key pair

10. Leave the network settings as is except, tick the `Allow HTTP traffic from the internet`
11. Leave the storage section as is
12. Add following User data to the `User data` section under the `Advanced details` section

```bash
#!/bin/bash
# Use this for your user data (script from top to bottom)
# install httpd (Linux 2 version)
yum update -y
yum install -y httpd
systemctl start httpd
systemctl enable httpd
echo "<h1>Hello World from $(hostname -f)</h1>" > /var/www/html/index.html
```

13. Make sure the instance is set to 1 in the summary section
14. Click `Launch instance`

## Notes

- If an EC2 instance is stopped and started again, it may be allocated a new public ip address
