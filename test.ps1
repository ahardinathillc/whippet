$currentDirectory = $PWD.Path
$destinationDirectory = "/Publish"

$destinationDirectory = $currentDirectory + $destinationDirectory

New-Item -ItemType Directory -Force -Path $destinationDirectory

Copy-Item -Path $PWD.Path -Filter "*.dll" -Recurse -Destination $destinationDirectory -Container -Verbose