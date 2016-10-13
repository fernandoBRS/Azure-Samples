# Created by: Fernando de Oliveira
# Uploading and downloading files from Azure File Storage

$fileShareName = "myFileShareName"
$filePath = "testdir"
$file = "D:\upload\testfile.txt"

# Uploading a file 
Set-AzureStorageFileContent -ShareName $fileShareName -Path $filePath -Source $file

# Downloading a file
$fileToDownload = "testdir/testfile.txt"
$fileDestination = "D:\download"

Get-AzureStorageFileContent -ShareName $fileShareName -Path $fileToDownload -Destination $fileDestination