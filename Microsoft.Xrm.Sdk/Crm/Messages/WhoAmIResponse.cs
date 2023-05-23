using System;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class WhoAmIResponse : OrganizationResponse
{
    public Guid UserId { get; set; }
    public Guid BusinessUnitId { get; set; }
    public Guid OrganizationId { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        // Convert to XDocument
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        // Obtain Values from result.
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "UserId")
                this.UserId = Util.LoadFromXml<Guid>(result.Element(Util.ns.b + "value"));
            else if (result.Element(Util.ns.b + "key").Value == "BusinessUnitId")
                this.BusinessUnitId = Util.LoadFromXml<Guid>(result.Element(Util.ns.b + "value"));
            else if (result.Element(Util.ns.b + "key").Value == "OrganizationId")
                this.OrganizationId = Util.LoadFromXml<Guid>(result.Element(Util.ns.b + "value"));
        }
    }
}