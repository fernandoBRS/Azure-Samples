[DSCLocalConfigurationManager()]
configuration LCMConfigPush
{
    Node localhost
    {
        # "RefreshMode" property specifies how the LCM will get configurations.
        # Using 'Push', the node will call the Start-DscConfiguration cmdlet.
        
        Settings
        {
            RefreshMode = 'Push'
        }
    }
}