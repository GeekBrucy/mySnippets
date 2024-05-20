# dotnet commands:

## Add projects to solution

`dotnet sln add .\YourProject\YourProject.csproj`

Why do we add `sln` file?

- restoring/building all project
- run from project (`dotnet run --project YourProject`)

## Add reference to project

`dotnet add Target/Target.csproj reference .\Source\Source.csproj`

The command above means add `Source` project reference to `Target` project.

Alternatively, cd to the target directory, and do
`dotnet add reference DesiredProject/DesiredProject.csproj`

## Run a project at solution root level

`dotnet run --project YourProjectName`
