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
