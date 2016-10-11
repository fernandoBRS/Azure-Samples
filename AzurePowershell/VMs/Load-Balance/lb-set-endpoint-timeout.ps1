# Created by: Fernando de Oliveira
# Configuring idle timeout for a Load Balance endpoint set
# Note: Timeout must be defined only during endpoint creation

$cloudServiceName = "myCloudService"
$lbSetName = "myLBSetName"

# LB endpoint set parameters
$lbSetProtocol = "tcp"
$endpointPublicPort = "myPort"
$lbSetPrivatePort = "myPrivatePort"
$lbSetProbePort = "myProbePort"
$lbSetTimeout = 10

Set-AzureLoadBalancedEndpoint -ServiceName $cloudServiceName -LBSetName $lbSetName |
-Protocol $lbSetProtocol -LocalPort $lbSetPrivatePort -ProbeProtocolTCP |
-ProbePort $lbSetProbePort -IdleTimeoutInMinutes $lbSetTimeout