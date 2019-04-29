using CommandLine;

namespace Rappen.XTB.LCG.Cmd
{
    class CommandLineOptions
    {
        [Option('s', "settingsFilePath", Required = true, HelpText = @"The path to the latebound constants generator configuration file (e.g. c:\temp\LcgConfig.xml)")]
        public string SettingsFilePath { get; set; }

        [Option('d', "loginDomain", Required = true, HelpText = @"credentials domain name")]
        public string Domain { get; set; }

        [Option('u', "loginUser", Required = true, HelpText = @"credentials username")]
        public string User { get; set; }

        [Option('u', "loginPassword", Required = true, HelpText = @"credentials password")]
        public string Password { get; set; }

        [Option('r', "dynOrgName", Required = true, HelpText = @"d365 organization name")]
        public string OrgUnit { get; set; }

        [Option('v', "dynServerName", Required = true, HelpText = @"d365 server name (e.g. crm.myorganization.com")]
        public string ServerName { get; set; }

        [Option('p', "dynProtocol", Required = true, HelpText = @"d365 server protocol (http or https)")]
        public CrmCredentials.protocol Protocol { get; set; }

        // ToDo: Add option to usae connectionstrings
    }
}