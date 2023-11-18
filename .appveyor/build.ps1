

# https://stefanscherer.github.io/use-appveyor-to-build-multi-arch-docker-image/
# https://github.com/3shape/containerized-structure-test

# Variables to manage initialize in this script
$imageName = "blackbeardteam/bash_jslt";    # name of the image
$taggedimage = $imageName + ':' + $env:APPVEYOR_BUILD_VERSION
$taggedimagelatest = $imageName + ':latest'

# Script begin
$ErrorActionPreference = 'Stop';

Write-Host Starting build $taggedimage;

Write-Host setting working directory to $pwd;

$os = If ($isWindows) {'Windows'} Else {'Ubuntu'}
docker info

Write-Host docker build --tag $taggedimagelatest --file "dockerfile.${os}" $pwd
docker build --tag $taggedimagelatest --file "Dockerfile.${os}" .
Write-Host image $taggedimagelatest is generated

Write-Host retag $taggedimagelatest to $taggedimage
docker tag $taggedimagelatest $taggedimage

Write-Host build ended

docker images

Set-Location ..