# Attaching data disks to a VM
# Created by Fernando de Oliveira

$cloudService = "youCloudServiceName"
$vmName = "myVM"
$diskName = "myDiskName"

Get-AzureVM $cloudService -Name $vmName |
Add-AzureDataDisk -Import -DiskName $diskName -LUN 0 |
Update-AzureVM