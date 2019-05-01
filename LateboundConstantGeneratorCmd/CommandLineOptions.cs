using CommandLine;

namespace Rappen.XTB.LCG.Cmd
{
    class CommandLineOptions
    {
        [Option('s', "settingsFilePath", Required = true, HelpText = @"The path to the latebound constants generator configuration file (e.g. c:\temp\LcgConfig.xml)")]
        public string SettingsFilePath { get; set; }

        [Option('c', "connectionString", Required = false, HelpText = @"connection string (for more information see: https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/xrm-tooling/use-connection-strings-xrm-tooling-connect")]
        public string ConnectionString { get; set; }

        [Option('d', "loginDomain", Required = false, HelpText = @"credentials domain name")]
        public string Domain { get; set; }

        [Option('u', "loginUser", Required = false, HelpText = @"credentials username")]
        public string User { get; set; }

        [Option('u', "loginPassword", Required = false, HelpText = @"credentials password")]
        public string Password { get; set; }

        [Option('r', "dynOrgName", Required = false, HelpText = @"d365 organization name")]
        public string OrgUnit { get; set; }

        [Option('v', "dynServerName", Required = false, HelpText = @"d365 server name (e.g. crm.myorganization.com")]
        public string ServerName { get; set; }

        [Option('p', "dynProtocol", Required = false, HelpText = @"d365 server protocol (http or https)")]
        public CrmCredentials.protocol Protocol { get; set; }
    }
}