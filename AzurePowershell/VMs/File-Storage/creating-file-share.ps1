# Created by: Fernando de Oliveira
# Creating a file share using ile Storage

# Storage account info
$storageAccountName = "yourStorageAccountName"
$storageAccountKey = "yourStorageAccountKey"

# File share
$fileShareName = "yourFileShareName"

# First you need to create a context that will encapsulate the storage account and key.
# After that, you create a file share with the storage account info encapsulated.

$context = New-AzureStorageContext $storageAccountName $storageAccountKey
New-AzureStorageShare $fileShareName Context $context