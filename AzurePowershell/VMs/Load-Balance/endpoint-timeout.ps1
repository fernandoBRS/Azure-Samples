# Created by: Fernando de Oliveira
# Configuring idle timeout for a VM endpoint
# Note: Timeout must be defined only during endpoint creation

$cloudServiceName = "myCloudService"
$vmName = "myVMName"

# Endpoint parameters
$endpointName = "myEndpointName"
$endpointProtocol = "tcp"
$endpointPublicPort = "myPort"
$endpointPrivatePort = "myPort"
$endpointTimeout = 10

Get-AzureVM -ServiceName $cloudServiceName -Name $vmName |
Add-AzureEndpoint -Name $endpointName -Protocol $endpointProtocol |
-PublicPort $endpointPublicPort -LocalPort $endpointPrivatePort |
-IdleTimeoutInMinutes $endpointTimeout |
Update-AzureVM