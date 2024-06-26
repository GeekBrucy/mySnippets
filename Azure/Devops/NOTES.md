# Logging commands (##vso)

https://learn.microsoft.com/en-us/azure/devops/pipelines/scripts/logging-commands?view=azure-devops&tabs=powershell

# Set variables in scripts

https://learn.microsoft.com/en-us/azure/devops/pipelines/process/set-variables-scripts?view=azure-devops&tabs=bash

# Deployment Tips

## Check if file exists in build

```bash
$fileExists= Test-Path -Path "$(System.DefaultWorkingDirectory)/_ArtifactName/output/Path/file"
Write-Output "##vso[task.setvariable variable=fileExists]$fileExists"
```

# Run tests in pipeline

https://learn.microsoft.com/en-us/azure/devops/pipelines/ecosystems/dotnet-core?view=azure-devops&tabs=yaml-editor#run-your-tests

```yaml
steps:
  # ...
  # do this after other tasks such as building
  - task: DotNetCoreCLI@2
    inputs:
      command: test
      projects: "**/*Tests/*.csproj"
      arguments: "--configuration $(buildConfiguration)"
```

```yaml
steps:
  # ...
  # do this after your tests have run
  - script: dotnet test <test-project> --logger trx
  - task: PublishTestResults@2
    condition: succeededOrFailed()
    inputs:
      testRunner: VSTest
      testResultsFiles: "**/*.trx"
```
