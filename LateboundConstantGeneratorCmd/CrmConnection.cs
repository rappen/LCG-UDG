using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace Rappen.XTB.LCG.Cmd
{
    public class CrmConnection
    {
        private CrmServiceClient crmServiceClient;

        public IOrganizationService OrganizationService { get; private set; }
        public string WebApplicationUrl { get; }

        public int OrganizationMajorVersion
        {
            get
            {
                return int.Parse(crmServiceClient.ConnectedOrgVersion.ToString().Split('.')[0]);
            }
        }

        private CrmConnection(OrganizationServiceProxy organizationService, string webApplicationUrl)
        {
            this.OrganizationService = organizationService;
            this.crmServiceClient = new CrmServiceClient(organizationService);
            this.WebApplicationUrl = webApplicationUrl;
        }


        public static CrmConnection ConnectCrm(CrmCredentials credentials)
        {
            var organizationServiceUri = $@"{credentials.Protocol}://{credentials.ServerName}/{credentials.OrgUnit}/XRMServices/2011/Organization.svc";
            var serverUri = new Uri(organizationServiceUri);
            var clientCredentials = new ClientCredentials();

            clientCredentials.Windows.ClientCredential = new NetworkCredential(credentials.User, credentials.Password, credentials.Domain);
            var organizationServiceProxy = new OrganizationServiceProxy(serverUri, null, clientCredentials, null);
            organizationServiceProxy.EnableProxyTypes();
           return new CrmConnection(organizationServiceProxy, organizationServiceUri);
        }
    }
}
