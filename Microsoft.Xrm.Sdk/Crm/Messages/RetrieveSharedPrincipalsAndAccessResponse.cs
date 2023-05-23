using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveSharedPrincipalsAndAccessResponse : OrganizationResponse
{
    public PrincipalAccess[] PrincipalAccesses { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        // Convert to XDocument
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        // Obtain Values from result.
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "PrincipalAccesses")
            {
                List<PrincipalAccess> list = new List<PrincipalAccess>();
                foreach (var item in result.Element(Util.ns.b + "value").Elements(Util.ns.g + "PrincipalAccess"))
                {
                    list.Add(PrincipalAccess.LoadFromXml(item));
                }
                this.PrincipalAccesses = list.ToArray();
            }
        }
    }
}