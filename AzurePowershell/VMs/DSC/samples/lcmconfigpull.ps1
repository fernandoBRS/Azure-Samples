[DSCLocalConfigurationManager()]
configuration LCMConfigPull
{
    Node "Server001"
    {
        # "RefreshMode" property specifies how the LCM will get configurations.

        # Using 'Pull', the node contact the configuration server at an interval
        # set by "RefreshFrequencyMins" property and downloads the current configuration.
        
        # ConfigurationID: GUID used to get a particular config file from a server.
        # ConfigurationMode: Specifies how the LCM will apply the configuration in the node.
        #      1) ApplyOnly: Only applies the configuration sent by you.
        #      2) ApplyAndMonitor: Applies the configuration sent by you and new configurations discovered in the "pull" server.
        #      2) ApplyAndAutoCorrect: Same as ApplyAndMonitor, but creating log files about the changes.
        # RefreshFrequencyMins: Default value is 15 minutes.
        # RebootNodeIfNeeded: When a configuration change, sometimes can be necessary to reboot the node.

        Settings
        {
            ConfigurationID = "646e48cb-3082-4a12-9fd9-f71b9a562d4e"
            ConfigurationMode = "ApplyAndAutoCorrect"
            RefreshMode = "Pull"
            RefreshFrequencyMins = 90
            RebootNodeIfNeeded = $true
        }
    }
}