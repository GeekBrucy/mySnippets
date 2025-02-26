# ECS Terminologies
- Service
- Cluster
- Container
- host port: the port number on the container instance to reserve for your container
- container port: the port number on the container that is bound to the user-specified or automatically assigned host port

# Tips
- Use advanced container definition parameters and define environment variables under the environment parameter within the task definition

- If web service run on port 80, to ensure no port conflicts: Specify port 80 for the container port and port 0 for the host port