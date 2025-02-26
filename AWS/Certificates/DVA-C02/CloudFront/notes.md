- For web distributions, to control how long your objects stay in a CloudFront cache before CloudFront forwards another request to your origin, you can:
  - Configure your **origin to add a Cache-Control** or an **Expires header field to each object**.
  - Specify a value for **Minimum TTL in CloudFront cache behaviors**.
    - Use the default value of 24 hours.
  - [Request and response behavior for Amazon S3 origins](https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/RequestAndResponseBehaviorS3Origin.html)

# CloudFront function

* lightweight functions in JS for high-scale, latency-sensitive CDN customizations
* Manipulate the request and responses and perform authentication and authorization, generate HTTP responses at the edge

# Lambda@Edge
# CloudFront-Viewer-Country

* use the value of the CloudFront-Viewer-Country header to update the S3 bucket domain name to a bucket in a Region that is closer to the viewer

# Viewer request event

* The function executes when CloudFront receives a request from a viewer before it checks to see whether the requested object is in the CloudFront cache.

# Origin request event

* The function executes only when CloudFront forwards a request to your origin. When the requested object is in the CloudFront cache, the function doesn‘t execute.

# Failover

* CloudFront routes all incoming requests to the primary origin, even when a previous request failed over to the secondary origin

* CloudFront fails over to the secondary origin only when the HTTP method of the viewer request is GET, HEAD or OPTIONS

https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/high_availability_origin_failover.html