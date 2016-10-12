# Created by : Fernando de Oliveira
# Configuring an availability set for a VM during creation

$cloudServiceName = "myCloudServiceName"

$vmName = "myVMName"
$vmSize = "Standard_D2"
$vmImageName = "myImageName"
$availabilitySetName = "myAvailabilitySetName"

$userName = "myUserName"
$password = "myPassword"

New-AzureMConfig -Name $vmName -InstanceSize $vmSize -ImageName $vmImageName -AvailabilitySetName $AvailabilitySetName |
Add-AzureProvisioningConfig -Windows -AdminUsername $userName -Password $password |
New-AzureVM -ServiceName $cloudServiceName

# Starting the VM
Start-AzureVM -ServiceName $cloudServiceName -Name $vmName