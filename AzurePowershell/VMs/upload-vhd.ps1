# Uploading a VM on-premises to Azure as VHD
# Created by Fernando de Oliveira

# Two ways of using publish settings file:
# 1) Using Azure AD as authentication (Add-AzureAccount).
# 2) Download the publish settings file (Get-AzurePublishSettingsFile).

# Make sure you created a container for VHDs in Blob storage
$vhdDestination = "http://storageAccountName.blob.core.windows.net/vhd/myNewVhd.vhd"
$vhdLocalFilePath = "C:\source\vhd\myVhd.vhd"


# Get-AzurePublishSettingsFile
# Import-AzurePublishSettingsFile "filePath\fileName.publishsettings"
# Set-AzureSubscription "subscriptionName" -CurrentStorageAccountName "storageAccountName"

Add-AzureAccount
Set-AzureSubscription "subscriptionName" -CurrentStorageAccountName "storageAccountName"

# Repeat it for all VHDs you need to upload
Add-AzureVhd -Destination $vhdDestination -LocalFilePath $vhdLocalFilePath

