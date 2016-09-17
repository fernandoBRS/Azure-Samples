# Creating the DSC package
# Created by Fernando de Oliveira

# After creating the configuration script, it is necessary to create the package.
Publish-AzureVMDSCConfiguration .\DSC\samples\webpage.ps1 -ConfigurationArchivePath .\DSC\samples\webpage.ps1.zip