using CommandLine;

namespace Rappen.XTB.LCG.Cmd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed(o =>
                {
                    var lcgHelper = new LCGHelper();
                    lcgHelper.LoadSettingsFromFile(o.SettingsFilePath);

                    var credentials = new CrmCredentials
                    {
                        Domain = o.Domain,
                        OrgUnit = o.OrgUnit,
                        ServerName = o.ServerName,
                        Password = o.Password,
                        Protocol = o.Protocol,
                        User = o.User
                    };

                    lcgHelper.ConnectCrm(credentials);
                    lcgHelper.GenerateConstants();
                });
        }
    }
}
