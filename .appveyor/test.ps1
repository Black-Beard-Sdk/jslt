

# Variables to initialize in appveyor
# ARCH                     : Architecture for linux builds

# Variables to manage initialize in this script
$imageName = "blackbeardteam/parrot";    # name of the image
$taggedimage = $imageName + ':' + $env:APPVEYOR_BUILD_VERSION
$taggedimagelatest = $imageName + ':latest'

# Script begin
$containerName = "parrot__test";
Write-Host Starting test

if ($env:ARCH -ne "amd64") {
  Write-Host "Arch $env:ARCH detected. Skip testing."
  exit 0
}

$ErrorActionPreference = 'SilentlyContinue';
docker kill $containerName
docker rm -f $containerName

$ErrorActionPreference = 'Stop';
Write-Host Starting container
docker run --name $containerName -d $taggedimage
docker run --name $containerName -d $taggedimage
Start-Sleep 10

$ErrorActionPreference = 'SilentlyContinue';

docker logs $containerName
docker kill $containerName
docker rm -f $containerName