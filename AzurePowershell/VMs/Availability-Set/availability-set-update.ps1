# Created by: Fernando de Oliveira
# Configuring an availability set for an existing VM

$cloudServiceName = "myCloudServiceName"
$vmName = "myVMName"
$availabilitySetName = "myAvailabilitySetName"

Get-AzureVM -ServiceName $cloudServiceName -Name $vmName |
Set-AzureAvailabilitySet -AvailabilitySetName $availabilitySetName |
Update-AzureVM