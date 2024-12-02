- In API Gateway, a deployment is represented by a Deployment resource. It is like an executable of an API represented by a RestApi resource. For the client to call your API, you must create a deployment and associate a stage to it. A stage is represented by a Stage resource and represents a snapshot of the API, including methods, integrations, models, mapping templates, Lambda authorizers (formerly known as custom authorizers), etc

- For example, with DynamoDB as the backend, the API developer sets up the integration request to forward the incoming method request to the chosen backend. The setup includes specifications of an appropriate DynamoDB action, required IAM role and policies, and required input data transformation. The backend returns the result to API Gateway as an integration response. To route the integration response to an appropriate method response (of a given HTTP status code) to the client, you can configure the integration response to map required response parameters from integration to method

- To deploy an API, you create an API deployment and associate it with a stage. Each stage is a snapshot of the API and is made available for the client to call. Every time you update an API, which includes modification of methods, integrations, authorizers, and anything else other than stage settings, you must redeploy the API to an existing stage or to a new stage.

- Configure usage plan

  1. Create one or more APIs, configure the methods to require an API key, and deploy the APIs to stages
  2. Generate or import API keys to distribute to application developers (your customers) who will be using your API.
  3. Create the usage plan with the desired throttle and quota limits
  4. Associate API stages and API keys with the usage plan.

  - Callers of the API must supply an assigned API key in the x-api-key header in requests to the API

- Security

  - IAM
    - Great for users / roles already within your AWS account + resource policy for cross account
    - Handle authentication + authorization
    - Leverages Signature v4
  - Custom Authorizer:
    - Great for 3rd party tokens
    - Very flexible in terms of what IAM policy is returned
    - Handle Authentication verification + Authorization in the Lambda function
    - Pay per lambda invocation, results are cached
  - Cognito User pool:
    - You manage your own user pool (can be backed by Facebook, Google login etc...)
    - No need to write any custom code
    - Must implement authorization in the backend

- http api vs rest api
  - https://docs.aws.amazon.com/apigateway/latest/developerguide/http-api-vs-rest.html
