dotnet build -c release

$packageName = (Get-ChildItem -r -Path .\bin\release\*.nupkg| Select-Object FullName).FullName
dotnet nuget push "$packageName" --api-key "$env:NUGET_API_KEY" --source https://api.nuget.org/v3/index.json