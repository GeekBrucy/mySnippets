# ALB Authentication
* **Application Load Balancer** can be used to securely **authenticate** users for accessing your applications. This enables you to offload the work of authenticating users to your load balancer so that your applications can focus on their business logic. You can use Cognito User Pools to authenticate users through well-known social IdPs, such as Amazon, Facebook, or Google, through the user pools supported by Amazon Cognito or through corporate identities, using SAML, LDAP, or Microsoft AD, through the user pools supported by Amazon Cognito. You configure user authentication by creating an authenticate action for one or more listener rules. The authenticate-cognito and authenticate-oidc action types are supported only with HTTPS listeners.

https://docs.aws.amazon.com/elasticloadbalancing/latest/application/listener-authenticate-users.html

# Take the high CPU load off the web servers (HTTPS)
* Configure an SSL/TLS certificate on an Application Load Balancer via AWS Certificate Manager (ACM)
* Create an HTTPS listener on the Application Load Balancer with SSL termination