$currentDirectory = $PWD.Path
$destinationDirectory = "/Publish"

dotnet new tool-manifest 
dotnet tool install Cake.Tool --version 4.0.0

$destinationDirectory = $currentDirectory + $destinationDirectory

dotnet cake
New-Item -ItemType Directory -Force -Path $destinationDirectory

Get-Childitem -Path ./ -Recurse | Where-Object {$_.Name -ilike "bin"} | ForEach-Object { Copy-Item $_.Fullname $destinationDirectory -Verbose -Force }

Write-Output $destinationDirectory