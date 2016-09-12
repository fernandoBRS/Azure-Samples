# Creating a Data Disk from a VHD
# Created by Fernando de Oliveira

$diskName = "myDiskName"
$vhdLocation = "http://storageAccountName.blob.core.windows.net/vhd/myNewVhd.vhd"
$diskLabel = "OS Disk - Windows Server 2012 R2"

# For Windows: -OS "Windows"
# For Linux: -OS "Linux"

Add-AzureDisk -DiskName $diskName -MediaLocation $vhdLocation -Label $diskLabel