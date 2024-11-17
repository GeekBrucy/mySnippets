- Each time you upload a new version of your application with the Elastic Beanstalk console or the EB CLI, Elastic Beanstalk creates an application version. If you don’t delete versions that you no longer use, you will eventually reach the application version limit and be unable to create new versions of that application. You can avoid hitting the limit by applying an application version lifecycle policy to your applications. A lifecycle policy tells Elastic Beanstalk to delete application versions that are old, or to delete application versions when the total number of versions for an application exceeds a specified number.

- You can now use an **immutable deployment** policy when updating your application or environment configuration on Elastic Beanstalk. This policy is well suited for updates in production environments where you want to minimize downtime and reduce the risk from failed deployments. It ensures that the impact of a failed deployment is limited to a single instance and allows your application to serve traffic at full capacity throughout the update.

- You can now also use a **rolling with additional batch** policy when updating your application. This policy ensures that the impact of a failed deployment is limited to a single batch of instances and allows your application to serve traffic at full capacity throughout the update.

- When you use the AWS Elastic Beanstalk console to deploy a new application or an application version, you’ll need to upload a source bundle. Your source bundle must meet the following requirements:

  - Consist of a single ZIP file or WAR file (you can include multiple WAR files inside your ZIP file)
  - Not exceed 512 MB
  - Not include a parent folder or top-level directory (subdirectories are fine)

- If you want to deploy a worker application that processes periodic background tasks, your application source bundle must also include a cron.yaml file. For more information, see Periodic Tasks.

- Elastic Beanstalk supports two methods of saving configuration option settings. Configuration files in YAML or JSON format can be included in your application’s source code in a directory named .ebextensions and deployed as part of your application source bundle. You create and manage configuration files locally.
