configuration WebPage
{
    Node localhost
    {
        # Ensures that IIS is enabled
        
        WindowsFeature IIS
        {
            Ensure = "Present"
            Name = "Web-Server"
        }

        # Ensures that Hyper-V role is installed
        # Path to log the operation

        WindowsFeature HyperVRole
        {
            Ensure = "Present"
            Name = "Hyper-V"
            LogPath = "C:\DSCLog_HyperV.txt"
        }

        # Ensures that Failover features is removed

        WindowsFeature FailoverClusterRole
        {
            Ensure = "Absent"
            Name = "Failover-Clustering"
        }

        # Copying a single file as default website
        # "Force" property will copy the file in destination path even if there is any error
        # "Type" property will indicate if the resource is a file or a directory.

        File WebPage
        {
            Ensure = "Present"
            DestinationPath = "C:\myWebsite\wwwroot\index.html"
            Force = $true
            Type = "File"
            Contents = '<html><body><h1>Welcome to the Website!</h1></body></html>'
        }
    }
}