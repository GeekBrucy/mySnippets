# create an s3 bucket
aws s3 mb s3://bz-code-sam

# package cloudformation
aws cloudformation package --s3-bucket bz-code-sam --template-file template.yaml --output-template-file gen/template-generated.yaml

# sam package ...   <--- short hand for aws cloudformation

# deploy
aws cloudformation deploy --template-file gen/template-generated.yaml --stack-name hello-world-sam --capabilities CAPABILITY_IAM
