- The `AppSpec` file allows a developer to specify scripts to be run at different lifecycle hooks. The BeforeAllowTraffic lifecycle event occurs before the updated task set is moved to the target group that is receiving live traffic. So, any validation before production deployment should be configured at this lifecycle event. The listener is configured at the ALB level, not at the deployment group.

- **In-place** deployment type can NOT be used for Lambda and ECS

- CodeDeploy lifecycle:

- Valid Lambda lifecycle hook
  - BeforeAllowTraffic > AfterAllowTraffic
  - ...
- Valid EC2 lifecycle hook
  - BeforeInstall > AfterInstall > ApplicationStart > ValidateService
  - more
- Valid ECS lifecycle hook
  - BeforeInstall > AfterInstall > AfterAllowTestTraffic > BeforeAllowTraffic > AfterAllowTraffic
  - ...