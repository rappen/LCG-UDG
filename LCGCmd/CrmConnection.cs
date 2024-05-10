using System;
using System.Net;
using System.ServiceModel.Description;

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;

namespace Rappen.XTB.LCG.Cmd
{
    public class CrmConnection
    {
        private readonly CrmServiceClient crmServiceClient;
        public string WebApplicationUrl { get; }

        public IOrganizationService OrganizationService => this.crmServiceClient.OrganizationServiceProxy;

        public int OrganizationMajorVersion => int.Parse(crmServiceClient.ConnectedOrgVersion.ToString().Split('.')[0]);

        private CrmConnection(OrganizationServiceProxy organizationService, string webApplicationUrl)
        {
            this.crmServiceClient = new CrmServiceClient(organizationService);
            this.WebApplicationUrl = webApplicationUrl;
        }

        private CrmConnection(CrmServiceClient crmServiceClient)
        {
            this.crmServiceClient = crmServiceClient;
            this.WebApplicationUrl = crmServiceClient.CrmConnectOrgUriActual.ToString();
        }

        public static CrmConnection ConnectCrm(string connectionString)
        {
            var crmServiceClient = new CrmServiceClient(connectionString);
            return new CrmConnection(crmServiceClient);
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
