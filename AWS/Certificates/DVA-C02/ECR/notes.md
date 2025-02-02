# Amazon ECR
* ECR = Elastic Container Registry
* Store and manage Docker images on AWS
* Private and Public repository (Amazon ECR Public Gallery https://gallery.ecr.aws)
* Fully integrated with ECS, backed by Amazon S3
* Access is controlled through IAM (permission errors => policy)
* Supports image vulnerability scanning, versioning, image tags, image lifecycle, …

## Using AWS CLI
### Login Command

#### AWS CLI v2

```bash
aws ecr get-login-password --region region | docker login --username AWS
--password-stdin aws_account_id.dkr.ecr.region.amazonaws.com
```

#### Docker Commands
* Push
```bash
docker push aws_account_id.dkr.ecr.region.amazonaws.com/demo:latest
```
* Pull
```bash
docker pull aws_account_id.dkr.ecr.region.amazonaws.com/demo:latest
```
* In case an EC2 instance (or you) can’t pull a Docker image, check IAM
permissions