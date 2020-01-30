using System;

namespace Rappen.XTB.LCG.Cmd
{
    public class CrmCredentials
    {
        public string User { get; set; }

        public String Password { get; set; }

        public String Domain { get; set; }

        public String ServerName { get; set; }

        public String OrgUnit { get; set; }

        public protocol Protocol { get; set; }

        public enum protocol
        {
            http,
            https
        }
    }
}
