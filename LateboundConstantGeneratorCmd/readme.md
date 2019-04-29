# Command Line Interface for Latebound Constants Generator

Generate constant classes out of constants generator configuration from [XRM toolbox Latebound Constants Generator](https://www.xrmtoolbox.com/plugins/Rappen.XrmToolBox.LateboundConstantsGenerator/)

## Usage
1. Credentials
LateboundConstantGeneratorCmd.exe --settingsFilePath="pathandfilename.xml" --loginDomain=YourDomain --loginUser=DomainUserName --loginPassword=YourPassword --dynOrgName=OrganizationNema --dynServerName=Servername(e.g. www.mycrmserver.com) --dynProtocol=https or http

2. Connection string
LateboundConstantGeneratorCmd.exe --settingsFilePath="pathandfilename.xml" --connectionString="conncction string"

Learn more about XRM connection strings
[Use connection strings in XRM tooling to connect to Dynamics 365 for Customer Engagement apps](https://docs.microsoft.com/en-us/dynamics365/customer-engagement/developer/xrm-tooling/use-connection-strings-xrm-tooling-connect)