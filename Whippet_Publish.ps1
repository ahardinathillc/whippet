$currentDirectory = $PWD.Path
$destinationDirectory = $PWD.Path + "/Publish"

$binToDelete = Get-Childitem ./ -Recurse | Where-Object {$_.Name -ilike "bin"}
$objToDelete = Get-Childitem ./ -Recurse | Where-Object {$_.Name -ilike "obj"}

Remove-Item -LiteralPath $destinationDirectory -Force -Recurse -Quet 

for($i = 0; $i -lt $binToDelete.Count; $i++){
    # calculate progress percentage
    $percentage = ($i + 1) / $binToDelete.Count * 100
    Write-Progress -Activity "Deleting bin Files" -Status "Deleting File #$($i+1)/$($binToDelete.Count)" -PercentComplete $percentage
    # delete file
    $binToDelete[$i] | Remove-Item -Force -Recurse
}

for($i = 0; $i -lt $objToDelete.Count; $i++){
    # calculate progress percentage
    $percentage = ($i + 1) / $objToDelete.Count * 100
    Write-Progress -Activity "Deleting obj Files" -Status "Deleting File #$($i+1)/$($objToDelete.Count)" -PercentComplete $percentage
    # delete file
    $objToDelete[$i] | Remove-Item -Force -Recurse
}

# All done
Write-Progress -Activity "Deleting Files" -Completed

dotnet new tool-manifest 
dotnet tool install Cake.Tool --version 4.0.0
dotnet cake

# Delete all PDB files in publish

$pdb = Get-Childitem -File -Path $destinationDirectory -Filter '*.pdb' -Recurse

for($i = 0; $i -lt $pdb.Count; $i++){
    # calculate progress percentage
    $percentage = ($i + 1) / $pdb.Count * 100
    Write-Progress -Activity "Deleting debug Files" -Status "Deleting File #$($i+1)/$($pdb.Count)" -PercentComplete $percentage
    # delete file
    $pdb[$i] | Remove-Item -Force -Recurse
}