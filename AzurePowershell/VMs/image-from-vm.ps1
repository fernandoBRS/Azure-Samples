# Getting a VM Image from an existing VM
# Created by Fernando de Oliveira

$cloudServiceName = "myCloudServiceName"
$vmName = "myVmName"
$state = "Specialized"

$imageName = "newImageName"
$imageLabel = "New Image from VM1"

Save-AzureVMImage -ServiceName $cloudServiceName -Name $vmName -OSState $state -NewImageName $imageName -NewImageLabel $imageLabel
