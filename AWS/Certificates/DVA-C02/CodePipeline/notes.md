- You might want to create a pipeline that uses resources created or managed by another AWS account. For example, you might want to use one account for your pipeline and another for your AWS CodeDeploy resources. To do so, you must create a AWS Key Management Service (AWS KMS) key to use, add the key to the pipeline, and set up account policies and roles to enable cross-account access. (Synergy: CodeDeploy)

- To monitor pipeline state change, create an Amazon CloudWatch Events rule that uses CodePipeline as an event source
