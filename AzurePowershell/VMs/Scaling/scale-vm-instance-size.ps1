# Created by: Fernando de Oliveira
# Scaling up and down a VM instance
# Information about VM sizes: https://azure.microsoft.com/pt-br/documentation/articles/cloud-services-sizes-specs/

$cloudServiceName = "myCloudService"
$vmName = "myVMName"
$vmSize = "Standard_D2"

Get-AzureVM -ServiceName $ServiceName -Name $vmName |
Set-AzureVMSize -InstanceSize $vmSize |
Update-AzureVM