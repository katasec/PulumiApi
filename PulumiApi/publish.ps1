
# Remove any existing packages
$packageName = (Get-ChildItem -r -Path .\bin\release\*.nupkg| Select-Object FullName).FullName
$packageName | % { 
	if ($_ -ne $null) {
		rm $_ 
	}
}

# Publish new package
dotnet publish -c release

# Find package Full Name
$packageName = (Get-ChildItem -r -Path .\bin\release\*.nupkg| Select-Object FullName).FullName

# Publish it
dotnet nuget push "$packageName" --api-key "$env:NUGET_API_KEY" --source https://api.nuget.org/v3/index.json