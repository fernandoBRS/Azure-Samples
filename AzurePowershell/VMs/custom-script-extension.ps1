# Adding the Custom Script Extension to a VM
# Created by Fernando de Oliveira

$updatedVmName = "myUpdatedVMName"
$vmName = "myVmName"
$scriptFile1 = "http://storageAccountName.blob.core.windows.net/myContainer/script1.ps1"
$scriptFile2 = "http://storageAccountName.blob.core.windows.net/myContainer/script2.ps1"
$scriptToRun = "script1.ps1"
$arguments = "arg1 arg2"

$cloudServiceName = "myCloudServiceName"

Set-AzureVMCustomScriptExtension -VM $updatedVmName -FileUri $scriptFile1, $scriptFile2 |
-Run $scriptToRun -Argument $arguments;
Update-AzureVM -ServiceName $cloudServiceName -Name $vmName -VM $updatedVmName