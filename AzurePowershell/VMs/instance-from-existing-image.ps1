# Creating a VM instance from an existing VM Image
# Created by Fernando de Oliveira

$cloudServiceName = "myCloudServiceName"
$vmName = "myVmName"
$location = "West US"
$instanceSize = "Basic_A0"
$username = "myUsername"
$password = "myPassword"

# If you are creating the instance from a Linux VM:
# -Linux instead of -Windows
# -LinuxUser instead of -AdminUsername

New-AzureQuickVM -Windows -Location $location -ServiceName $cloudServiceName |
-Name $vmName -InstanceSize $instanceSize -ImageName -AdminUsername $username -Password $password -WaitForBoot